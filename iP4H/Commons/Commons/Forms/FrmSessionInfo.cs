using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iP4H.Commons.NetworkInfo;
using iP4H.Commons.Session;
using iP4H.Commons.Participant;
using iP4H.Commons.Participant.Role;

namespace iP4H.Commons.Forms
{
    public partial class FrmSessionInfo : Form
    {
        
        #region Ctor

        public FrmSessionInfo()
        {
            InitializeComponent();
            InitializeMacAddress();
        }

        #endregion

        #region Initializers

        public void InitializeMacAddress()
        {
            this.txtMacAddress.Text = ParticipantInfo.Instance.MacAddress;
        }

        #endregion

        #region Button Clicks

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Validate Form
            if (!this.ValidateInfo())
                return;
            //Session
            SessionInfo.Instance.MulticastIp = cbMulticastIP.Text;
            SessionInfo.Instance.Port = (ushort)nupPort.Value;
            SessionInfo.Instance.Key = new SessionKey(txtKey.Text);
            //Participant
            ParticipantInfo.Instance.MacAddress = txtMacAddress.Text;
            ParticipantInfo.Instance.NickName = txtName.Text;
            if (rdbMaster.Checked)
                ParticipantInfo.Instance.Role = Master.Instance;
            else if (rdbContribuitor.Checked)
                ParticipantInfo.Instance.Role = Contribuitor.Instance;
            else
                ParticipantInfo.Instance.Role = Viewer.Instance;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Session
            SessionInfo.Instance.Clear();
            //Participant
            ParticipantInfo.Instance.Clear();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Validate

        private bool ValidateInfo()
        {
            //Multicast IP Address
            try
            {
                System.Net.IPAddress.Parse(this.cbMulticastIP.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("The Multicast IP address is incorrect", "Session");
                Console.WriteLine(ex.Message);
                this.tpSession.Focus();
                this.cbMulticastIP.Focus();
                return false;
            }
            //Port
            if (this.nupPort.Value <= 0)
            {
                MessageBox.Show("The Port is incorrect", "Session");
                this.tpSession.Focus();
                this.nupPort.Focus();
                return false;
            }
            //Name
            if (this.txtName.Text.Length <= 0)
            {
                MessageBox.Show("Please type your name", "Session");
                this.tpParticipant.Focus();
                this.txtName.Focus();
                return false;
            }
            return true;              
        }


        #endregion

    }
}