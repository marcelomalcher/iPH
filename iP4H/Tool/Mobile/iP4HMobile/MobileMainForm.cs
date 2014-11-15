using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using OpenNETCF.Configuration;
using OpenNETCF.Windows.Forms;

using LAC.Contribution.Enums;
using LAC.Functions.Forms;
using LAC.Functions.Controls;

using iPH.Commons.Functions;

using iPH.Commons.Tests;


namespace iPH.Tool.Mobile
{
    public partial class MobileMainForm : iPH.Commons.Forms.InteractivePresentationForm
    {
        #region Constants

        private const string MOCA_WS_URL_CONFIG = "MocaWebServiceUrl";
        private const string SESSION_SERVICE_CONFIG = "SessionServiceUrl";

        private const int NO_ZOOM = 0;
        private const int MAX_ZOOM = 6;
        private const double REL_ZOOM = 0.1;
        
        #endregion

        #region Members

        private int myZoomValue = NO_ZOOM; 

        #endregion

        #region Ctor

        public MobileMainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Form Controls events

        private void MobileMainForm_Load(object sender, EventArgs e)
        {
            this.DefaultZoom();
        }

        private void baseBoardPanel_Resize(object sender, EventArgs e)
        {
            this.DefaultZoom();
        }

        #endregion

        #region MenuClicks

        #region File

        private void miLoad_Click(object sender, EventArgs e)
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

        private void miSave_Click(object sender, EventArgs e)
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

        private void miSaveAs_Click(object sender, EventArgs e)
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

        private void miClose_Click(object sender, EventArgs e)
        {
            this.ClosePresentation();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Edit

        //This function is currently not being used
        //private void miAppendIDD_Click(object sender, EventArgs e)
        //{
        //    if (ofdIDD.ShowDialog() == DialogResult.OK)
        //    {
        //        string iddFileName = ofdIDD.FileName;
        //        if (Path.GetExtension(iddFileName) != ".idd")
        //            throw new ArgumentException("Input file must be a Ink Deck Document (.idd) file");
        //        this.AppendDeckFromFile(iddFileName);
        //    }
        //}

        private void miCopy_Click(object sender, EventArgs e)
        {
            this.CopySlide();
        }

        private void miPaste_Click(object sender, EventArgs e)
        {
            this.PasteSlide();
        }

        private void miConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfigurations();
        }

        #endregion

        #region View

        private void miSlideInformation_Click(object sender, EventArgs e)
        {
            if (this.CurrentSlide != null)
            {
                SlideInformationForm.Show(this.CurrentSlide.Title, this.CurrentSlide.Info);
            }
        }

        private void miSlideArea_Click(object sender, EventArgs e)
        {
            pnlSlide.BringToFront();
            //menu buttons
            miSlideArea.Checked = true;
            miDeckArea.Checked = false;
        }

        private void miDeckArea_Click(object sender, EventArgs e)
        {
            pnlDeck.BringToFront();
            //menu buttons
            miSlideArea.Checked = false;
            miDeckArea.Checked = true;
        }

        #endregion

        #region Session

        private void miConnect_Click(object sender, EventArgs e)
        {
            this.Connect();
        }

        private void miDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        private void miSendContribution_Click(object sender, EventArgs e)
        {
            this.SendSubmissionToMaster();
        }

        private void miSyncMaster_Click(object sender, EventArgs e)
        {
            this.SetSyncMaster(!this.Parameters.SyncMaster);
        }

        private void miBroadcastPresentation_Click(object sender, EventArgs e)
        {
            this.SendMainDeck();
        }

        private void miBroadcastCurrentSlide_Click(object sender, EventArgs e)
        {
            this.SendCurrentSlide();
        }

        private void miRequestSync_Click(object sender, EventArgs e)
        {
            this.SendRequestSync();
        }

        private void miAllowContributions_Click(object sender, EventArgs e)
        {
            this.SetAllowParticipantsToSendContribution(!this.Parameters.AllowSubmissions);
        }

        private void miSyncViewer_Click(object sender, EventArgs e)
        {
            this.SetSyncViewer(!this.Parameters.SyncViewer);
        }
        #endregion

        #region Format

