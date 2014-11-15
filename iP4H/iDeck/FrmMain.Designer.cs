namespace iPH.iDeck
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ofdPPT = new System.Windows.Forms.OpenFileDialog();
            this.mmMain = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiInsertNewSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.publicWhiteboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateWhiteboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRemoveSlide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiChangeSlideTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiChangeSlideColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiChangeSlideInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInformationBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.sbMain = new System.Windows.Forms.StatusStrip();
            this.tbPanelSlideTitleValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideTypeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideModValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbPanelSlideSizeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.cdSlide = new System.Windows.Forms.ColorDialog();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnPrivateSlideAdd = new System.Windows.Forms.Button();
            this.btnSlideRemove = new System.Windows.Forms.Button();
            this.btnSlideAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pnlSlideInfo = new System.Windows.Forms.Panel();
            this.tbSlideInfo = new System.Windows.Forms.TextBox();
            this.ofdIDD = new System.Windows.Forms.OpenFileDialog();
            this.sfdIDD = new System.Windows.Forms.SaveFileDialog();
            this.containerMain = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mmMain.SuspendLayout();
            this.sbMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlSlideInfo.SuspendLayout();
            this.containerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdPPT
            // 
            this.ofdPPT.Filter = "PPT files|*.ppt";
            // 
            // mmMain
            // 
            this.mmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiEdit,
            this.tmiView,
            this.tmiHelp});
            this.mmMain.Location = new System.Drawing.Point(0, 0);
            this.mmMain.Name = "mmMain";
            this.mmMain.Size = new System.Drawing.Size(738, 24);
            this.mmMain.TabIndex = 0;
            this.mmMain.Text = "menuStrip1";
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiOpen,
            this.tmiClose,
            this.toolStripMenuItem1,
            this.tmiSave,
            this.tmiSaveAs,
            this.toolStripMenuItem2,
            this.tmiExit});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.Size = new System.Drawing.Size(35, 20);
            this.tmiFile.Text = "File";
            // 
            // tmiOpen
            // 
            this.tmiOpen.Name = "tmiOpen";
            this.tmiOpen.Size = new System.Drawing.Size(152, 22);
            this.tmiOpen.Text = "Open";
            this.tmiOpen.Click += new System.EventHandler(this.tmiOpen_Click);
            // 
            // tmiClose
            // 
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(152, 22);
            this.tmiClose.Text = "Close";
            this.tmiClose.Click += new System.EventHandler(this.tmiClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // tmiSave
            // 
            this.tmiSave.Name = "tmiSave";
            this.tmiSave.Size = new System.Drawing.Size(152, 22);
            this.tmiSave.Text = "Save";
            this.tmiSave.Click += new System.EventHandler(this.tmiSave_Click);
            // 
            // tmiSaveAs
            // 
            this.tmiSaveAs.Name = "tmiSaveAs";
            this.tmiSaveAs.Size = new System.Drawing.Size(152, 22);
            this.tmiSaveAs.Text = "Save As...";
            this.tmiSaveAs.Click += new System.EventHandler(this.tmiSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(152, 22);
            this.tmiExit.Text = "Exit";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiEdit
            // 
            this.tmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAppend,
            this.toolStripMenuItem5,
            this.tmiInsertNewSlide,
            this.tmiRemoveSlide,
            this.toolStripMenuItem3,
            this.tmiCopy,
            this.tmiPaste,
            this.toolStripMenuItem6,
            this.tmiChangeSlideTitle,
            this.tmiChangeSlideColor,
            this.tmiChangeSlideInfo});
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(37, 20);
            this.tmiEdit.Text = "Edit";
            // 
            // tmiAppend
            // 
            this.tmiAppend.Image = global::iPH.iDeck.Properties.Resources.imPresentationFile;
            this.tmiAppend.Name = "tmiAppend";
            this.tmiAppend.Size = new System.Drawing.Size(186, 22);
            this.tmiAppend.Text = "Append presentation";
            this.tmiAppend.Click += new System.EventHandler(this.tmiAppend_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(183, 6);
            // 
            // tmiInsertNewSlide
            // 
            this.tmiInsertNewSlide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicWhiteboardToolStripMenuItem,
            this.privateWhiteboardToolStripMenuItem});
            this.tmiInsertNewSlide.Name = "tmiInsertNewSlide";
            this.tmiInsertNewSlide.Size = new System.Drawing.Size(186, 22);
            this.tmiInsertNewSlide.Text = "Insert new slide";
            // 
            // publicWhiteboardToolStripMenuItem
            // 
            this.publicWhiteboardToolStripMenuItem.Name = "publicWhiteboardToolStripMenuItem";
            this.publicWhiteboardToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.publicWhiteboardToolStripMenuItem.Text = "Public whiteboard";
            this.publicWhiteboardToolStripMenuItem.Click += new System.EventHandler(this.btnSlideAdd_Click);
            // 
            // privateWhiteboardToolStripMenuItem
            // 
            this.privateWhiteboardToolStripMenuItem.Name = "privateWhiteboardToolStripMenuItem";
            this.privateWhiteboardToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.privateWhiteboardToolStripMenuItem.Text = "Private whiteboard";
            this.privateWhiteboardToolStripMenuItem.Click += new System.EventHandler(this.btnPrivateSlideAdd_Click);
            // 
            // tmiRemoveSlide
            // 
            this.tmiRemoveSlide.Name = "tmiRemoveSlide";
            this.tmiRemoveSlide.Size = new System.Drawing.Size(186, 22);
            this.tmiRemoveSlide.Text = "Remove slide";
            this.tmiRemoveSlide.Click += new System.EventHandler(this.btnSlideRemove_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 6);
            // 
            // tmiCopy
            // 
            this.tmiCopy.Name = "tmiCopy";
            this.tmiCopy.Size = new System.Drawing.Size(186, 22);
            this.tmiCopy.Text = "Copy";
            this.tmiCopy.Click += new System.EventHandler(this.tmiCopy_Click);
            // 
            // tmiPaste
            // 
            this.tmiPaste.Enabled = false;
            this.tmiPaste.Name = "tmiPaste";
            this.tmiPaste.Size = new System.Drawing.Size(186, 22);
            this.tmiPaste.Text = "Paste";
            this.tmiPaste.Click += new System.EventHandler(this.tmiPaste_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(183, 6);
            // 
            // tmiChangeSlideTitle
            // 
            this.tmiChangeSlideTitle.Name = "tmiChangeSlideTitle";
            this.tmiChangeSlideTitle.Size = new System.Drawing.Size(186, 22);
            this.tmiChangeSlideTitle.Text = "Change slide title";
            this.tmiChangeSlideTitle.Click += new System.EventHandler(this.tmiChangeSlideTitle_Click);
            // 
            // tmiChangeSlideColor
            // 
            this.tmiChangeSlideColor.Name = "tmiChangeSlideColor";
            this.tmiChangeSlideColor.Size = new System.Drawing.Size(186, 22);
            this.tmiChangeSlideColor.Text = "Change slide color";
            this.tmiChangeSlideColor.Click += new System.EventHandler(this.tmiChangeSlideColor_Click);
            // 
            // tmiChangeSlideInfo
            // 
            this.tmiChangeSlideInfo.Name = "tmiChangeSlideInfo";
            this.tmiChangeSlideInfo.Size = new System.Drawing.Size(186, 22);
            this.tmiChangeSlideInfo.Text = "Change slide info";
            this.tmiChangeSlideInfo.Click += new System.EventHandler(this.tmiChangeSlideInfo_Click);
            // 
            // tmiView
            // 
            this.tmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiInformationBar});
            this.tmiView.Name = "tmiView";
            this.tmiView.Size = new System.Drawing.Size(41, 20);
            this.tmiView.Text = "View";
            // 
            // tmiInformationBar
            // 
            this.tmiInformationBar.CheckOnClick = true;
            this.tmiInformationBar.Name = "tmiInformationBar";
            this.tmiInformationBar.Size = new System.Drawing.Size(171, 22);
            this.tmiInformationBar.Text = "Slide\'s information";
            this.tmiInformationBar.CheckedChanged += new System.EventHandler(this.tmiInformationBar_CheckedChanged);
            // 
            // tmiHelp
            // 
            this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAbout});
            this.tmiHelp.Name = "tmiHelp";
            this.tmiHelp.Size = new System.Drawing.Size(40, 20);
            this.tmiHelp.Text = "Help";
            // 
            // tmiAbout
            // 
            this.tmiAbout.Image = global::iPH.iDeck.Properties.Resources.imAbout;
            this.tmiAbout.Name = "tmiAbout";
            this.tmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tmiAbout.Text = "About";
            this.tmiAbout.Click += new System.EventHandler(this.tmiAbout_Click);
            // 
            // sbMain
            // 
            this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPanelSlideTitleValue,
            this.tbPanelSlideTypeValue,
            this.tbPanelSlideModValue,
            this.tbPanelSlideCountValue,
            this.tbPanelSlideSizeValue});
            this.sbMain.Location = new System.Drawing.Point(0, 475);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(738, 22);
            this.sbMain.TabIndex = 1;
            this.sbMain.Text = "statusStrip1";
            // 
            // tbPanelSlideTitleValue
            // 
            this.tbPanelSlideTitleValue.AutoSize = false;
            this.tbPanelSlideTitleValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideTitleValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideTitleValue.Name = "tbPanelSlideTitleValue";
            this.tbPanelSlideTitleValue.Size = new System.Drawing.Size(300, 17);
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
            this.tbPanelSlideTypeValue.Size = new System.Drawing.Size(100, 17);
            // 
            // tbPanelSlideModValue
            // 
            this.tbPanelSlideModValue.AutoSize = false;
            this.tbPanelSlideModValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideModValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideModValue.Name = "tbPanelSlideModValue";
            this.tbPanelSlideModValue.Size = new System.Drawing.Size(100, 17);
            // 
            // tbPanelSlideCountValue
            // 
            this.tbPanelSlideCountValue.AutoSize = false;
            this.tbPanelSlideCountValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideCountValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideCountValue.Name = "tbPanelSlideCountValue";
            this.tbPanelSlideCountValue.Size = new System.Drawing.Size(100, 17);
            // 
            // tbPanelSlideSizeValue
            // 
            this.tbPanelSlideSizeValue.AutoSize = false;
            this.tbPanelSlideSizeValue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbPanelSlideSizeValue.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPanelSlideSizeValue.Name = "tbPanelSlideSizeValue";
            this.tbPanelSlideSizeValue.Size = new System.Drawing.Size(100, 17);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnPrivateSlideAdd);
            this.pnlTop.Controls.Add(this.btnSlideRemove);
            this.pnlTop.Controls.Add(this.btnSlideAdd);
            this.pnlTop.Controls.Add(this.btnNext);
            this.pnlTop.Controls.Add(this.btnPrevious);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(738, 36);
            this.pnlTop.TabIndex = 2;
            // 
            // btnPrivateSlideAdd
            // 
            this.btnPrivateSlideAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPrivateSlideAdd.Image")));
            this.btnPrivateSlideAdd.Location = new System.Drawing.Point(119, 3);
            this.btnPrivateSlideAdd.Name = "btnPrivateSlideAdd";
            this.btnPrivateSlideAdd.Size = new System.Drawing.Size(36, 30);
            this.btnPrivateSlideAdd.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnPrivateSlideAdd, "Add private slide");
            this.btnPrivateSlideAdd.UseVisualStyleBackColor = true;
            this.btnPrivateSlideAdd.Click += new System.EventHandler(this.btnPrivateSlideAdd_Click);
            // 
            // btnSlideRemove
            // 
            this.btnSlideRemove.Image = global::iPH.iDeck.Properties.Resources.imSlideDelete;
            this.btnSlideRemove.Location = new System.Drawing.Point(156, 3);
            this.btnSlideRemove.Name = "btnSlideRemove";
            this.btnSlideRemove.Size = new System.Drawing.Size(36, 30);
            this.btnSlideRemove.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnSlideRemove, "Delete slide");
            this.btnSlideRemove.UseVisualStyleBackColor = true;
            this.btnSlideRemove.Click += new System.EventHandler(this.btnSlideRemove_Click);
            // 
            // btnSlideAdd
            // 
            this.btnSlideAdd.Image = global::iPH.iDeck.Properties.Resources.imSlideNew;
            this.btnSlideAdd.Location = new System.Drawing.Point(82, 3);
            this.btnSlideAdd.Name = "btnSlideAdd";
            this.btnSlideAdd.Size = new System.Drawing.Size(36, 30);
            this.btnSlideAdd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnSlideAdd, "Add public slide");
            this.btnSlideAdd.UseVisualStyleBackColor = true;
            this.btnSlideAdd.Click += new System.EventHandler(this.btnSlideAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::iPH.iDeck.Properties.Resources.imSlideNext;
            this.btnNext.Location = new System.Drawing.Point(40, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 30);
            this.btnNext.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnNext, "Next slide");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = global::iPH.iDeck.Properties.Resources.imSlidePrevious;
            this.btnPrevious.Location = new System.Drawing.Point(3, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 30);
            this.btnPrevious.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnPrevious, "Previous slide");
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnlSlideInfo
            // 
            this.pnlSlideInfo.Controls.Add(this.tbSlideInfo);
            this.pnlSlideInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSlideInfo.Location = new System.Drawing.Point(0, 422);
            this.pnlSlideInfo.Name = "pnlSlideInfo";
            this.pnlSlideInfo.Size = new System.Drawing.Size(738, 53);
            this.pnlSlideInfo.TabIndex = 6;
            this.pnlSlideInfo.Visible = false;
            // 
            // tbSlideInfo
            // 
            this.tbSlideInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSlideInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbSlideInfo.Location = new System.Drawing.Point(9, 6);
            this.tbSlideInfo.Multiline = true;
            this.tbSlideInfo.Name = "tbSlideInfo";
            this.tbSlideInfo.ReadOnly = true;
            this.tbSlideInfo.Size = new System.Drawing.Size(717, 41);
            this.tbSlideInfo.TabIndex = 0;
            // 
            // ofdIDD
            // 
            this.ofdIDD.Filter = "IDD files|*.idd";
            // 
            // sfdIDD
            // 
            this.sfdIDD.Filter = "IDD files|*.idd";
            // 
            // containerMain
            // 
            this.containerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.containerMain.Location = new System.Drawing.Point(0, 60);
            this.containerMain.Name = "containerMain";
            // 
            // containerMain.Panel1
            // 
            this.containerMain.Panel1.AutoScroll = true;
            this.containerMain.Panel1MinSize = 100;
            this.containerMain.Size = new System.Drawing.Size(738, 362);
            this.containerMain.SplitterDistance = 180;
            this.containerMain.SplitterWidth = 5;
            this.containerMain.TabIndex = 7;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 497);
            this.Controls.Add(this.containerMain);
            this.Controls.Add(this.pnlSlideInfo);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.mmMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mmMain;
            this.Name = "FrmMain";
            this.Text = "iPH - iDeck";
            this.mmMain.ResumeLayout(false);
            this.mmMain.PerformLayout();
            this.sbMain.ResumeLayout(false);
            this.sbMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlSlideInfo.ResumeLayout(false);
            this.pnlSlideInfo.PerformLayout();
            this.containerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdPPT;
        private System.Windows.Forms.MenuStrip mmMain;
        private System.Windows.Forms.ToolStripMenuItem tmiFile;
        private System.Windows.Forms.ToolStripMenuItem tmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiInsertNewSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiRemoveSlide;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiAbout;
        private System.Windows.Forms.StatusStrip sbMain;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tmiChangeSlideColor;
        private System.Windows.Forms.ColorDialog cdSlide;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnSlideRemove;
        private System.Windows.Forms.Button btnSlideAdd;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStripMenuItem publicWhiteboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem privateWhiteboardToolStripMenuItem;
        private System.Windows.Forms.Button btnPrivateSlideAdd;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideTitleValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideTypeValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideModValue;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideCountValue;
        private System.Windows.Forms.ToolStripMenuItem tmiChangeSlideTitle;
        private System.Windows.Forms.ToolStripMenuItem tmiChangeSlideInfo;
        private System.Windows.Forms.ToolStripMenuItem tmiView;
        private System.Windows.Forms.ToolStripMenuItem tmiInformationBar;
        private System.Windows.Forms.Panel pnlSlideInfo;
        private System.Windows.Forms.TextBox tbSlideInfo;
        private System.Windows.Forms.OpenFileDialog ofdIDD;
        private System.Windows.Forms.ToolStripMenuItem tmiAppend;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tmiPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.SaveFileDialog sfdIDD;
        private System.Windows.Forms.ToolStripMenuItem tmiSaveAs;
        private System.Windows.Forms.SplitContainer containerMain;
        private System.Windows.Forms.ToolStripStatusLabel tbPanelSlideSizeValue;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}