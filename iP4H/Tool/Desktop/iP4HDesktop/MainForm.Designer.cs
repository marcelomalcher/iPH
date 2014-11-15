namespace iPH.Tool.Desktop
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsPersistence1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsPersistence2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInsertNewSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInsertNewSlidePublic = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInsertNewSlidePrivate = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsEdit1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsEdit2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSlideInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsView1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiNextSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPreviousSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPresentation = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSearchForActiveSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsSession1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSendContributionMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSynchronizeMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsSession2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiBroadcastPresentation = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiBroadcastCurrentSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRequestSync = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAllowContributionFromParticipant = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSyncViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInk = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInkColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiText = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTextFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiContext = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiContextInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiShowParticipants = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiContextInformationRules = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tblblStatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideTitleValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideTypeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideModValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainFunctionsPanel = new System.Windows.Forms.Panel();
            this.btnSyncViewer = new System.Windows.Forms.Button();
            this.btnContextInformation = new System.Windows.Forms.Button();
            this.btnTextErase = new System.Windows.Forms.Button();
            this.btnTextWrite = new System.Windows.Forms.Button();
            this.btnInkErase = new System.Windows.Forms.Button();
            this.btnInkWrite = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnMessageContribuitor = new System.Windows.Forms.Button();
            this.btnMessageMaster = new System.Windows.Forms.Button();
            this.btnSyncMaster = new System.Windows.Forms.Button();
            this.btnRequestSync = new System.Windows.Forms.Button();
            this.coFunctionsPanel = new System.Windows.Forms.Panel();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.btnNewSlidePrivate = new System.Windows.Forms.Button();
            this.btnNewSlidePublic = new System.Windows.Forms.Button();
            this.btnNextSlide = new System.Windows.Forms.Button();
            this.btnPreviousSlide = new System.Windows.Forms.Button();
            this.scDeck = new System.Windows.Forms.SplitContainer();
            this.tcDeck = new System.Windows.Forms.TabControl();
            this.tpMainDeck = new System.Windows.Forms.TabPage();
            this.panelMainDeck = new System.Windows.Forms.Panel();
            this.tpContributionDeck = new System.Windows.Forms.TabPage();
            this.panelContributionDeck = new System.Windows.Forms.Panel();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.slideInfoPanel = new System.Windows.Forms.Panel();
            this.lblSlideName = new System.Windows.Forms.Label();
            this.tbSlideInfo = new System.Windows.Forms.TextBox();
            this.ofdIDD = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.desktopMainFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sfdIDD = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.mainFunctionsPanel.SuspendLayout();
            this.coFunctionsPanel.SuspendLayout();
            this.scDeck.Panel1.SuspendLayout();
            this.scDeck.Panel2.SuspendLayout();
            this.scDeck.SuspendLayout();
            this.tcDeck.SuspendLayout();
            this.tpMainDeck.SuspendLayout();
            this.tpContributionDeck.SuspendLayout();
            this.slideInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiEdit,
            this.tmiView,
            this.tmiPresentation,
            this.tmiFormat,
            this.tmiContext,
            this.tmiHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(817, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiLoad,
            this.tmiSave,
            this.tmiSaveAs,
            this.tmsPersistence1,
            this.tmiClose,
            this.tmsPersistence2,
            this.tmiExit});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.Size = new System.Drawing.Size(37, 20);
            this.tmiFile.Text = "File";
            // 
            // tmiLoad
            // 
            this.tmiLoad.Name = "tmiLoad";
            this.tmiLoad.Size = new System.Drawing.Size(172, 22);
            this.tmiLoad.Text = "Load...";
            this.tmiLoad.Click += new System.EventHandler(this.tmiLoad_Click);
            // 
            // tmiSave
            // 
            this.tmiSave.Name = "tmiSave";
            this.tmiSave.Size = new System.Drawing.Size(172, 22);
            this.tmiSave.Text = "Save";
            this.tmiSave.Click += new System.EventHandler(this.tmiSave_Click);
            // 
            // tmiSaveAs
            // 
            this.tmiSaveAs.Name = "tmiSaveAs";
            this.tmiSaveAs.Size = new System.Drawing.Size(172, 22);
            this.tmiSaveAs.Text = "Save As...";
            this.tmiSaveAs.Click += new System.EventHandler(this.tmiSaveAs_Click);
            // 
            // tmsPersistence1
            // 
            this.tmsPersistence1.Name = "tmsPersistence1";
            this.tmsPersistence1.Size = new System.Drawing.Size(169, 6);
            // 
            // tmiClose
            // 
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(172, 22);
            this.tmiClose.Text = "Close Presentation";
            this.tmiClose.Click += new System.EventHandler(this.tmiClose_Click);
            // 
            // tmsPersistence2
            // 
            this.tmsPersistence2.Name = "tmsPersistence2";
            this.tmsPersistence2.Size = new System.Drawing.Size(169, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(172, 22);
            this.tmiExit.Text = "Exit";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiEdit
            // 
            this.tmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiInsertNewSlide,
            this.tmsEdit1,
            this.tmiCopy,
            this.tmiPaste,
            this.tmsEdit2,
            this.tmiConfiguration});
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tmiEdit.Text = "Edit";
            // 
            // tmiInsertNewSlide
            // 
            this.tmiInsertNewSlide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiInsertNewSlidePublic,
            this.tmiInsertNewSlidePrivate});
            this.tmiInsertNewSlide.Name = "tmiInsertNewSlide";
            this.tmiInsertNewSlide.Size = new System.Drawing.Size(155, 22);
            this.tmiInsertNewSlide.Text = "Insert new slide";
            // 
            // tmiInsertNewSlidePublic
            // 
            this.tmiInsertNewSlidePublic.Name = "tmiInsertNewSlidePublic";
            this.tmiInsertNewSlidePublic.Size = new System.Drawing.Size(110, 22);
            this.tmiInsertNewSlidePublic.Text = "Public";
            this.tmiInsertNewSlidePublic.Click += new System.EventHandler(this.btnNewSlidePublic_Click);
            // 
            // tmiInsertNewSlidePrivate
            // 
            this.tmiInsertNewSlidePrivate.Name = "tmiInsertNewSlidePrivate";
            this.tmiInsertNewSlidePrivate.Size = new System.Drawing.Size(110, 22);
            this.tmiInsertNewSlidePrivate.Text = "Private";
            this.tmiInsertNewSlidePrivate.Click += new System.EventHandler(this.btnNewSlidePrivate_Click);
            // 
            // tmsEdit1
            // 
            this.tmsEdit1.Name = "tmsEdit1";
            this.tmsEdit1.Size = new System.Drawing.Size(152, 6);
            // 
            // tmiCopy
            // 
            this.tmiCopy.Name = "tmiCopy";
            this.tmiCopy.Size = new System.Drawing.Size(155, 22);
            this.tmiCopy.Text = "Copy";
            this.tmiCopy.Click += new System.EventHandler(this.tmiCopy_Click);
            // 
            // tmiPaste
            // 
            this.tmiPaste.Enabled = false;
            this.tmiPaste.Name = "tmiPaste";
            this.tmiPaste.Size = new System.Drawing.Size(155, 22);
            this.tmiPaste.Text = "Paste";
            this.tmiPaste.Click += new System.EventHandler(this.tmiPaste_Click);
            // 
            // tmsEdit2
            // 
            this.tmsEdit2.Name = "tmsEdit2";
            this.tmsEdit2.Size = new System.Drawing.Size(152, 6);
            // 
            // tmiConfiguration
            // 
            this.tmiConfiguration.Image = global::iPH.Tool.Desktop.Properties.Resources.imConfiguration;
            this.tmiConfiguration.Name = "tmiConfiguration";
            this.tmiConfiguration.Size = new System.Drawing.Size(155, 22);
            this.tmiConfiguration.Text = "Configuration";
            this.tmiConfiguration.Click += new System.EventHandler(this.tmiConfiguration_Click);
            // 
            // tmiView
            // 
            this.tmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiSlideInformation,
            this.tmsView1,
            this.tmiNextSlide,
            this.tmiPreviousSlide});
            this.tmiView.Name = "tmiView";
            this.tmiView.Size = new System.Drawing.Size(44, 20);
            this.tmiView.Text = "View";
            // 
            // tmiSlideInformation
            // 
            this.tmiSlideInformation.CheckOnClick = true;
            this.tmiSlideInformation.Name = "tmiSlideInformation";
            this.tmiSlideInformation.Size = new System.Drawing.Size(173, 22);
            this.tmiSlideInformation.Text = "Slide\'s information";
            this.tmiSlideInformation.Click += new System.EventHandler(this.tmiSlideInformation_Click);
            // 
            // tmsView1
            // 
            this.tmsView1.Name = "tmsView1";
            this.tmsView1.Size = new System.Drawing.Size(170, 6);
            // 
            // tmiNextSlide
            // 
            this.tmiNextSlide.Enabled = false;
            this.tmiNextSlide.Name = "tmiNextSlide";
            this.tmiNextSlide.Size = new System.Drawing.Size(173, 22);
            this.tmiNextSlide.Text = "Next slide";
            this.tmiNextSlide.Click += new System.EventHandler(this.btnNextSlide_Click);
            // 
            // tmiPreviousSlide
            // 
            this.tmiPreviousSlide.Enabled = false;
            this.tmiPreviousSlide.Name = "tmiPreviousSlide";
            this.tmiPreviousSlide.Size = new System.Drawing.Size(173, 22);
            this.tmiPreviousSlide.Text = "Previous slide";
            this.tmiPreviousSlide.Click += new System.EventHandler(this.btnPreviousSlide_Click);
            // 
            // tmiPresentation
            // 
            this.tmiPresentation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiConnect,
            this.tmiDisconnect,
            this.tmiSearchForActiveSessions,
            this.tmsSession1,
            this.tmiSendContributionMaster,
            this.tmiSynchronizeMaster,
            this.tmsSession2,
            this.tmiBroadcastPresentation,
            this.tmiBroadcastCurrentSlide,
            this.tmiRequestSync,
            this.tmiAllowContributionFromParticipant,
            this.tmiSyncViewer});
            this.tmiPresentation.Name = "tmiPresentation";
            this.tmiPresentation.Size = new System.Drawing.Size(58, 20);
            this.tmiPresentation.Text = "Session";
            // 
            // tmiConnect
            // 
            this.tmiConnect.Image = global::iPH.Tool.Desktop.Properties.Resources.imConnect;
            this.tmiConnect.Name = "tmiConnect";
            this.tmiConnect.Size = new System.Drawing.Size(307, 22);
            this.tmiConnect.Text = "Connect";
            this.tmiConnect.Click += new System.EventHandler(this.tmiConnect_Click);
            // 
            // tmiDisconnect
            // 
            this.tmiDisconnect.Enabled = false;
            this.tmiDisconnect.Image = global::iPH.Tool.Desktop.Properties.Resources.imDisconnect;
            this.tmiDisconnect.Name = "tmiDisconnect";
            this.tmiDisconnect.Size = new System.Drawing.Size(307, 22);
            this.tmiDisconnect.Text = "Disconnect";
            this.tmiDisconnect.Click += new System.EventHandler(this.tmiDisconnect_Click);
            // 
            // tmiSearchForActiveSessions
            // 
            this.tmiSearchForActiveSessions.Name = "tmiSearchForActiveSessions";
            this.tmiSearchForActiveSessions.Size = new System.Drawing.Size(307, 22);
            this.tmiSearchForActiveSessions.Text = "Search for Active Sessions";
            this.tmiSearchForActiveSessions.Click += new System.EventHandler(this.tmiSearchForActiveSessionsToolStripMenuItem_Click);
            // 
            // tmsSession1
            // 
            this.tmsSession1.Name = "tmsSession1";
            this.tmsSession1.Size = new System.Drawing.Size(304, 6);
            // 
            // tmiSendContributionMaster
            // 
            this.tmiSendContributionMaster.Name = "tmiSendContributionMaster";
            this.tmiSendContributionMaster.Size = new System.Drawing.Size(307, 22);
            this.tmiSendContributionMaster.Text = "Send Contribution to master";
            this.tmiSendContributionMaster.Click += new System.EventHandler(this.tmiSendContributionMaster_Click);
            // 
            // tmiSynchronizeMaster
            // 
            this.tmiSynchronizeMaster.Checked = true;
            this.tmiSynchronizeMaster.CheckOnClick = true;
            this.tmiSynchronizeMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tmiSynchronizeMaster.Name = "tmiSynchronizeMaster";
            this.tmiSynchronizeMaster.Size = new System.Drawing.Size(307, 22);
            this.tmiSynchronizeMaster.Text = "Synchronize with master";
            this.tmiSynchronizeMaster.Click += new System.EventHandler(this.tmiSynchronizeMaster_Click);
            // 
            // tmsSession2
            // 
            this.tmsSession2.Name = "tmsSession2";
            this.tmsSession2.Size = new System.Drawing.Size(304, 6);
            // 
            // tmiBroadcastPresentation
            // 
            this.tmiBroadcastPresentation.Name = "tmiBroadcastPresentation";
            this.tmiBroadcastPresentation.Size = new System.Drawing.Size(307, 22);
            this.tmiBroadcastPresentation.Text = "Broadcast presentation";
            this.tmiBroadcastPresentation.Click += new System.EventHandler(this.tmiBroadcastPresentation_Click);
            // 
            // tmiBroadcastCurrentSlide
            // 
            this.tmiBroadcastCurrentSlide.Name = "tmiBroadcastCurrentSlide";
            this.tmiBroadcastCurrentSlide.Size = new System.Drawing.Size(307, 22);
            this.tmiBroadcastCurrentSlide.Text = "Broadcast current slide";
            this.tmiBroadcastCurrentSlide.Click += new System.EventHandler(this.tmiBroadcastCurrentSlide_Click);
            // 
            // tmiRequestSync
            // 
            this.tmiRequestSync.Name = "tmiRequestSync";
            this.tmiRequestSync.Size = new System.Drawing.Size(307, 22);
            this.tmiRequestSync.Text = "Request synchronization";
            this.tmiRequestSync.Click += new System.EventHandler(this.btnRequestSync_Click);
            // 
            // tmiAllowContributionFromParticipant
            // 
            this.tmiAllowContributionFromParticipant.Checked = true;
            this.tmiAllowContributionFromParticipant.CheckOnClick = true;
            this.tmiAllowContributionFromParticipant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tmiAllowContributionFromParticipant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tmiAllowContributionFromParticipant.Name = "tmiAllowContributionFromParticipant";
            this.tmiAllowContributionFromParticipant.Size = new System.Drawing.Size(307, 22);
            this.tmiAllowContributionFromParticipant.Text = "Allow participants to send their contribution";
            this.tmiAllowContributionFromParticipant.Click += new System.EventHandler(this.btnMessageMaster_Click);
            // 
            // tmiSyncViewer
            // 
            this.tmiSyncViewer.Checked = true;
            this.tmiSyncViewer.CheckOnClick = true;
            this.tmiSyncViewer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tmiSyncViewer.Name = "tmiSyncViewer";
            this.tmiSyncViewer.Size = new System.Drawing.Size(307, 22);
            this.tmiSyncViewer.Text = "Synchronize with viewer";
            this.tmiSyncViewer.Click += new System.EventHandler(this.btnSyncViewer_Click);
            // 
            // tmiFormat
            // 
            this.tmiFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiInk,
            this.tmiText});
            this.tmiFormat.Name = "tmiFormat";
            this.tmiFormat.Size = new System.Drawing.Size(57, 20);
            this.tmiFormat.Text = "Format";
            // 
            // tmiInk
            // 
            this.tmiInk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiInkColor});
            this.tmiInk.Name = "tmiInk";
            this.tmiInk.Size = new System.Drawing.Size(96, 22);
            this.tmiInk.Text = "Ink";
            // 
            // tmiInkColor
            // 
            this.tmiInkColor.Name = "tmiInkColor";
            this.tmiInkColor.Size = new System.Drawing.Size(103, 22);
            this.tmiInkColor.Text = "Color";
            this.tmiInkColor.Click += new System.EventHandler(this.tmiInkColor_Click);
            // 
            // tmiText
            // 
            this.tmiText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiTextColor,
            this.tmiTextFont});
            this.tmiText.Name = "tmiText";
            this.tmiText.Size = new System.Drawing.Size(96, 22);
            this.tmiText.Text = "Text";
            // 
            // tmiTextColor
            // 
            this.tmiTextColor.Name = "tmiTextColor";
            this.tmiTextColor.Size = new System.Drawing.Size(103, 22);
            this.tmiTextColor.Text = "Color";
            this.tmiTextColor.Click += new System.EventHandler(this.tmiTextColor_Click);
            // 
            // tmiTextFont
            // 
            this.tmiTextFont.Name = "tmiTextFont";
            this.tmiTextFont.Size = new System.Drawing.Size(103, 22);
            this.tmiTextFont.Text = "Font";
            this.tmiTextFont.Click += new System.EventHandler(this.tmiTextFont_Click);
            // 
            // tmiContext
            // 
            this.tmiContext.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiContextInformation,
            this.tmiShowParticipants,
            this.tmiContextInformationRules});
            this.tmiContext.Name = "tmiContext";
            this.tmiContext.Size = new System.Drawing.Size(60, 20);
            this.tmiContext.Text = "Context";
            // 
            // tmiContextInformation
            // 
            this.tmiContextInformation.Name = "tmiContextInformation";
            this.tmiContextInformation.Size = new System.Drawing.Size(212, 22);
            this.tmiContextInformation.Text = "Context Information";
            this.tmiContextInformation.Click += new System.EventHandler(this.tmiContextInformation_Click);
            // 
            // tmiShowParticipants
            // 
            this.tmiShowParticipants.Name = "tmiShowParticipants";
            this.tmiShowParticipants.Size = new System.Drawing.Size(212, 22);
            this.tmiShowParticipants.Text = "Show all participants";
            this.tmiShowParticipants.Click += new System.EventHandler(this.tmiShowParticipants_Click);
            // 
            // tmiContextInformationRules
            // 
            this.tmiContextInformationRules.Name = "tmiContextInformationRules";
            this.tmiContextInformationRules.Size = new System.Drawing.Size(212, 22);
            this.tmiContextInformationRules.Text = "Context Information Rules";
            this.tmiContextInformationRules.Click += new System.EventHandler(this.tmiContextInformationRules_Click);
            // 
            // tmiHelp
            // 
            this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAbout});
            this.tmiHelp.Name = "tmiHelp";
            this.tmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tmiHelp.Text = "Help";
            // 
            // tmiAbout
            // 
            this.tmiAbout.Image = global::iPH.Tool.Desktop.Properties.Resources.imAbout;
            this.tmiAbout.Name = "tmiAbout";
            this.tmiAbout.Size = new System.Drawing.Size(107, 22);
            this.tmiAbout.Text = "About";
            this.tmiAbout.Click += new System.EventHandler(this.tmiAbout_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tblblStatusConnection,
            this.tbPanelSlideTitleValue,
            this.tbPanelSlideTypeValue,
            this.tbPanelSlideModValue,
            this.tbPanelSlideCountValue});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 562);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(817, 22);
            this.mainStatusStrip.TabIndex = 3;
            // 
            // tblblStatusConnection
            // 
            this.tblblStatusConnection.AutoSize = false;
            this.tblblStatusConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tblblStatusConnection.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tblblStatusConnection.Name = "tblblStatusConnection";
            this.tblblStatusConnection.Size = new System.Drawing.Size(200, 17);
            this.tblblStatusConnection.Text = "Disconnected";
            // 
            // tbPanelSlideTitleValue
            // 
            this.tbPanelSlideTitleValue.AutoSize = false;
            this.tbPanelSlideTitleValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideTitleValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideTitleValue.Name = "tbPanelSlideTitleValue";
            this.tbPanelSlideTitleValue.Size = new System.Drawing.Size(200, 17);
            this.tbPanelSlideTitleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPanelSlideTypeValue
            // 
            this.tbPanelSlideTypeValue.AutoSize = false;
            this.tbPanelSlideTypeValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideTypeValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideTypeValue.Name = "tbPanelSlideTypeValue";
            this.tbPanelSlideTypeValue.Size = new System.Drawing.Size(150, 17);
            // 
            // tbPanelSlideModValue
            // 
            this.tbPanelSlideModValue.AutoSize = false;
            this.tbPanelSlideModValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideModValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideModValue.Name = "tbPanelSlideModValue";
            this.tbPanelSlideModValue.Size = new System.Drawing.Size(70, 17);
            // 
            // tbPanelSlideCountValue
            // 
            this.tbPanelSlideCountValue.AutoSize = false;
            this.tbPanelSlideCountValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideCountValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideCountValue.Name = "tbPanelSlideCountValue";
            this.tbPanelSlideCountValue.Size = new System.Drawing.Size(70, 17);
            // 
            // mainFunctionsPanel
            // 
            this.mainFunctionsPanel.Controls.Add(this.btnSyncViewer);
            this.mainFunctionsPanel.Controls.Add(this.btnContextInformation);
            this.mainFunctionsPanel.Controls.Add(this.btnTextErase);
            this.mainFunctionsPanel.Controls.Add(this.btnTextWrite);
            this.mainFunctionsPanel.Controls.Add(this.btnInkErase);
            this.mainFunctionsPanel.Controls.Add(this.btnInkWrite);
            this.mainFunctionsPanel.Controls.Add(this.btnDisconnect);
            this.mainFunctionsPanel.Controls.Add(this.btnConnect);
            this.mainFunctionsPanel.Controls.Add(this.btnMessageContribuitor);
            this.mainFunctionsPanel.Controls.Add(this.btnMessageMaster);
            this.mainFunctionsPanel.Controls.Add(this.btnSyncMaster);
            this.mainFunctionsPanel.Controls.Add(this.btnRequestSync);
            this.mainFunctionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainFunctionsPanel.Location = new System.Drawing.Point(0, 24);
            this.mainFunctionsPanel.Name = "mainFunctionsPanel";
            this.mainFunctionsPanel.Size = new System.Drawing.Size(817, 36);
            this.mainFunctionsPanel.TabIndex = 4;
            // 
            // btnSyncViewer
            // 
            this.btnSyncViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncViewer.Image = global::iPH.Tool.Desktop.Properties.Resources.imSynchronizedViewer;
            this.btnSyncViewer.Location = new System.Drawing.Point(667, 3);
            this.btnSyncViewer.Name = "btnSyncViewer";
            this.btnSyncViewer.Size = new System.Drawing.Size(36, 30);
            this.btnSyncViewer.TabIndex = 22;
            this.desktopMainFormToolTip.SetToolTip(this.btnSyncViewer, "Viewer synchronization");
            this.btnSyncViewer.UseVisualStyleBackColor = true;
            this.btnSyncViewer.Click += new System.EventHandler(this.btnSyncViewer_Click);
            // 
            // btnContextInformation
            // 
            this.btnContextInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContextInformation.Image = global::iPH.Tool.Desktop.Properties.Resources.imContextInformation;
            this.btnContextInformation.Location = new System.Drawing.Point(778, 3);
            this.btnContextInformation.Name = "btnContextInformation";
            this.btnContextInformation.Size = new System.Drawing.Size(36, 30);
            this.btnContextInformation.TabIndex = 21;
            this.desktopMainFormToolTip.SetToolTip(this.btnContextInformation, "Context information");
            this.btnContextInformation.UseVisualStyleBackColor = true;
            this.btnContextInformation.Click += new System.EventHandler(this.btnContextInformation_Click);
            // 
            // btnTextErase
            // 
            this.btnTextErase.Image = global::iPH.Tool.Desktop.Properties.Resources.imTextErase21;
            this.btnTextErase.Location = new System.Drawing.Point(319, 3);
            this.btnTextErase.Name = "btnTextErase";
            this.btnTextErase.Size = new System.Drawing.Size(36, 30);
            this.btnTextErase.TabIndex = 16;
            this.desktopMainFormToolTip.SetToolTip(this.btnTextErase, "Erase text");
            this.btnTextErase.UseVisualStyleBackColor = true;
            this.btnTextErase.Click += new System.EventHandler(this.btnTextErase_Click);
            // 
            // btnTextWrite
            // 
            this.btnTextWrite.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTextWrite.Image = global::iPH.Tool.Desktop.Properties.Resources.imTextWrite2;
            this.btnTextWrite.Location = new System.Drawing.Point(282, 3);
            this.btnTextWrite.Name = "btnTextWrite";
            this.btnTextWrite.Size = new System.Drawing.Size(36, 30);
            this.btnTextWrite.TabIndex = 15;
            this.desktopMainFormToolTip.SetToolTip(this.btnTextWrite, "Insert text");
            this.btnTextWrite.UseVisualStyleBackColor = true;
            this.btnTextWrite.Click += new System.EventHandler(this.btnTextWrite_Click);
            // 
            // btnInkErase
            // 
            this.btnInkErase.Image = global::iPH.Tool.Desktop.Properties.Resources.iminkerase2;
            this.btnInkErase.Location = new System.Drawing.Point(243, 3);
            this.btnInkErase.Name = "btnInkErase";
            this.btnInkErase.Size = new System.Drawing.Size(36, 30);
            this.btnInkErase.TabIndex = 14;
            this.desktopMainFormToolTip.SetToolTip(this.btnInkErase, "Erase ink");
            this.btnInkErase.UseVisualStyleBackColor = true;
            this.btnInkErase.Click += new System.EventHandler(this.btnInkErase_Click);
            // 
            // btnInkWrite
            // 
            this.btnInkWrite.BackColor = System.Drawing.SystemColors.Control;
            this.btnInkWrite.Image = global::iPH.Tool.Desktop.Properties.Resources.iminkwrite;
            this.btnInkWrite.Location = new System.Drawing.Point(206, 3);
            this.btnInkWrite.Name = "btnInkWrite";
            this.btnInkWrite.Size = new System.Drawing.Size(36, 30);
            this.btnInkWrite.TabIndex = 13;
            this.desktopMainFormToolTip.SetToolTip(this.btnInkWrite, "Insert ink");
            this.btnInkWrite.UseVisualStyleBackColor = false;
            this.btnInkWrite.Click += new System.EventHandler(this.btnInkWrite_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Image = global::iPH.Tool.Desktop.Properties.Resources.imDisconnect;
            this.btnDisconnect.Location = new System.Drawing.Point(41, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(36, 30);
            this.btnDisconnect.TabIndex = 12;
            this.desktopMainFormToolTip.SetToolTip(this.btnDisconnect, "Disconnect from the session");
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::iPH.Tool.Desktop.Properties.Resources.imConnect;
            this.btnConnect.Location = new System.Drawing.Point(4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(36, 30);
            this.btnConnect.TabIndex = 11;
            this.desktopMainFormToolTip.SetToolTip(this.btnConnect, "Connect to a session");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMessageContribuitor
            // 
            this.btnMessageContribuitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessageContribuitor.Image = global::iPH.Tool.Desktop.Properties.Resources.imSendToMaster;
            this.btnMessageContribuitor.Location = new System.Drawing.Point(741, 3);
            this.btnMessageContribuitor.Name = "btnMessageContribuitor";
            this.btnMessageContribuitor.Size = new System.Drawing.Size(36, 30);
            this.btnMessageContribuitor.TabIndex = 19;
            this.desktopMainFormToolTip.SetToolTip(this.btnMessageContribuitor, "Send contribution");
            this.btnMessageContribuitor.UseVisualStyleBackColor = true;
            this.btnMessageContribuitor.Click += new System.EventHandler(this.btnMessageContribuitor_Click);
            // 
            // btnMessageMaster
            // 
            this.btnMessageMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessageMaster.Image = global::iPH.Tool.Desktop.Properties.Resources.imReceiveFromContribuitors;
            this.btnMessageMaster.Location = new System.Drawing.Point(741, 3);
            this.btnMessageMaster.Name = "btnMessageMaster";
            this.btnMessageMaster.Size = new System.Drawing.Size(36, 30);
            this.btnMessageMaster.TabIndex = 18;
            this.desktopMainFormToolTip.SetToolTip(this.btnMessageMaster, "Enable/disable contributions");
            this.btnMessageMaster.UseVisualStyleBackColor = true;
            this.btnMessageMaster.Click += new System.EventHandler(this.btnMessageMaster_Click);
            // 
            // btnSyncMaster
            // 
            this.btnSyncMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncMaster.Image = global::iPH.Tool.Desktop.Properties.Resources.imSynchronizedMaster;
            this.btnSyncMaster.Location = new System.Drawing.Point(704, 3);
            this.btnSyncMaster.Name = "btnSyncMaster";
            this.btnSyncMaster.Size = new System.Drawing.Size(36, 30);
            this.btnSyncMaster.TabIndex = 20;
            this.desktopMainFormToolTip.SetToolTip(this.btnSyncMaster, "Master Synchronization");
            this.btnSyncMaster.UseVisualStyleBackColor = true;
            this.btnSyncMaster.Click += new System.EventHandler(this.btnSyncMaster_Click);
            // 
            // btnRequestSync
            // 
            this.btnRequestSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestSync.Image = global::iPH.Tool.Desktop.Properties.Resources.imRequestSync;
            this.btnRequestSync.Location = new System.Drawing.Point(704, 3);
            this.btnRequestSync.Name = "btnRequestSync";
            this.btnRequestSync.Size = new System.Drawing.Size(36, 30);
            this.btnRequestSync.TabIndex = 17;
            this.desktopMainFormToolTip.SetToolTip(this.btnRequestSync, "Request synchronization");
            this.btnRequestSync.UseVisualStyleBackColor = true;
            this.btnRequestSync.Click += new System.EventHandler(this.btnRequestSync_Click);
            // 
            // coFunctionsPanel
            // 
            this.coFunctionsPanel.Controls.Add(this.lbMessages);
            this.coFunctionsPanel.Controls.Add(this.btnNewSlidePrivate);
            this.coFunctionsPanel.Controls.Add(this.btnNewSlidePublic);
            this.coFunctionsPanel.Controls.Add(this.btnNextSlide);
            this.coFunctionsPanel.Controls.Add(this.btnPreviousSlide);
            this.coFunctionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.coFunctionsPanel.Location = new System.Drawing.Point(0, 526);
            this.coFunctionsPanel.Name = "coFunctionsPanel";
            this.coFunctionsPanel.Size = new System.Drawing.Size(817, 36);
            this.coFunctionsPanel.TabIndex = 9;
            // 
            // lbMessages
            // 
            this.lbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessages.BackColor = System.Drawing.SystemColors.Control;
            this.lbMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.ItemHeight = 12;
            this.lbMessages.Location = new System.Drawing.Point(83, 3);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(652, 28);
            this.lbMessages.TabIndex = 29;
            // 
            // btnNewSlidePrivate
            // 
            this.btnNewSlidePrivate.Image = global::iPH.Tool.Desktop.Properties.Resources.imslidenewprivate;
            this.btnNewSlidePrivate.Location = new System.Drawing.Point(41, 3);
            this.btnNewSlidePrivate.Name = "btnNewSlidePrivate";
            this.btnNewSlidePrivate.Size = new System.Drawing.Size(36, 30);
            this.btnNewSlidePrivate.TabIndex = 28;
            this.desktopMainFormToolTip.SetToolTip(this.btnNewSlidePrivate, "New private slide");
            this.btnNewSlidePrivate.UseVisualStyleBackColor = true;
            this.btnNewSlidePrivate.Click += new System.EventHandler(this.btnNewSlidePrivate_Click);
            // 
            // btnNewSlidePublic
            // 
            this.btnNewSlidePublic.Image = global::iPH.Tool.Desktop.Properties.Resources.imslidenew;
            this.btnNewSlidePublic.Location = new System.Drawing.Point(4, 3);
            this.btnNewSlidePublic.Name = "btnNewSlidePublic";
            this.btnNewSlidePublic.Size = new System.Drawing.Size(36, 30);
            this.btnNewSlidePublic.TabIndex = 26;
            this.desktopMainFormToolTip.SetToolTip(this.btnNewSlidePublic, "New public slide");
            this.btnNewSlidePublic.UseVisualStyleBackColor = true;
            this.btnNewSlidePublic.Click += new System.EventHandler(this.btnNewSlidePublic_Click);
            // 
            // btnNextSlide
            // 
            this.btnNextSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSlide.Image = global::iPH.Tool.Desktop.Properties.Resources.imslidenext;
            this.btnNextSlide.Location = new System.Drawing.Point(778, 3);
            this.btnNextSlide.Name = "btnNextSlide";
            this.btnNextSlide.Size = new System.Drawing.Size(36, 30);
            this.btnNextSlide.TabIndex = 3;
            this.desktopMainFormToolTip.SetToolTip(this.btnNextSlide, "Next slide");
            this.btnNextSlide.UseVisualStyleBackColor = true;
            this.btnNextSlide.Click += new System.EventHandler(this.btnNextSlide_Click);
            // 
            // btnPreviousSlide
            // 
            this.btnPreviousSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousSlide.Image = global::iPH.Tool.Desktop.Properties.Resources.imslideprevious;
            this.btnPreviousSlide.Location = new System.Drawing.Point(741, 3);
            this.btnPreviousSlide.Name = "btnPreviousSlide";
            this.btnPreviousSlide.Size = new System.Drawing.Size(36, 30);
            this.btnPreviousSlide.TabIndex = 2;
            this.desktopMainFormToolTip.SetToolTip(this.btnPreviousSlide, "Previous slide");
            this.btnPreviousSlide.UseVisualStyleBackColor = true;
            this.btnPreviousSlide.Click += new System.EventHandler(this.btnPreviousSlide_Click);
            // 
            // scDeck
            // 
            this.scDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDeck.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scDeck.Location = new System.Drawing.Point(0, 60);
            this.scDeck.Name = "scDeck";
            // 
            // scDeck.Panel1
            // 
            this.scDeck.Panel1.Controls.Add(this.tcDeck);
            // 
            // scDeck.Panel2
            // 
            this.scDeck.Panel2.Controls.Add(this.boardPanel);
            this.scDeck.Panel2.Controls.Add(this.slideInfoPanel);
            this.scDeck.Size = new System.Drawing.Size(817, 466);
            this.scDeck.SplitterDistance = 200;
            this.scDeck.TabIndex = 10;
            // 
            // tcDeck
            // 
            this.tcDeck.Controls.Add(this.tpMainDeck);
            this.tcDeck.Controls.Add(this.tpContributionDeck);
            this.tcDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDeck.Location = new System.Drawing.Point(0, 0);
            this.tcDeck.Name = "tcDeck";
            this.tcDeck.SelectedIndex = 0;
            this.tcDeck.Size = new System.Drawing.Size(200, 466);
            this.tcDeck.TabIndex = 7;
            // 
            // tpMainDeck
            // 
            this.tpMainDeck.Controls.Add(this.panelMainDeck);
            this.tpMainDeck.Location = new System.Drawing.Point(4, 22);
            this.tpMainDeck.Name = "tpMainDeck";
            this.tpMainDeck.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainDeck.Size = new System.Drawing.Size(192, 440);
            this.tpMainDeck.TabIndex = 0;
            this.tpMainDeck.Text = "Deck";
            this.tpMainDeck.UseVisualStyleBackColor = true;
            // 
            // panelMainDeck
            // 
            this.panelMainDeck.BackColor = System.Drawing.Color.White;
            this.panelMainDeck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMainDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainDeck.Location = new System.Drawing.Point(3, 3);
            this.panelMainDeck.Name = "panelMainDeck";
            this.panelMainDeck.Size = new System.Drawing.Size(186, 434);
            this.panelMainDeck.TabIndex = 8;
            // 
            // tpContributionDeck
            // 
            this.tpContributionDeck.Controls.Add(this.panelContributionDeck);
            this.tpContributionDeck.Location = new System.Drawing.Point(4, 22);
            this.tpContributionDeck.Name = "tpContributionDeck";
            this.tpContributionDeck.Padding = new System.Windows.Forms.Padding(3);
            this.tpContributionDeck.Size = new System.Drawing.Size(192, 440);
            this.tpContributionDeck.TabIndex = 1;
            this.tpContributionDeck.Text = "Contributions";
            this.tpContributionDeck.UseVisualStyleBackColor = true;
            // 
            // panelContributionDeck
            // 
            this.panelContributionDeck.BackColor = System.Drawing.Color.White;
            this.panelContributionDeck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContributionDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContributionDeck.Location = new System.Drawing.Point(3, 3);
            this.panelContributionDeck.Name = "panelContributionDeck";
            this.panelContributionDeck.Size = new System.Drawing.Size(186, 434);
            this.panelContributionDeck.TabIndex = 11;
            // 
            // boardPanel
            // 
            this.boardPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.boardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPanel.Location = new System.Drawing.Point(0, 0);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(613, 399);
            this.boardPanel.TabIndex = 12;
            // 
            // slideInfoPanel
            // 
            this.slideInfoPanel.Controls.Add(this.lblSlideName);
            this.slideInfoPanel.Controls.Add(this.tbSlideInfo);
            this.slideInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.slideInfoPanel.Location = new System.Drawing.Point(0, 399);
            this.slideInfoPanel.Name = "slideInfoPanel";
            this.slideInfoPanel.Size = new System.Drawing.Size(613, 67);
            this.slideInfoPanel.TabIndex = 10;
            this.slideInfoPanel.Visible = false;
            // 
            // lblSlideName
            // 
            this.lblSlideName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlideName.Location = new System.Drawing.Point(9, 5);
            this.lblSlideName.Name = "lblSlideName";
            this.lblSlideName.Size = new System.Drawing.Size(596, 15);
            this.lblSlideName.TabIndex = 1;
            // 
            // tbSlideInfo
            // 
            this.tbSlideInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSlideInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbSlideInfo.Location = new System.Drawing.Point(9, 23);
            this.tbSlideInfo.Multiline = true;
            this.tbSlideInfo.Name = "tbSlideInfo";
            this.tbSlideInfo.ReadOnly = true;
            this.tbSlideInfo.Size = new System.Drawing.Size(596, 38);
            this.tbSlideInfo.TabIndex = 0;
            // 
            // ofdIDD
            // 
            this.ofdIDD.DefaultExt = "idd";
            this.ofdIDD.Filter = "IDD files|*.idd";
            this.ofdIDD.Title = "Load File";
            // 
            // sfdIDD
            // 
            this.sfdIDD.DefaultExt = "idd";
            this.sfdIDD.Filter = "IDD files|*.idd";
            this.sfdIDD.Title = "Save File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(817, 584);
            this.Controls.Add(this.scDeck);
            this.Controls.Add(this.coFunctionsPanel);
            this.Controls.Add(this.mainFunctionsPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "iPH - XP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainFunctionsPanel.ResumeLayout(false);
            this.coFunctionsPanel.ResumeLayout(false);
            this.scDeck.Panel1.ResumeLayout(false);
            this.scDeck.Panel2.ResumeLayout(false);
            this.scDeck.ResumeLayout(false);
            this.tcDeck.ResumeLayout(false);
            this.tpMainDeck.ResumeLayout(false);
            this.tpContributionDeck.ResumeLayout(false);
            this.slideInfoPanel.ResumeLayout(false);
            this.slideInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiFile;
        private System.Windows.Forms.ToolStripMenuItem tmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tmiClose;
        private System.Windows.Forms.ToolStripMenuItem tmiSaveAs;
        private System.Windows.Forms.ToolStripSeparator tmsPersistence1;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiInsertNewSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiInsertNewSlidePublic;
        private System.Windows.Forms.ToolStripMenuItem tmiInsertNewSlidePrivate;
        private System.Windows.Forms.ToolStripSeparator tmsEdit2;
        private System.Windows.Forms.ToolStripMenuItem tmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tmiView;
        private System.Windows.Forms.ToolStripMenuItem tmiSlideInformation;
        private System.Windows.Forms.ToolStripMenuItem tmiFormat;
        private System.Windows.Forms.ToolStripMenuItem tmiInk;
        private System.Windows.Forms.ToolStripMenuItem tmiInkColor;
        private System.Windows.Forms.ToolStripMenuItem tmiText;
        private System.Windows.Forms.ToolStripMenuItem tmiTextFont;
        private System.Windows.Forms.ToolStripMenuItem tmiTextColor;
        private System.Windows.Forms.ToolStripMenuItem tmiPresentation;
        private System.Windows.Forms.ToolStripMenuItem tmiBroadcastPresentation;
        private System.Windows.Forms.ToolStripMenuItem tmiBroadcastCurrentSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiAllowContributionFromParticipant;
        private System.Windows.Forms.ToolStripMenuItem tmiRequestSync;
        private System.Windows.Forms.ToolStripMenuItem tmiSyncViewer;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiAbout;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tblblStatusConnection;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideTitleValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideTypeValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideModValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideCountValue;
        private System.Windows.Forms.Panel mainFunctionsPanel;
        private System.Windows.Forms.Button btnSyncViewer;
        private System.Windows.Forms.Button btnContextInformation;
        private System.Windows.Forms.Button btnSyncMaster;
        private System.Windows.Forms.Button btnMessageContribuitor;
        private System.Windows.Forms.Button btnMessageMaster;
        private System.Windows.Forms.Button btnRequestSync;
        private System.Windows.Forms.Button btnTextErase;
        private System.Windows.Forms.Button btnTextWrite;
        private System.Windows.Forms.Button btnInkErase;
        private System.Windows.Forms.Button btnInkWrite;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel coFunctionsPanel;
        private System.Windows.Forms.Button btnNewSlidePrivate;
        private System.Windows.Forms.Button btnNewSlidePublic;
        private System.Windows.Forms.Button btnNextSlide;
        private System.Windows.Forms.Button btnPreviousSlide;
        private System.Windows.Forms.SplitContainer scDeck;
        private System.Windows.Forms.TabControl tcDeck;
        private System.Windows.Forms.TabPage tpMainDeck;
        private System.Windows.Forms.Panel panelMainDeck;
        private System.Windows.Forms.TabPage tpContributionDeck;
        private System.Windows.Forms.Panel panelContributionDeck;
        private System.Windows.Forms.Panel slideInfoPanel;
        private System.Windows.Forms.Label lblSlideName;
        private System.Windows.Forms.TextBox tbSlideInfo;
        private System.Windows.Forms.OpenFileDialog ofdIDD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.ToolTip desktopMainFormToolTip;
        private System.Windows.Forms.SaveFileDialog sfdIDD;
        private System.Windows.Forms.ToolStripMenuItem tmiSave;
        private System.Windows.Forms.ToolStripSeparator tmsPersistence2;
        private System.Windows.Forms.ToolStripMenuItem tmiContext;
        private System.Windows.Forms.ToolStripSeparator tmsEdit1;
        private System.Windows.Forms.ToolStripSeparator tmsSession1;
        private System.Windows.Forms.ToolStripMenuItem tmiSendContributionMaster;
        private System.Windows.Forms.ToolStripMenuItem tmiSynchronizeMaster;
        private System.Windows.Forms.ToolStripSeparator tmsSession2;
        private System.Windows.Forms.ToolStripMenuItem tmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tmiDisconnect;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tmiContextInformation;
        private System.Windows.Forms.ToolStripMenuItem tmiConfiguration;
        private System.Windows.Forms.ToolStripMenuItem tmiShowParticipants;
        private System.Windows.Forms.ToolStripMenuItem tmiContextInformationRules;
        private System.Windows.Forms.ToolStripSeparator tmsView1;
        private System.Windows.Forms.ToolStripMenuItem tmiNextSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiPreviousSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiSearchForActiveSessions;
        private System.Windows.Forms.ListBox lbMessages;



    }
}