        private void miInkColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = false;
            colorDialog.Color = this.GetInkColor();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetInkColor(colorDialog.Color);
            }
            colorDialog.Dispose();
        }

        private void miTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = false;
            colorDialog.Color = this.GetTextColor();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SetTextColor(colorDialog.Color);
            }
            colorDialog.Dispose();
        }

        private void miTextFont_Click(object sender, EventArgs e)
        {
            FormatTextFont formatTextFont = new FormatTextFont(this.GetTextFont());
            if (formatTextFont.ShowDialog() == DialogResult.OK)
            {
                this.SetTextFont(formatTextFont.Font);
            }
            formatTextFont.Dispose();
        }

        #endregion

        #region Context

        private void miContextInformation_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationForm();
        }

        private void miShowParticipants_Click(object sender, EventArgs e)
        {
            this.ShowParticipantsForm();
        }

        private void miContextInformationRules_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationRulesForm();
        }
 
        #endregion

        #region Help

        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm("iPH - Interactive Presenter for Handhelds 2007 - Mobile 0.1", "Copyright © 2007", "LAC/PUC-Rio and Marcelo Malcher");
            aboutForm.ShowDialog();
            aboutForm.Dispose();
        }

        #endregion

        #endregion

        #region MainFunctionPanel

        private void btnInkWrite_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.InkWriteType);
        }

        private void btnInkErase_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.InkEraseType);
        }

        private void btnTextWrite_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.TextWriteType);
        }

        private void btnTextErase_Click(object sender, EventArgs e)
        {
            this.SetContributionAction(ActionType.TextEraseType);
        }

        private void btnContextInfo_Click(object sender, EventArgs e)
        {
            this.ShowContextInformationForm();
        }

        #endregion

        #region CoFunctionsPanel

        private void btnDefaultSize_Click(object sender, EventArgs e)
        {
            this.DefaultZoom();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.IncreaseZoom();
        }
        
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            this.DecreaseZoom();
        }

        private void btnPreviousSlide_Click(object sender, EventArgs e)
        {
            this.PreviousSlide(this.CurrentSlide);
        }

        private void btnDeckView_Click(object sender, EventArgs e)
        {
            this.pnlDeck.BringToFront();
        }

        private void btnNextSlide_Click(object sender, EventArgs e)
        {
            this.NextSlide(this.CurrentSlide);
        }

        #endregion

        #region CoFunctionsDeckPanel

        private void btnNewPublicSlide_Click(object sender, EventArgs e)
        {
            this.CreateNewPublicSlide();
        }

        private void btnNewPrivateSlide_Click(object sender, EventArgs e)
        {
            this.CreateNewPrivateSlide();
        }

        private void btnSlideView_Click(object sender, EventArgs e)
        {
            this.pnlSlide.BringToFront();
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
            return ConfigurationSettings.AppSettings[MOCA_WS_URL_CONFIG];
        }

        public override string GetSessionServiceURL()
        {
            return ConfigurationSettings.AppSettings[SESSION_SERVICE_CONFIG];
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
            pnlDeck.Visible = flag;
            btnDeckView.Visible = flag;
        }

        protected override void VisualizeContributionsDeckPanel(bool flag)
        {
            if (flag)
            {
                this.tcDeck.TabPages.Insert(1, this.tpContributionDeck);
                this.tpContributionDeck.Refresh();
            }
            else
            {
                if (this.tcDeck.TabPages.Count > 1)
                    this.tcDeck.TabPages.RemoveAt(1);
            }
            this.tcDeck.Refresh();
        }

        protected override void VisualizeSlidePanel(bool flag)
        {
            pnlSlide.Visible = flag;
            btnSlideView.Visible = flag;
        }
        #endregion

        #region Functions
        
        #region Implementation Functions

        public void ClearMenuControls()
        {
            //Clearing the menu items that depend on the role of the participant
            miFile.MenuItems.Clear();
            miEdit.MenuItems.Clear();
            miSession.MenuItems.Clear();
            miContext.MenuItems.Clear();
        }

        protected override void HasClassroomPersistenceFunction(bool flag)
        {
            //Menu File
            if (flag)
            {
                miFile.MenuItems.Add(miOpen);
                miFile.MenuItems.Add(miSave);
                miFile.MenuItems.Add(miSaveAs);
                miFile.MenuItems.Add(msFile1);
                miFile.MenuItems.Add(miClose);
                miFile.MenuItems.Add(msFile2);
            }
            miFile.MenuItems.Add(miExit);
        }

        protected override void HasContributionFunction(bool flag)
        {
            this.SetMakeContributions(flag);
        }

        protected override void HasParticipantsManagerFunction(bool flag)
        {
            //Menu Context
            miContext.MenuItems.Add(miContextInformation);
            if (flag)
            {
                miContext.MenuItems.Add(miShowParticipants);
                miContext.MenuItems.Add(miContextInformationRules);
            }
        }

        protected override void HasPresentationEditionFunction(bool flag)
        {
            //Buttons
            btnNewPublicSlide.Visible = flag;
            btnNewPrivateSlide.Visible = flag;
            //Menu Edit          
            if (flag)
            {
                miEdit.MenuItems.Add(miInsertNewSlide);
                miEdit.MenuItems.Add(msEdit1);
                miEdit.MenuItems.Add(miCopy);
                miEdit.MenuItems.Add(miPaste);
                miEdit.MenuItems.Add(msEdit2);
            }
            miEdit.MenuItems.Add(miConfiguration);
        }

        protected override void HasPresentationSendFunction(bool flag)
        {
            miSession.MenuItems.Add(miConnect);
            miSession.MenuItems.Add(miDisconnect);
            miSession.MenuItems.Add(miSearchSessions);
            if (flag)
            {
                miSession.MenuItems.Add(msSession1);
                miSession.MenuItems.Add(miBroadcastPresentation);
                miSession.MenuItems.Add(miBroadcastCurrentSlide);
                miSession.MenuItems.Add(miRequestSync);
                miSession.MenuItems.Add(miAllowContributions);
                miSession.MenuItems.Add(miSyncViewer);
            }

            //Allow Submissions
            this.SetAllowParticipantsToSendContribution(flag);
            //Automatic Contributions
            this.SetAutomaticContributions(flag);
            //Sync Viewer
            this.SetSyncViewer(flag);
        }

        protected override void HasSubmitModificationFunction(bool flag)
        {
            if (flag)
            {
                miSession.MenuItems.Add(msSession2);
                miSession.MenuItems.Add(miSendContribution);
                miSession.MenuItems.Add(miSyncMaster);
            }
            //Sync Master
            this.SetSyncMaster(flag);
        }

        private delegate void AvailableSubmitModificationsFunctionDelegate(bool flag);
        protected override void AvailableSubmitModificationsFunction(bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AvailableSubmitModificationsFunctionDelegate(AvailableSubmitModificationsFunction), new Object[] { flag });
                return;
            }
            miSendContribution.Enabled = flag;
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
        }
        
        #endregion

        #region Update Controls

        protected override void UpdateVisualControlsAndFunctions()
        {
            this.VisualizeControls();
            this.ClearMenuControls();
            this.UpdateFunctions();
        }

        protected override void UpdateMakeContributionsControls(bool flag)
        {
            //Buttons
            btnInkWrite.Enabled = flag;
            btnInkErase.Enabled = flag;
            btnTextWrite.Enabled = flag;
            btnTextErase.Enabled = flag;
            //Menu Format
            miFormat.Enabled = flag;
            miInk.Enabled = flag;
            miInkColor.Enabled = flag;
            miText.Enabled = flag;
            miTextColor.Enabled = flag;
            miTextFont.Enabled = flag;
        }

        protected override void UpdateAutomaticContributionsControls(bool flag)
        {
            //TODO?
        }

        private delegate void UpdatePersistenceControlsDelegate(bool flag);
        protected override void UpdatePersistenceControls(bool flag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdatePersistenceControlsDelegate(UpdatePersistenceControls), new Object[] { flag });
                return;
            }
            //Menu File
            miClose.Enabled = flag;
            miSave.Enabled = flag;
            miSaveAs.Enabled = flag;
            miNextSlide.Enabled = flag;
            miPreviousSlide.Enabled = flag;
            btnNextSlide.Enabled = flag;
            btnPreviousSlide.Enabled = flag;
        }

        protected override void UpdateConnectionControls(bool flag)
        {
            //Menu Session
            miConnect.Enabled = !flag;
            miDisconnect.Enabled = flag;
            miSearchSessions.Enabled = !flag;
        }

        protected override void UpdateCopyAndPasteSlideControls(bool flag)
        {
            //Menu Edit
            miCopy.Enabled = !flag;
            miPaste.Enabled = flag;
        }

        protected override void UpdateAllowParticipantsToSendContributionControls(bool flag)
        {
            //Menu Session
            miAllowContributions.Checked = flag;
        }

        protected override void UpdateSyncMasterControls(bool flag)
        {
            //Menu Session
            miSyncMaster.Checked = flag;
        }

        protected override void UpdateSyncMasterAttentionControls()
        {            
        }

        protected override void UpdateSyncViewerControls(bool flag)
        {
            //Menu Session
            miSyncViewer.Checked = flag;            
        }
        #endregion

        #region Messages

        public override void OnNewMessage(String message) 
        {
            //do something
        }

        #endregion

        #endregion

        #region Zoom

        private void DefaultZoom()
        {            
            this.myZoomValue = NO_ZOOM;
            this.ApplyZoom();
        }

        private void IncreaseZoom()
        {
            if (this.myZoomValue < MAX_ZOOM)
            {
                this.myZoomValue += 1;
                this.ApplyZoom();
            }
        }

        private void DecreaseZoom()
        {
            if (this.myZoomValue > NO_ZOOM)
            {
                this.myZoomValue -= 1;
                this.ApplyZoom();
            }
        }

        private void ApplyZoom()
        {
            double myWidth = (double)this.baseBoardPanel.Width + ((double)this.myZoomValue * REL_ZOOM * (double)this.baseBoardPanel.Width);
            double myHeight = (double)this.baseBoardPanel.Height + ((double)this.myZoomValue * REL_ZOOM * (double)this.baseBoardPanel.Height);
            //Setting new Size
            this.boardPanel.Width = (int)myWidth;
            this.boardPanel.Height = (int)myHeight;
        }

        #endregion   

        private void miMenu_Click(object sender, EventArgs e)
        {

        }

        private void miFullScreen_Click(object sender, EventArgs e)
        {
            miFullScreen.Checked = !miFullScreen.Checked;
            
            mainFunctionsPanel.Visible = !miFullScreen.Checked;
            coFunctionsPanel.Visible = !miFullScreen.Checked;

            if (miFullScreen.Checked)
            {
                this.boardPanel.Dock = DockStyle.Fill;
            }
            else
            {
                this.boardPanel.Dock = DockStyle.None;
                this.DefaultZoom();
            }
        }

        private void miSearchSessions_Click(object sender, EventArgs e)
        {
            this.SearchActiveSessions();                        
        }
    }
}

