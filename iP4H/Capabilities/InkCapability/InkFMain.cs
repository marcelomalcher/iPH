using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CF.MSR.LST.ConferenceXP;
using CF.MSR.LST.Net.Rtp;
using LAC.Ink;
using LAC.Ink.Events.Arguments;
using iP4H.Commons.Controls;
using iP4H.Commons.Intefaces;
using iP4H.Commons.NetworkInfo;

namespace CCXP.Capabilities.CP.Ink
{
    public partial class InkFMain : CapabilityForm, IForm
    {
        #region Attributes
        private MainControl formControl;
        private LAC.Ink.Ink ink;
        #endregion

        #region Constructor & Initializers
        public InkFMain()
        {
            InitializeComponent();           
            this.formControl = new MainControl(this);
            
            InitializeForm();
            InitializeInk();
        }

        public void InitializeForm()
        {

            this.SuspendLayout();
            this.FormControl.InvokeReceiveDelegate += new MainControl.ReceiveDelegateEventHandler(this.OnInvokeReceiveDelegate);
            this.ResumeLayout();

        }

        private void InitializeInk()
        {
            //ink = new LAC.Ink.Ink(pnlInkLeft);
            ink = new LAC.Ink.Ink(pnlPrincipal, "C://Marcelo//PUC//Computação Móvel//Monografia//AN//app//Slides//Main", "Slide1.jpg");
            ink.Enabled = true;
            ink.Optimize = false;
            ink.CurrentWidth = 2;
            ink.CurrentColor = Color.Blue;
            ink.StrechtImage = true;
            ink.BoardColor = Color.Coral;
            ink.NewStrokeEvent += new NewStrokeEventHandler(NewStroke);
            ink.StrokesRemovedEvent += new StrokeRemovedEventHandler(StrokesRemoved);
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

        #region Properties
        public MainControl FormControl
        {
            get { return this.formControl; }
        }
        #endregion

        #region Invoke
        public void OnInvokeReceiveDelegate(object sender, MainControl.ReceiveDelegateEventArgs args)
        {
            this.Invoke(new MainControl.ReceiveDelegate(this.FormControl.Receive), new Object[] { args.Obj, args.Id });
        }
        #endregion

        public void ReceiveStroke(Stroke stroke)
        {
            stroke.Ink = ink;
            ink.AddStroke(stroke);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            String ipAddress = "234.9.9.4";
            ushort port = 195;
            ushort ttl = 3;
            lock (this)
            {
                if (this.FormControl.Connect(ipAddress, port, ttl, txtNick.Text))
                {
                    sbConnection.Text = "Connected";
                    ink.Enabled = true;
                }
            }
        }

        public void NewStroke(object sender, NewStrokeArgs e)
        {
            this.FormControl.messageSender.SendObject(e.Stroke);
        }

        public void StrokesRemoved(object sender, StrokeRemovedArgs e)
        {
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            this.FormControl.messageSender.SendObject("ping!");
        }


        #region IForm Members

        public void ReceiveObject(object obj)
        {
            if (obj is LAC.Ink.Stroke)
            {
                ReceiveStroke((Stroke)obj);
            }
        }

        #endregion

        private void btnChangeControl_Click(object sender, EventArgs e)
        {
            if (this.ink.Visible)
                this.ink.Visible = false;
            else
                this.ink.Visible = true;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            this.ink.BoardColor = Color.Teal;
        }

        private void btnMacAddress_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PhysicalAddressInfo.GetMacAddress());
        }
    }
}