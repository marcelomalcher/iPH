using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using CF.MSR.LST.Net.Rtp;
using CF.MSR.LST;
using CF.MSR.LST.RTDocuments;
using OpenNETCF.Diagnostics;
using CompactFormatter;

namespace iP4H.Commons.Communications
{
    /// <summary>
    /// Package and send messages
    /// </summary>
    public class MessageSender
    {
        #region Members

        // Main Control
        private CommunicationControl parent;		

        // The sending queue manages the outgoing messages.  The sending queues sender is initialized 
        // externally
        private SendingQueue sendingQueue = null;

        // We want to stop sending when were are disposing.  This property should be set externally when 
        // disposing is initiated.
        private bool isDisposing;

        #endregion

        #region Properties

        public bool IsDisposing
        {
            get { return this.isDisposing; }
            set { this.isDisposing = value; }
        }

        #endregion

        #region Constructors

        public MessageSender(CommunicationControl parent)
            : this(null, parent)
        {
        }

        public MessageSender(SendingQueue sendingQueue, CommunicationControl parent)
        {
            this.isDisposing = false;
            this.sendingQueue = sendingQueue;
            this.parent = parent;
        }

        #endregion

        #region Send
        
        //
        public void SendObject(Object obj)
        {
            this.Send(obj);
        }

        // Called by all sending methods, will determine which network layer to use
        private void Send(object objToSend)
        {
            if (this.parent.ConnectionState == CommunicationControl.ConnectionMode.RTP)
            {
                BufferChunk bc = Utility.ToBufferChunk(objToSend);
                this.RTPSend(bc);
            }
        }

        // Send a message - all we are doing is using the rtpSend.  Several threads could compete for this - event threads
        // and the broadcast thread, so we need to lock it
        private void RTPSend(BufferChunk bc)
        {
            // Once we begin to dispose, we stop sending
            lock (this)
            {
                if (this.sendingQueue != null && !this.isDisposing)
                    this.sendingQueue.SendMessage(bc);
            }
        }

        #endregion
    }
}
