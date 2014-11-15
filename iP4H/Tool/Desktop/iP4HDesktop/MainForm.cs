using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using LAC.Contribution.Enums;
using LAC.Functions.Forms;

using iPH.Commons.Functions;

using iPH.Commons.Tests;

namespace iPH.Tool.Desktop
{
    public partial class MainForm : iPH.Commons.Forms.InteractivePresentationForm
    {
        #region Constants

        private const string MOCA_WS_URL_CONFIG = "MocaWebServiceUrl";

        #endregion

        #region Ctor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region MenuClicks

        #region File

        private void tmiSaveAs_Click(object sender, EventArgs e)
        {
            string fileName;
            if (sfdIDD.ShowDialog() == DialogResult.OK)
            {
                fileName = sfdIDD.FileName;
            }
            else
                return;
            this.SaveDeckSet(fileName);
        }

        private void tmiSave_Click(object sender, EventArgs e)
        {
            if (this.DeckSetOpened != "")
            {
                this.SaveDeckSet(this.DeckSetOpened);
            }
            else
            {
                string fileName;
                if (sfdIDD.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfdIDD.FileName;
                }
                else
                    return;
                this.SaveDeckSet(fileName);
            }
        }

        private void tmiLoad_Click(object sender, EventArgs e)
        {
            string fileName;
            if (ofdIDD.ShowDialog() == DialogResult.OK)
            {
                fileName = ofdIDD.FileName;
                if (Path.GetExtension(fileName) != ".idd")
                    throw new ArgumentException("Input file must be a Ink Deck Document (.idd) file");

            }
            else
                return;
            this.LoadDeckSet(fileName);
        }

        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.ClosePresentation();
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Edit

        //Currently this function is not being used
        //private void tmiAppendIDD_Click(object sender, EventArgs e)
        //{
        //    if (ofdIDD.ShowDialog() == DialogResult.OK)
        //    {
        //        string iddFileName = ofdIDD.FileName;
        //        if (Path.GetExtension(iddFileName) != ".idd")
        //            throw new ArgumentException("Input file must be a Ink Deck Document (.idd) file");
        //        this.AppendDeckFromFile(iddFileName);
        //    }
        //}

        private void tmiCopy_Click(object sender, EventArgs e)
        {
            this.CopySlide();
        }

        private void tmiPaste_Click(object sender, EventArgs e)
        {
            this.PasteSlide();
        }

        private void tmiConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfigurations();
        }

        #endregion

        #region View

        private void tmiSlideInformation_Click(object sender, EventArgs e)
        {
            this.slideInfoPanel.Visible = tmiSlideInformation.Checked;
        }

        #endregion

        #region Session

        //Connect to a session
        private void tmiConnect_Click(object sender, EventArgs e)
        {
            this.Connect();
        }

        //Disconnect from the current session
        private void tmiDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        //Send the current slide with contributions to master
        private void tmiSendContributionMaster_Click(object sender, EventArgs e)
        {
            this.SendSubmissionToMaster();
        }

        //Enable the synchronization with the master
        private void tmiSynchronizeMaster_Click(object sender, EventArgs e)
        {
            this.SetSyncMaster(!this.Parameters.SyncMaster);
        }

        //Broadcast the current deck
        private void tmiBroadcastPresentation_Click(object sender, EventArgs e)
        {
            this.SendMainDeck();
        }

        //Broadcast current slide
        private void tmiBroadcastCurrentSlide_Click(object sender, EventArgs e)
        {
            this.SendCurrentSlide();
        }

        #endregion

        #region Format

