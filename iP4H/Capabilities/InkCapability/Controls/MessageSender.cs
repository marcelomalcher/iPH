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
using LAC.Ink;
using CompactFormatter;

namespace CCXP.Capabilities.CP.Ink.Controls
{
    /// <summary>
    /// Package and send messages between presenters and viewers.
    /// </summary>
    public class MessageSender
    {
        private MainControl parent;		// Main Control

        // The sending queue manages the outgoing messages.  The sending queues sender is initialized 
        // externally
        private SendingQueue sendingQueue = null;

        // We want to stop sending when were are disposing.  This property should be set externally when 
        // disposing is initiated.
        private bool isDisposing;
        public bool IsDisposing
        {
            get { return this.isDisposing; }
            set { this.isDisposing = value; }
        }

        public MessageSender(MainControl parent)
            : this(null, parent)
        {
        }

        public MessageSender(SendingQueue sendingQueue, MainControl parent)
        {
            this.isDisposing = false;
            this.sendingQueue = sendingQueue;
            this.parent = parent;
        }

        // Called by all sending methods, will determine which network layer to use
        private void Send(object objToSend)
        {
            if (this.parent.ConnectionState == MainControl.ConnectionMode.RTP)
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

        public void SendString(String str)
        {
            this.Send(str);
        }

        public void SendStroke(Stroke stroke)
        {
            this.Send(stroke);
        }
    }
}
