# region Include
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;
using System.IO;

using CF.MSR.LST.Net.Rtp;
using CF.MSR.LST;
using CF.MSR.LST.ConferenceXP;
using CF.MSR.LST.RTDocuments;
using CF.ReflectorRegistrarClient;

using OpenNETCF.Diagnostics;

using CompactFormatter;
using CompactFormatter.Attributes;

using iP4H.Commons.Forms;

# endregion

namespace iP4H.Commons.Communications
{
    public class CommunicationControl
    {

        # region Members

        # region Networking Members

        // The message sender is responsible for packaging and sending messages, the RTPSender resides in the 
        // sending queue which is given to the message sender
        public SendingQueue sendingQueue = null;
        public MessageSender messageSender = null;

        // Record SSRC of the sender to avoid creating a listener to self
        public uint mySSRC = 0;

        public RtpSession rtpSession = null;

        // ConnectionMode
        public enum ConnectionMode { RTP, Disconnected };
        private ConnectionMode myConnectionMode = ConnectionMode.Disconnected;

        # endregion

        # region General Members

        public bool isDisposing = false;
        public bool isLoading = false;

        private object myLockObject;
        private static RegistrarClient regClient = null;

        # endregion

        # endregion
        
        # region Constructors

        public CommunicationControl(object lockObject)
            : base()
        {
            this.LockObject = lockObject;
            this.messageSender = new MessageSender(this);
            RtpEvents.RtpStreamAdded += new RtpEvents.RtpStreamAddedEventHandler(this.OnRtpStreamAdded);
            InvokeReceiveDelegate += new ReceiveDelegateEventHandler(this.OnInvokeReceiveDelegate);                       
        }

        public void Dispose()
        {
            // Stop doing other things
            this.isDisposing = true;
            if (this.messageSender != null)
                this.messageSender.IsDisposing = true;
            // Close Any Connections
            this.CloseRtpConnections();
        }

        # endregion
        
        # region Properties

        public object LockObject
        {
            set
            {
                if (value != null)
                    myLockObject = value;
            }
            get { return myLockObject; }
        }

        public ConnectionMode ConnectionState
        {
            get { return this.myConnectionMode; }
            set { this.myConnectionMode = value; }
        }

        # endregion

        # region Invoke

        //Send an event to disconnect from venue.
        public event EventHandler InvokeDisconnect;

        public virtual void OnInvokeDisconnect(EventArgs args)
        {
            if (this.InvokeDisconnect != null)
                this.InvokeDisconnect(this, args);
        }

        //Send an event to receive a delegate
        public event ReceiveDelegateEventHandler InvokeReceiveDelegate;

        protected virtual void OnInvokeReceiveDelegate(ReceiveDelegateEventArgs args)
        {
            if (this.InvokeReceiveDelegate != null)
                this.InvokeReceiveDelegate(this, args);
        }

        public class ReceiveDelegateEventArgs : EventArgs
        {
            Object obj;
            int id;

            public Object Obj { get { return obj; } }
            public Object Id { get { return id; } }

            public ReceiveDelegateEventArgs()
                : base()
            {
                this.obj = null;
                this.id = 0;
            }

            public ReceiveDelegateEventArgs(Object obj, int id)
                : base()
            {
                this.obj = obj;
                this.id = id;
            }
        }

        public delegate void ReceiveDelegateEventHandler(object sender, ReceiveDelegateEventArgs args);

        # endregion

        # region Connect

        #region RTP Calls

