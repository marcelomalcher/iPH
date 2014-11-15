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

# endregion

namespace CCXP.Capabilities.CP.Ink.Controls
{
    public class MainControl
    {

        # region Members

        # region Cursors

        public bool waitCursor;

        # endregion

        # region Networking Members

        // The message sender is responsible for packaging and sending messages, the RTPSender resides in the 
        // sending queue which is given to the message sender
        public SendingQueue sendingQueue = null;
        public MessageSender messageSender = null;

        //Service thread
        public Thread senderThread = null;

        //Beacon liveness thread
        public Thread beaconThread = null;

        // Record SSRC of the sender to avoid creating a listener to self
        public uint mySSRC = 0;

        public RtpSession rtpSession = null;

        // Is the presenter going to broadcast slides on request
        public bool acceptBroadcastRequests = false;

        private CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);

        // *******
        public enum ConnectionMode { RTP, Disconnected };
        private ConnectionMode myConnectionMode = ConnectionMode.Disconnected;
        // *******

        # endregion

        # region General Members

        public bool isDisposing = false;

        // RJA 
        // We have problems if we perform some operations while loading - this is a hack
        public bool isLoading = false;

        private object myLockObject;

        private static RegistrarClient regClient = null;

        # endregion

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

        # region Constructors

        public MainControl(object lockObject)
            : base()
        {
            this.LockObject = lockObject;
            this.messageSender = new MessageSender(this);
        }

        public void Dispose()
        {
            this.isDisposing = true;					// Stop doing other things
            if (this.messageSender != null)
                this.messageSender.IsDisposing = true;
            this.CloseRtpConnections();             // Close Any Connections
        }

        # endregion

        # region Event

        # region FilmStrip

        public event EventHandler UpdateFilmstrip;

