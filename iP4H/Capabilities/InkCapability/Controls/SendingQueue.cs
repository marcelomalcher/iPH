using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

using CF.MSR.LST.Net.Rtp;
using CF.MSR.LST;
using CF.MSR.LST.ConferenceXP;

namespace CCXP.Capabilities.CP.Ink.Controls
{
    public class SendingQueue
    {
        private RtpSender rtpSender = null;

        private Capability capability;

        private MainControl mainControl = null;	// Link back to the main control for error handling

        private Queue messageQueue;
        private Thread sendingThread;

        public SendingQueue(MainControl mainControl, RtpSender rtpSender)
        {
            this.mainControl = mainControl;
            this.rtpSender = rtpSender;
            Restart();
        }

        // This is ugly - we need to initialize the sending queue before the rtpsender has been created
        // The hack is just to pass in the capability, and create the sender on the first send
        public SendingQueue(MainControl mainControl, Capability capability)
        {
            this.mainControl = mainControl;
            this.capability = capability;
            this.rtpSender = null;
            Restart();
        }


        public void Restart()
        {
            this.messageQueue = new Queue();
            StartSendingThread();
        }

        private void StartSendingThread()
        {
            this.sendingThread = new Thread(new ThreadStart(SendingThreadStart));
            this.sendingThread.Name = "Sending Thread";
            this.sendingThread.IsBackground = true;
            this.sendingThread.Start();
        }

        // Kill the sending thread and the rtpSender
        public void Dispose()
        {
            bool locked = false;
            try
            {
                locked = Monitor.TryEnter(this); // Wait a moment if anyone's sending

                this.sendingThread.Abort();
                if (this.rtpSender != null)
                {
                    this.rtpSender.Dispose();
                    this.rtpSender = null;
                }
                this.messageQueue = null;
            }
            finally
            {
                if (locked) Monitor.Exit(this);
            }
        }

        // Send a message or queue it
        public void SendMessage(BufferChunk bc)
        {
            lock (this)
            {
                this.messageQueue.Enqueue(bc);
            }
        }

        // Send the message - if the network connection has been lost, a socket exception is thrown.
        // We also ignore and swallow the Object Disposed Exception - because of the shutdown logic
        private void Send(BufferChunk bc)
        {
            try
            {
                if (this.rtpSender == null && this.capability != null)
                {
                    this.rtpSender = this.capability.RtpSender;
                }
                if (this.rtpSender != null)
                    this.rtpSender.Send(bc);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                MessageBox.Show("The network connection has been dropped, try reconnecting to the venue.\r\n+Error: " + e.Message,
                    "Network Connection Dropped");
                mainControl.OnInvokeDisconnect(new System.EventArgs());
            }
            catch (ObjectDisposedException)
            {		// Ignore - shutting down.
            }
        }

        private void SendingThreadStart()
        {
            try
            {
                while (true)
                {
                    BufferChunk bc = null;
                    bool done = false;

                    while (!done)
                    {
                        lock (this)
                        {
                            if (messageQueue.Count > 0)
                            {
                                bc = (BufferChunk)messageQueue.Dequeue();
                            }
                            if (messageQueue.Count <= 0)
                                done = true;
                        }

                        if (bc != null)
                        {
                            Send(bc);
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception e)
            {   // Only complain about exceptions if we are not disposing
                if (!this.mainControl.isDisposing)
                {
                    MessageBox.Show("Anonymous exception caught in Sending Queue \r\n" + e.Message);
                }
            }
        }

        private delegate void DisconnectDelegate();


    }
}