        // Start up rtp listeners and senders
        // verify performance
        public bool Connect(string ipAddressString, ushort portNumber, ushort ttl, String connectionName)
        {
            if (ipAddressString == null || portNumber == 0)
                return false;

            // If connections are open, close them
            this.CloseRtpConnections();		

            this.myConnectionMode = ConnectionMode.RTP;

            IPAddress ipAddress = IPAddress.Parse(ipAddressString);

            RtpSender rtpSender = null;

            try
            {
                RtpParticipant participant = new RtpParticipant(connectionName, "Name");
                this.rtpSession = new RtpSession(new IPEndPoint(ipAddress, portNumber), participant, true, true);
                // fec needs to be chosen during creation of RtpSender
                ushort fec = 100;  //Default is 100%
                rtpSender = rtpSession.CreateRtpSenderFec(connectionName, CF.MSR.LST.Net.Rtp.PayloadType.dynamicPresentation, null, 0, fec);
                rtpSender.DelayBetweenPackets = 5;
            }
            catch (System.Net.Sockets.SocketException se)
            {
                MessageBox.Show("Connection failed\n\rMachine must be connected to a network.\r\n"
                    + "If you repeatedly encounter this error, you may need to restart your machine.\r\n"
                    + "This is a known bug.  Thanks for your patience.\r\n"
                    + "Error: " + se.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection failed: " + e.ToString());
                return false;
            }

            sendingQueue = new SendingQueue(this, rtpSender);
            messageSender = new MessageSender(sendingQueue, this);

            // Record SSRC - this is used to avoid creating a listener to self
            this.mySSRC = rtpSender.SSRC;

            return true;
        }

        public void CloseRtpConnections()
        {
            this.myConnectionMode = ConnectionMode.Disconnected;
            lock (this.LockObject)
            {
                if (this.rtpSession != null)
                {
                    this.rtpSession.Dispose();
                    this.rtpSession = null;
                    if (regClient != null)
                    {
                        regClient.leave();
                        regClient = null;
                    }

                }
            }
            lock (this.LockObject)
            {
                this.messageSender = new MessageSender(this);
            }
            lock (this.LockObject)
            {
                if (this.sendingQueue != null)
                {
                    this.sendingQueue.Dispose();
                    this.sendingQueue = null;
                }
            }
        }

        // For now - only listen to DynamicPresentation streams
        public void OnRtpStreamAdded(object sender, RtpEvents.RtpStreamEventArgs ea)
        {
            if (sender == this.rtpSession)
            {
                if (ea.RtpStream.SSRC != this.mySSRC && ea.RtpStream.PayloadType == CF.MSR.LST.Net.Rtp.PayloadType.dynamicPresentation)
                {
                    // Hook the frame received event
                    ea.RtpStream.FrameReceived += new CF.MSR.LST.Net.Rtp.RtpStream.FrameReceivedEventHandler(FrameReceived);
                }
            }
        }

        // Creat a listening thread.  The complication here is passing an argument (the stream) to the thread
        // This is done rather opaquely creating a secondary class for passing the arguments.
        public delegate void ListeningThreadMethod(RtpStream rtpStream);

        public class ListeningMethodArguements
        {
            public RtpStream rtpStream;
            public ListeningThreadMethod threadMethod;

            public ListeningMethodArguements(ListeningThreadMethod threadMethod, RtpStream rtpStream)
            {
                this.threadMethod = threadMethod;
                this.rtpStream = rtpStream;
            }

            public void CallThreadMethod()
            {
                threadMethod(rtpStream);
            }
        }

        // Send a message - all we are doing is using the rtpSend.  Several threads could compete for this - event threads
        // and the broadcast thread, so we need to lock it
        // The locking has been moved from locking the form to locking the sender
        public void RtpSend(BufferChunk bc)
        {
            lock (this.LockObject)
            {
                if (sendingQueue != null && !this.isDisposing)
                    sendingQueue.SendMessage(bc);
            }
        }

        # endregion

        # endregion

        #region Receive operations

        // When packets come in, we look at the op code and process according.  As the presenter, some of the codes are 
        // are ignored since it is assumed that they are originating from the presenter.  This design will need to be 
        // addressed
        private void FrameReceived(object sender, RtpStream.FrameReceivedEventArgs ea)
        {           
            RtpStream rtpStream = (RtpStream)sender;
           
            // Ignore messages from oneself
            if (rtpStream.SSRC == this.mySSRC)	
                return;

            try
            {
                MemoryStream ms = new MemoryStream((byte[])ea.Frame);

                //Deserializing with CompactFormatter..
                CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
                Object obj = cf.Deserialize(ms);

                // For the UI Thread
                if (!this.isDisposing)
                    this.InvokeReceiveDelegate(this, new ReceiveDelegateEventArgs(obj, 0));

            }
            catch (System.ArgumentException e)
            {
                Debug.WriteLine(e.Message);       // Just for now - this is a known problem
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Anonymous exception caught in FrameReceived " + e.Message + "\r\n" + e.StackTrace);
            }
        }

        // Process an incoming message as an object
        public delegate void ReceiveDelegate(Object obj, int senderID);
        public void Receive(Object obj, int senderID)
        {
            ((InteractivePresentationForm)LockObject).ReceiveObject(obj);
        }

        #endregion

        #region Invoke
        public void OnInvokeReceiveDelegate(object sender, ReceiveDelegateEventArgs args)
        {
            this.Receive(args.Obj, (int)args.Id);
        }
        #endregion

    }
}
