using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPH.Commons.Session;
using iPH.Commons.User;
using iPH.Commons.User.Role;

namespace iPH.Commons.Forms
{
    public partial class SessionForm : Form
    {
        #region Members

        private SessionInfo mySession;
        private Participant myParticipant;
        private bool registerSession = false ;
        
        #endregion

        #region Constructor

        public SessionForm(SessionInfo session, Participant participant)
        {
            InitializeComponent();
            this.mySession = session;
            this.myParticipant = participant;
            this.txtMacAddress.Text = this.myParticipant.MacAddress;
        }

        public SessionForm(SessionInfo session, Participant participant, String IP, int port, String password)
            :this(session, participant)
        {
            cbMulticastIP.Text = IP;
            nupPort.Value = port;
            this.txtKey.Text = password;

            //
            this.cbMulticastIP.Enabled = false;
            this.nupPort.Enabled = false;
            this.txtKey.Enabled = false;
            this.rdbMaster.Enabled = false;
            this.rdbContribuitor.Checked = true;
        }

        #endregion

        #region Button Clicks

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Validate Form
            if (!this.ValidateInfo())
                return;
            //Session
            //Multicast IP
            this.mySession.MulticastIp = cbMulticastIP.Text;
            //Port
            this.mySession.Port = (ushort)nupPort.Value;
            //Key
            this.mySession.Key = new SessionKey(txtKey.Text);
            //Participant 
            //MacAddress
            this.myParticipant.MacAddress = txtMacAddress.Text;
            //Name
            this.myParticipant.NickName = txtName.Text;
            //Role
            if (rdbMaster.Checked)
            {
                this.myParticipant.Role = Master.Instance;
                if (MessageBox.Show("Do you want to register this session in the service?",
                    "Register Session", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    this.registerSession = true;
            }
            else if (rdbContribuitor.Checked)
                this.myParticipant.Role = Contribuitor.Instance;
            else
                this.myParticipant.Role = Viewer.Instance;
            //Dialog Result
            this.DialogResult = DialogResult.OK;
            //Closing
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Dialog Result
            this.DialogResult = DialogResult.Cancel;
            //Closing
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

        public bool RegisterSession
        {
            get
            {
                return this.registerSession;
            }
        }

    }
}