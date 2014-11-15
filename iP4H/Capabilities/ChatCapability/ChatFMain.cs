using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CF.MSR.LST.ConferenceXP;
using CF.MSR.LST.Net.Rtp;
using iP4H.Commons.Controls;
using iP4H.Commons.Intefaces;

namespace CCXP.Capabilities.CP.Chat
{
    public partial class ChatFMain : CapabilityForm, IForm
    {
        #region Attributes
        
        private MainControl formControl;

        #endregion

        #region Constructors & Initializers
        public ChatFMain()            
        {
            InitializeComponent();
            this.formControl = new MainControl(this);
        }

        public void InitializeForm()
        {
            this.SuspendLayout();            
            this.FormControl.InvokeReceiveDelegate += new MainControl.ReceiveDelegateEventHandler(this.OnInvokeReceiveDelegate);
            this.ResumeLayout();
        }
        #endregion

        #region Properties

        public MainControl FormControl
        {
            get { return this.formControl; }
        }

        #endregion

        #region ICapabilityForm

        public override void AddCapability(ICapability capability)
        {
            base.AddCapability(capability);
        }

        public override bool RemoveCapability(ICapability capability)
        {
            bool ret = base.RemoveCapability(capability);

            return ret;
        }

        #endregion ICapabilityForm

        # region Invoke

        public void OnInvokeReceiveDelegate(object sender, MainControl.ReceiveDelegateEventArgs args)
        {
            this.Invoke(new MainControl.ReceiveDelegate(this.FormControl.Receive), new Object[] { args.Obj, args.Id });
        }

        # endregion

        #region IForm Members

        public void ReceiveObject(object obj)
        {
            if (obj is String)
            {
                String str = (String)obj;
                ReceiveString(str);
            }
        }

        #endregion
        
        #region Receive Object
        public void ReceiveString(string str)
        {
            textReceive.Text = textReceive.Text + str + '\n';
        }
        #endregion

        #region Form Events

        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Add a new line to the end of text
            string message = textSend.Text;
            textSend.Text = "";
            SendMessage(message);
        }

        private void textSend_TextChanged(object sender, EventArgs e)
        {
            // In case they activate the button by typing text, and then delete it
            if (textSend.Text.Length == 0)
            {
                buttonSend.Enabled = false;
            }
            else
            {
                buttonSend.Enabled = true;
            }

        }

        private void SendMessage(string message)
        {
            this.FormControl.messageSender.SendObject(message);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            String ipAddress = "234.7.7.4";
            ushort port = 195;
            ushort ttl = 3;
            lock (this)
            {
                if (this.FormControl.Connect(ipAddress, port, ttl, txtName.Text))
                {
                    txtConnect.Text = "Connected " + ipAddress + " port " + port;
                }
            }
        }

        #endregion

    }
}