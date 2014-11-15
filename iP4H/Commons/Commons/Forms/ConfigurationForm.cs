using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPH.Commons.Configuration;

namespace iPH.Commons.Forms
{
    public partial class ConfigurationForm : Form
    {
        #region Members
        private InteractiveConfiguration myConfiguration;

        private Color publicSlideColor;
        private Color privateSlideColor;
        #endregion

        #region Ctor
       
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        public ConfigurationForm(InteractiveConfiguration configuration)
        {
            InitializeComponent();

            this.myConfiguration = configuration;

            //MoCA/WS
            this.tbMocaWSUrl.Text = this.myConfiguration.MocaWebServiceURL;

            this.chkUseContextRules.Checked = this.myConfiguration.UsesContextInformation;

            this.nudInterval.Value = this.myConfiguration.ContextTimerInterval;

            this.nudRequestTimeout.Value = this.myConfiguration.MocaWSRequestTimeOut;

            //Session
            this.tbSessionService.Text = this.myConfiguration.SessionServiceURL;

            this.cbSessionSearch.Checked = this.myConfiguration.SearchActiveSessions;

            this.nudSessionInterval.Value = this.myConfiguration.SessionTimeInterval;

            //Slide Colors
            this.publicSlideColor = this.myConfiguration.PublicSlideColor;
            this.privateSlideColor = this.myConfiguration.PrivateSlideColor;

            this.btnPublicSlideColor.BackColor = this.publicSlideColor;
            this.btnPrivateSlideColor.BackColor = this.privateSlideColor;
        }

        #endregion

        #region Button Clicks

        private void btnOk_Click(object sender, EventArgs e)
        {
            //MoCA/WS
            this.myConfiguration.MocaWebServiceURL = tbMocaWSUrl.Text;
            this.myConfiguration.UsesContextInformation = chkUseContextRules.Checked;
            this.myConfiguration.ContextTimerInterval = (int)nudInterval.Value;
            this.myConfiguration.MocaWSRequestTimeOut = (int)nudRequestTimeout.Value;
            //Session Service
            this.myConfiguration.SessionTimeInterval = (int)nudSessionInterval.Value;
            this.myConfiguration.SearchActiveSessions = cbSessionSearch.Checked;
            this.myConfiguration.SessionServiceURL = tbSessionService.Text;
            //Slide Colors
            this.myConfiguration.PublicSlideColor = this.publicSlideColor;
            this.myConfiguration.PrivateSlideColor = this.privateSlideColor;
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

        private void btnPublicSlideColor_Click(object sender, EventArgs e)
        {
            this.publicSlideColor = this.GetColor(this.publicSlideColor);            
            this.btnPublicSlideColor.BackColor = this.publicSlideColor;
        }

        private void btnPrivateSlideColor_Click(object sender, EventArgs e)
        {
            this.privateSlideColor = this.GetColor(this.privateSlideColor);
            this.btnPrivateSlideColor.BackColor = this.privateSlideColor;
        }

        #endregion

        #region Virtual Method

        public virtual Color GetColor(Color myCurrentColor)
        {
            return myCurrentColor;
        }

        #endregion
    }
}