        protected virtual void OnUpdateFilmstrip(EventArgs args)
        {
            if (this.UpdateFilmstrip != null)
                this.UpdateFilmstrip(this, args);
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

        //Send an event to invoke the update PVStatusPanel
        public event EventHandler InvokeUpdatePVStatus;

        protected virtual void OnInvokeUpdatePVStatus(EventArgs args)
        {
            if (this.InvokeUpdatePVStatus != null)
                this.InvokeUpdatePVStatus(this, args);
        }

        # endregion

        # region Layers

        public event EventHandler UpdateLayers;

        protected virtual void OnUpdateLayers(EventArgs args)
        {
            if (this.UpdateLayers != null)
                this.UpdateLayers(this, args);
        }

        # endregion

        # region Main View

        # region Buttons

        public event SendSelectionEventHandler SetSendSelection;

        protected virtual void OnSetSendSelection(SendSelectionEventArgs args)
        {
            if (this.SetSendSelection != null)
                this.SetSendSelection(this, args);
        }

        public class SendSelectionEventArgs : EventArgs
        {
            bool sendSelectionValue;

            public bool SendSelectionValue { get { return sendSelectionValue; } }

            public SendSelectionEventArgs()
                : base()
            {
                this.sendSelectionValue = false;
            }

            public SendSelectionEventArgs(bool val)
                : base()
            {
                this.sendSelectionValue = val;
            }
        }

        public delegate void SendSelectionEventHandler(object sender, SendSelectionEventArgs args);

        # endregion

        # region Cursor

        public event CursorEventHandler SetCursor;

        protected virtual void OnSetCursor(CursorEventArgs args)
        {
            if (this.SetCursor != null)
                this.SetCursor(this, args);
        }

        public class CursorEventArgs : EventArgs
        {
            bool waitCursorValue;

            public bool WaitCursorValue { get { return waitCursorValue; } }

            public CursorEventArgs()
                : base()
            {
                this.waitCursorValue = false;
            }

            public CursorEventArgs(bool val)
                : base()
            {
                this.waitCursorValue = val;
            }
        }

        public delegate void CursorEventHandler(object sender, CursorEventArgs args);

        # endregion

        # region Form Text

        public event EventHandler SetFormText;

        protected virtual void OnSetFormText(EventArgs args)
        {
            if (this.SetFormText != null)
                this.SetFormText(this, args);
        }

        # endregion

        # region Load

        public event LoadRtdEventHandler LoadRtd;

        protected virtual void OnLoadRtd(LoadRtdEventArgs args)
        {
            if (this.LoadRtd != null)
                this.LoadRtd(this, args);
        }

        public class LoadRtdEventArgs : EventArgs
        {
            RTDocument rtDoc;

            public RTDocument RtDoc { get { return rtDoc; } }

            public LoadRtdEventArgs()
                : base()
            {
                this.rtDoc = null;
            }

            public LoadRtdEventArgs(RTDocument rtDoc)
                : base()
            {
                this.rtDoc = rtDoc;
            }
        }

        public delegate void LoadRtdEventHandler(object sender, LoadRtdEventArgs args);

        # endregion

        # endregion

        # region Reset

        public event EventHandler Reset;

        protected virtual void OnReset(EventArgs args)
        {
            if (this.Reset != null)
                this.Reset(this, args);
        }

        # endregion

        # endregion

        # region Thread

        # endregion

        # region Connect

        # region Names
        // We need to generate a name to use for the connection.  We need to handle two cases - first, the DISC case
        // uses the messenger name (to allow eventual passport authentication.  However, we also need to support a 
        // testing mode which supports multiple instances on the same machine.

        // Name is machine name + current time.  This assume no two instances started at the same time
        public string GenerateUniqueName()
        {
            DateTime dt = DateTime.Now;
            string name = "TESTE" + "_" + dt.Ticks;

            return name;
        }

        public string GenerateMessengerName()
        {
            string logonName = "";
            try
            {
                CF.MSR.LST.ConferenceXP.Identity.Identifier = this.GenerateUniqueName();
                logonName = CF.MSR.LST.ConferenceXP.Identity.Identifier;
            }
            catch (Exception noMessenger)
            {
                Debug.WriteLine(noMessenger.Message);
                logonName = "disc@learningwebservices.com";
            }

            return logonName;
        }

        # endregion

        #region RTP Calls

        // Start up rtp listeners and senders
        public bool Connect(string ipAddressString, ushort portNumber, ushort ttl, String connectionName)
        {
            //			this.TokenHolder = 0;
            if (ipAddressString == null || portNumber == 0)
                return false;


            this.CloseRtpConnections();		// If connections are open, close them

            this.myConnectionMode = ConnectionMode.RTP;

            IPAddress ipAddress = IPAddress.Parse(ipAddressString);

            RtpSender rtpSender = null;

            try
            {
                RtpParticipant participant = new RtpParticipant(connectionName, "Name");
                this.rtpSession = new RtpSession(new IPEndPoint(ipAddress, portNumber), participant, true, true);
                // fec needs to be chosen during creation of RtpSender.  Read from config file...
                ushort fec = 100;  //Default is 100%
                if (fec == 0)
                {
                    rtpSender = rtpSession.CreateRtpSender(connectionName, CF.MSR.LST.Net.Rtp.PayloadType.dynamicPresentation, null);
                }
                else
                {
                    rtpSender = rtpSession.CreateRtpSenderFec(connectionName, CF.MSR.LST.Net.Rtp.PayloadType.dynamicPresentation, null, 0, fec);
                }

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

            // -- END ADDED
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

        //		public static Thread CreateTheListeningThread(ListeningThreadMethod start, RtpStream rtpStream){
        //			ListeningMethodArguements args = new ListeningMethodArguements(start, rtpStream);
        //			Thread t = new Thread(new ThreadStart(args.CallThreadMethod));
        //			t.Name = "Listening thread";
        //			t.IsBackground = true;
        //			return t;
        //		}




        // Send a message - all we are doing is using the rtpSend.  Several threads could compete for this - event threads
        // and the broadcast thread, so we need to lock it
        // The locking has been moved from locking the form to locking the sender
        public void RtpSend(BufferChunk bc)
        {

            // Once we begin to dispose, we stop sending
            lock (this.LockObject)
            {
                if (sendingQueue != null && !this.isDisposing)
                    sendingQueue.SendMessage(bc);
            }
        }

        # endregion



        # endregion

        # region Token

        //		public uint myTokenHolder = 0;
        //		public uint TokenHolder {
        //			get { return myTokenHolder; }
        //			set { 
        //				if (value != this.myTokenHolder) {
        //	//				bool oldAmITokenHolder = this.AmITokenHolder();
        //					myTokenHolder = value; 
        //	//				if (oldAmITokenHolder != this.AmITokenHolder())
        //	//					this.UpdateModes(); 
        //				}
        //			}
        //		}

        //		public bool IsTokenHolder(uint id) {
        //			if (this.TokenHolder == 0)
        //				// HACK: this is interfering with the capability viewer. Check only that this isn't the viewer.
        //				//return (uint)this.wsp.PresenterID == id;
        //				return this.Role == ViewerFormControl.RoleType.Presenter ? ((uint)this.wsp.ID == id) : ((uint)this.wsp.ID != id);
        //			else
        //				return id == this.TokenHolder;
        //		}

        //		public bool AmITokenHolder() {
        //			return this.IsTokenHolder((uint)this.wsp.ID);
        //		}

        //		public bool RequiresToken(byte opcode) {
        //			return 
        //				opcode == PacketType.SlideIndex ||
        //				opcode == PacketType.Slide ||
        //				opcode == PacketType.DummySlide ||
        //				opcode == PacketType.Scribble ||
        //				opcode == PacketType.Highlight ||
        //				opcode == PacketType.Pointer ||
        //				opcode == PacketType.Scroll ||
        //				opcode == PacketType.ClearAnnotations ||
        //				opcode == PacketType.ResetSlides ||
        //				opcode == PacketType.ScreenConfiguration ||
        //				opcode == PacketType.ClearSlide ||
        //				opcode == PacketType.ClearScribble ||
        //				opcode == PacketType.ScribbleDelete;
        //		}

        # endregion

        #region Send operations

        #region Capability

        private Capability capability = null;
        public Capability Capability
        {
            get { return capability; }
            set { capability = value; }
        }

        public void StartCapabilityThreads()
        {


            // This is a hack to try to make sure the RtpSender exists
            //			if (this.Capability.RtpSender == null)
            //				this.Capability.SendObject(new EmptyObject());

            // -- MODIFIED: CMPRINCE ARCHIVING PARTIALSTROKE
            SendingQueue sendingQueue = new SendingQueue(this, this.Capability);
            this.messageSender = new MessageSender(sendingQueue, this);
        }
        #endregion Capability

        public delegate void DisconnectDelegate(bool isCleanup);

        # region Broadcast
        public void BroadcastString(String str)
        {
            this.messageSender.SendString(str);

        }

        # endregion

        #endregion

        #region Receive operations

        // When packets come in, we look at the op code and process according.  As the presenter, some of the codes are 
        // are ignored since it is assumed that they are originating from the presenter.  This design will need to be 
        // addressed
        private void FrameReceived(object sender, RtpStream.FrameReceivedEventArgs ea)
        {

            RtpStream rtpStream = (RtpStream)sender;
            if (rtpStream.SSRC == this.mySSRC)			// Ignore messages from oneself
                return;

            try
            {
                MemoryStream ms = new MemoryStream((byte[])ea.Frame);

                Object obj = cf.Deserialize(ms);


                // For the UI Thread
                if (!this.isDisposing)
                    this.InvokeReceiveDelegate(this, new MainControl.ReceiveDelegateEventArgs(obj, 0));

            }
            catch (System.ArgumentException e)
            {
                Debug.WriteLine(e.Message);       // Just for now -this is a known problem
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Anonymous exception caught in FrameReceived " + e.Message + "\r\n" + e.StackTrace);
            }
        }

        # region Receive

        // Process an incoming message as an object
        public delegate void ReceiveDelegate(Object obj, int senderID);
        public void Receive(Object obj, int senderID)
        {
            lock (this.LockObject)
            {
                ((InkFMain)LockObject).ReceiveObject(obj);
            }
        }

        public void ReceiveString(String str)
        {
            lock (this.LockObject)
            {
                ((InkFMain)LockObject).ReceiveObject(str);
            }
        }

        # region Receive Capability
        private int orhCount = 0;		// Temporary debugging counter

        public void ObjectReceivedHandler(object objReceived, ObjectReceivedEventArgs oArgs)
        {

            //		MessageBox.Show(this, "Capability: Event received!");

            if (oArgs.Participant == Conference.LocalParticipant)
            {
                //				Debug.WriteLine("Message from self: " + oArgs.Data.GetType().ToString());
                return;
            }

            object obj = oArgs.Data;
            orhCount++;

            Debug.WriteLine(oArgs.Data.GetType().ToString() + "  " + orhCount);

            if (!this.isDisposing)
                this.InvokeReceiveDelegate(this, new MainControl.ReceiveDelegateEventArgs(obj, 0));
        }

        #endregion Receive Capability

        #endregion

        #endregion

    }
}
