using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

using CF.MSR.LST.Net.Rtp;
using CF.MSR.LST;
using CF.MSR.LST.ConferenceXP;

namespace LAC.Communications
{
    public class SendingQueue
    {
        private RtpSender rtpSender = null;
        // Link back to the main control for error handling
        private CommunicationControl mainControl = null;	
        private Queue messageQueue;
        private Thread sendingThread;
        //
        private AutoResetEvent newObject = new AutoResetEvent(false);

        public SendingQueue(CommunicationControl mainControl, RtpSender rtpSender)
        {
            this.mainControl = mainControl;
            this.rtpSender = rtpSender;           
            Restart();
        }

        public void Restart()
        {
            this.messageQueue = new Queue();
            newObject = new AutoResetEvent(false);
            StartSendingThread();
        }

        // Kill the sending thread and the rtpSender
        public void Dispose()
        {
            bool locked = false;
            try
            {
                // Wait a moment if anyone's sending
                locked = Monitor.TryEnter(this);

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
                if (locked)
                    Monitor.Exit(this);
            }
        }

        private void StartSendingThread()
        {
            this.sendingThread = new Thread(new ThreadStart(SendingThreadStart));
            this.sendingThread.Name = "Sending Thread";
            this.sendingThread.IsBackground = true;
            this.sendingThread.Start();
        }

        private void SendingThreadStart()
        {
            try
            {
                while (true)
                {
                    BufferChunk bc = null;
                    bool done = false;                    

                    lock (this)
                    {
                        // Wait until a message comes in, 
                        // either in the messageQueue.
                        if (this.messageQueue.Count <= 0)
                        {
                            newObject.WaitOne();
                        }
                    }

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
            {
                // Only complain about exceptions if we are not disposing
                if (!this.mainControl.isDisposing)
                {
                    MessageBox.Show("Anonymous exception caught in Sending Queue \r\n" + e.Message);
                }
            }
        }

        // Send a message or queue it
        public void SendMessage(BufferChunk bc)
        {
            this.messageQueue.Enqueue(bc);
            newObject.Set();
        }

        // Send the message - if the network connection has been lost, a socket exception is thrown.
        // We also ignore and swallow the Object Disposed Exception - because of the shutdown logic
        private void Send(BufferChunk bc)
        {
            try
            {
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
            {
                // Ignore - shutting down.
            }
        }        
    }
}