        private void tmiInkColor_Click(object sender, EventArgs e)
        {
            colorDialog.FullOpen = false;
            colorDialog.Color = this.GetInkColor();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetInkColor(colorDialog.Color);
            }
        }

        private void tmiTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = this.GetTextFont();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetTextFont(fontDialog.Font);
            }
        }

        private void tmiTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.FullOpen = false;
            colorDialog.Color = this.GetTextColor();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetTextColor(colorDialog.Color);
            }
        }

        #endregion

        #region Context

        //Show Context Information
        private void tmiContextInformation_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationForm();
        }

        //Show Participants
        private void tmiShowParticipants_Click(object sender, EventArgs e)
        {
            this.ShowParticipantsForm();
        }

        //Show Context Rules
        private void tmiContextInformationRules_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationRulesForm();
        }

        #endregion
    
        #region Help

        private void tmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm("iPH - Interactive Presenter for Handhelds - XP 0.2", "Copyright © 2007", "LAC/PUC-Rio and Marcelo Malcher");
            aboutForm.ShowDialog();
            aboutForm.Dispose();
        }

        #endregion

        #endregion

        #region MainFunctionPanel
        //Connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.Connect();
        }

        //Disconnect
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        //Write Ink
        private void btnInkWrite_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.InkWriteType);
        }

        //Erase Ink
        private void btnInkErase_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.InkEraseType);
        }

        //Write Text
        private void btnTextWrite_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.TextWriteType);
        }

        //Erase Text
        private void btnTextErase_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.TextEraseType);
        }

        //Allow Sumbissions
        private void btnMessageMaster_Click(object sender, EventArgs e)
        {
            this.SetAllowParticipantsToSendContribution(!this.Parameters.AllowSubmissions);
        }

        //Sync with Master
        private void btnSyncMaster_Click(object sender, EventArgs e)
        {
            this.SetSyncMaster(!this.Parameters.SyncMaster);
        }

        //Sync Viewer
        private void btnSyncViewer_Click(object sender, EventArgs e)
        {
            this.SetSyncViewer(!this.Parameters.SyncViewer);
        }

        //SendSubmission
        private void btnMessageContribuitor_Click(object sender, EventArgs e)
        {
            this.SendSubmissionToMaster();
        }

        //Request Sync
        private void btnRequestSync_Click(object sender, EventArgs e)
        {
            this.SendRequestSync();
        }

        //ContextInformation
        private void btnContextInformation_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationForm();
        }

        #endregion

        #region CoFunctionsPanel

        private void btnNewSlidePublic_Click(object sender, EventArgs e)
        {
            this.CreateNewPublicSlide();
        }

        private void btnNewSlidePrivate_Click(object sender, EventArgs e)
        {
            this.CreateNewPrivateSlide();
        }

        private void btnPreviousSlide_Click(object sender, EventArgs e)
        {
            this.PreviousSlide(this.CurrentSlide);
        }

        private void btnNextSlide_Click(object sender, EventArgs e)
        {
            this.NextSlide(this.CurrentSlide);
        }

        #endregion

        #endregion

        #region Override methods

        #region Configuration

        protected override void ShowConfigurationForm()
        {
            ConfigurationForm configForm = new ConfigurationForm(this.Configuration);
            configForm.ShowDialog();
            configForm.Dispose();
        }

        public override string GetMocaWebServiceURL()
        {
            return ConfigurationManager.AppSettings[MOCA_WS_URL_CONFIG];
        }

        #endregion

        #region Visualizers

        protected override void VisualizeMainFunctionsPanel(bool flag) 
        {
            this.mainFunctionsPanel.Visible = flag;
        }

        protected override void VisualizeCoFunctionsPanel(bool flag) 
        {
            this.coFunctionsPanel.Visible = flag;
        }

        protected override void VisualizeMainDeckPanel(bool flag) 
        {
            scDeck.Panel1Collapsed = !flag;
        }

        protected override void VisualizeContributionsDeckPanel(bool flag) 
        {
            if (flag)
                this.tcDeck.TabPages.Insert(1, this.tpContributionDeck);
            else
                this.tcDeck.TabPages.Remove(this.tpContributionDeck);
            this.tcDeck.Refresh(); 
        }

        protected override void VisualizeSlidePanel(bool flag) 
        {
            this.scDeck.Panel2Collapsed = !flag;
        }

        #endregion

        #region Functions
       
        #region Implementation Functions

        protected override void HasClassroomPersistenceFunction(bool flag)
        {
            //Menu File
            tmiSaveAs.Visible = flag;
            tmiSave.Visible = flag;
            tmiLoad.Visible = flag;
            tmsPersistence1.Visible = flag;
            tmiClose.Visible = flag;
            tmsPersistence2.Visible = flag;
        }

        protected override void HasContributionFunction(bool flag)
        {
            this.SetMakeContributions(flag);
        }

        protected override void HasParticipantsManagerFunction(bool flag)
        {
            //Menu Context
            tmiShowParticipants.Visible = flag;
            tmiContextInformationRules.Visible = flag;
        }

        protected override void HasPresentationEditionFunction(bool flag)
        {
            //Buttons
            btnNewSlidePublic.Visible = flag;
            btnNewSlidePrivate.Visible = flag;

            //Menu Edit           
            tmiInsertNewSlide.Visible = flag;
            tmiInsertNewSlidePublic.Visible = flag;
            tmiInsertNewSlidePrivate.Visible = flag;
            tmsEdit1.Visible = flag;
            tmiCopy.Visible = flag;
            tmiPaste.Visible = flag;
            tmsEdit2.Visible = flag;
        }

        protected override void HasPresentationSendFunction(bool flag)
        {
            //Allow Submissions
            this.SetAllowParticipantsToSendContribution(flag);

            //Automatic Contributions
            this.SetAutomaticContributions(flag);

            //Sync Viewer
            this.SetSyncViewer(flag);

            //Buttons
            btnRequestSync.Visible = flag;
            btnMessageMaster.Visible = flag;
            btnSyncViewer.Visible = flag;

            //Menu Session
            //tmiPresentation.Visible = flag;
            tmiBroadcastPresentation.Visible = flag;
            tmiBroadcastCurrentSlide.Visible = flag;
            tmiRequestSync.Visible = flag;
            tmiAllowContributionFromParticipant.Visible = flag;
            tmiSyncViewer.Visible = flag;
        }

        protected override void HasSubmitModificationFunction(bool flag)
        {
            //Sync Master
            this.SetSyncMaster(flag);
            
            //Menu Session
            tmiSendContributionMaster.Visible = flag;
            tmiSynchronizeMaster.Visible = flag;
            tmsSession2.Visible = flag;

            //Buttons
            btnMessageContribuitor.Visible = flag;
            btnSyncMaster.Visible = flag;
        }

        private delegate void AvailableSubmitModificationsFunctionDelegate(bool flag);
        protected override void AvailableSubmitModificationsFunction(bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AvailableSubmitModificationsFunctionDelegate(AvailableSubmitModificationsFunction), new Object[] { flag });
                return;
            }
            //Send Submission
            btnMessageContribuitor.Enabled = flag;
            tmiSendContributionMaster.Enabled = flag;
        }

        #endregion 
 
        #region Message
        private delegate void OnNewMessageDelegate(String message);
        public override void OnNewMessage(String message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OnNewMessageDelegate(OnNewMessage), new Object[] { message });
                return;
            }
            this.lbMessages.Items.Insert(0, message);
        }

        #endregion

        #endregion

        #region Parents

        protected override Control GetMainDeckPanelParent() 
        { 
            return this.panelMainDeck; 
        }

        protected override Control GetContributionsDeckPanelParent() 
        { 
            return this.panelContributionDeck; 
        }

        protected override Control GetSlidePanelParent() 
        { 
            return this.boardPanel;
        }

        #endregion

        #region Update Info

        protected override void UpdateSlideInformationControls() 
        {
            string slideName = "";
            string slideComments = "";
            string slideType = "";
            string slideMode = "";
            string slideCount = "";
            if (this.CurrentSlide != null)
            {
                slideName = this.CurrentSlide.Title;                
                slideComments = this.CurrentSlide.Info;
                slideType = this.CurrentSlide.GetType().Name;
                slideMode = this.CurrentSlide.SendContributions() ? "Public" : "Private" ;
                slideCount = (this.CurrentSlide.Deck.Slides.IndexOf(this.CurrentSlide) + 1) + "/" + this.CurrentSlide.Deck.Slides.Count.ToString();
            }

            this.UpdateInfo(slideName, slideComments, slideType, slideMode, slideCount);

        }

        private delegate void UpdateInfoDelegate(string slideName, string slideComments, string slideType, string slideMode, string slideCount);
        private void UpdateInfo(string slideName, string slideComments, string slideType, string slideMode, string slideCount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(UpdateInfo), new Object[] { slideName, slideComments, slideType, slideMode, slideCount });
                return;
            }

            //Panel Info
            this.lblSlideName.Text = slideName;
            this.tbSlideInfo.Text = slideComments;
            //Status Bar
            this.tbPanelSlideTitleValue.Text = slideName;
            this.tbPanelSlideTypeValue.Text = slideType;
            this.tbPanelSlideModValue.Text = slideMode;
            this.tbPanelSlideCountValue.Text = slideCount;
       }

        #endregion

        #region Update Controls

        protected override void UpdateVisualControlsAndFunctions()
        {
            this.VisualizeControls();
            this.UpdateFunctions();
        }

        protected override void UpdateMakeContributionsControls(bool flag) 
        {
            //Buttons
            btnInkWrite.Enabled = flag;
            btnInkErase.Enabled = flag;
            btnTextWrite.Enabled = flag;
            btnTextErase.Enabled = flag;
            //Menu
            tmiFormat.Visible = flag;
            tmiInk.Visible = flag;
            tmiInkColor.Visible = flag;
            tmiText.Visible = flag;
            tmiTextColor.Visible = flag;
            tmiTextFont.Visible = flag;
        }

        protected override void UpdateAutomaticContributionsControls(bool flag) 
        { 
            //TODO?
        }

        protected override void UpdateConnectionControls(bool flag) 
        {
            //Buttons
            btnConnect.Enabled = !flag;
            btnDisconnect.Enabled = flag;
            //Menu
            tmiConnect.Enabled = !flag;
            tmiDisconnect.Enabled = flag;
            tmiSearchForActiveSessions.Enabled = !flag;
            //Status
            tblblStatusConnection.Text = flag ? "Connected at " + this.Session.MulticastIp + ":" + this.Session.Port.ToString() : "Disconnected" ; 
        }

        protected override void UpdateCopyAndPasteSlideControls(bool flag) 
        {
            tmiCopy.Enabled = !flag;
            tmiPaste.Enabled = flag;
        }

        protected override void UpdateAllowParticipantsToSendContributionControls(bool flag) 
        { 
            tmiAllowContributionFromParticipant.Checked = flag;
            if (flag)
                btnMessageMaster.Image = iPH.Tool.Desktop.Properties.Resources.imReceiveFromContribuitors;                
            else
                btnMessageMaster.Image = iPH.Tool.Desktop.Properties.Resources.imReceiveFromContribuitorsStop;                              
        }

        protected override void UpdateSyncMasterControls(bool flag) 
        {
            tmiSynchronizeMaster.Checked = flag;
            if (flag)
                btnSyncMaster.Image = iPH.Tool.Desktop.Properties.Resources.imSynchronizedMaster;
            else
                btnSyncMaster.Image = iPH.Tool.Desktop.Properties.Resources.imNotSynchronizedMaster;
        }

        protected override void UpdateSyncMasterAttentionControls()
        {
            btnSyncMaster.Image = iPH.Tool.Desktop.Properties.Resources.imSynchronizedMasterAttention;
        }

        protected override void UpdateSyncViewerControls(bool flag) 
        {
            tmiSyncViewer.Checked = flag;
            if (flag)
                btnSyncViewer.Image = iPH.Tool.Desktop.Properties.Resources.imSynchronizedViewer;
            else
                btnSyncViewer.Image = iPH.Tool.Desktop.Properties.Resources.imNotSynchronizedViewer;
        }

        private delegate void UpdatePersistenceControlsDelegate(bool flag);
        protected override void UpdatePersistenceControls(bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdatePersistenceControlsDelegate(UpdatePersistenceControls), new Object[] { flag });
                return;
            }
            tmiClose.Enabled = flag;
            tmiSave.Enabled = flag;
            tmiSaveAs.Enabled = flag;
            tmiNextSlide.Enabled = flag;
            tmiPreviousSlide.Enabled = flag;
            btnNextSlide.Enabled = flag;
            btnPreviousSlide.Enabled = flag;
        }

        #endregion

        private void tmiSearchForActiveSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SearchActiveSessions();            
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

