namespace iPH.Commons.Forms
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; 

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcSession = new System.Windows.Forms.TabControl();
            this.tpContext = new System.Windows.Forms.TabPage();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.nudRequestTimeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseContextRules = new System.Windows.Forms.CheckBox();
            this.tbMocaWSUrl = new System.Windows.Forms.TextBox();
            this.lblMoCAWSUrl = new System.Windows.Forms.Label();
            this.tpSession = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSessionSearch = new System.Windows.Forms.CheckBox();
            this.tbSessionService = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tpSlideColors = new System.Windows.Forms.TabPage();
            this.btnPrivateSlideColor = new System.Windows.Forms.Button();
            this.btnPublicSlideColor = new System.Windows.Forms.Button();
            this.lblSlideColorDescription = new System.Windows.Forms.Label();
            this.lblPrivateSlideColor = new System.Windows.Forms.Label();
            this.lblPublicSlideColor = new System.Windows.Forms.Label();
            this.nudSessionInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tcSession.SuspendLayout();
            this.tpContext.SuspendLayout();
            this.tpSession.SuspendLayout();
            this.tpSlideColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 32);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnCancel.Location = new System.Drawing.Point(123, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOk.Location = new System.Drawing.Point(45, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tcSession
            // 
            this.tcSession.Controls.Add(this.tpContext);
            this.tcSession.Controls.Add(this.tpSession);
            this.tcSession.Controls.Add(this.tpSlideColors);
            this.tcSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSession.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tcSession.Location = new System.Drawing.Point(0, 0);
            this.tcSession.Name = "tcSession";
            this.tcSession.SelectedIndex = 0;
            this.tcSession.Size = new System.Drawing.Size(201, 213);
            this.tcSession.TabIndex = 5;
            // 
            // tpContext
            // 
            this.tpContext.Controls.Add(this.nudInterval);
            this.tpContext.Controls.Add(this.nudRequestTimeout);
            this.tpContext.Controls.Add(this.label3);
            this.tpContext.Controls.Add(this.label2);
            this.tpContext.Controls.Add(this.label1);
            this.tpContext.Controls.Add(this.chkUseContextRules);
            this.tpContext.Controls.Add(this.tbMocaWSUrl);
            this.tpContext.Controls.Add(this.lblMoCAWSUrl);
            this.tpContext.Location = new System.Drawing.Point(4, 22);
            this.tpContext.Name = "tpContext";
            this.tpContext.Size = new System.Drawing.Size(193, 187);
            this.tpContext.Text = "Context";
            // 
            // nudInterval
            // 
            this.nudInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudInterval.Location = new System.Drawing.Point(81, 127);
            this.nudInterval.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(100, 24);
            this.nudInterval.TabIndex = 23;
            this.nudInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nudRequestTimeout
            // 
            this.nudRequestTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRequestTimeout.Location = new System.Drawing.Point(94, 157);
            this.nudRequestTimeout.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nudRequestTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRequestTimeout.Name = "nudRequestTimeout";
            this.nudRequestTimeout.Size = new System.Drawing.Size(87, 24);
            this.nudRequestTimeout.TabIndex = 24;
            this.nudRequestTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 33);
            this.label3.Text = "Request Timeout (ms):";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.Text = "Interval (ms):";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(28, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 30);
            this.label1.Text = "Use Context Information Rules for Adaptation";
            // 
            // chkUseContextRules
            // 
            this.chkUseContextRules.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkUseContextRules.Location = new System.Drawing.Point(3, 90);
            this.chkUseContextRules.Name = "chkUseContextRules";
            this.chkUseContextRules.Size = new System.Drawing.Size(22, 26);
            this.chkUseContextRules.TabIndex = 11;
            // 
            // tbMocaWSUrl
            // 
            this.tbMocaWSUrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbMocaWSUrl.Location = new System.Drawing.Point(3, 29);
            this.tbMocaWSUrl.Multiline = true;
            this.tbMocaWSUrl.Name = "tbMocaWSUrl";
            this.tbMocaWSUrl.Size = new System.Drawing.Size(178, 50);
            this.tbMocaWSUrl.TabIndex = 7;
            // 
            // lblMoCAWSUrl
            // 
            this.lblMoCAWSUrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMoCAWSUrl.Location = new System.Drawing.Point(3, 6);
            this.lblMoCAWSUrl.Name = "lblMoCAWSUrl";
            this.lblMoCAWSUrl.Size = new System.Drawing.Size(85, 20);
            this.lblMoCAWSUrl.Text = "MoCA/WS Url:";
            // 
            // tpSession
            // 
            this.tpSession.Controls.Add(this.nudSessionInterval);
            this.tpSession.Controls.Add(this.label6);
            this.tpSession.Controls.Add(this.label5);
            this.tpSession.Controls.Add(this.cbSessionSearch);
            this.tpSession.Controls.Add(this.tbSessionService);
            this.tpSession.Controls.Add(this.label4);
            this.tpSession.Location = new System.Drawing.Point(4, 22);
            this.tpSession.Name = "tpSession";
            this.tpSession.Size = new System.Drawing.Size(193, 187);
            this.tpSession.Text = "Session";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(28, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 29);
            this.label5.Text = "Search for active sessions by region";
            // 
            // cbSessionSearch
            // 
            this.cbSessionSearch.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbSessionSearch.Location = new System.Drawing.Point(3, 93);
            this.cbSessionSearch.Name = "cbSessionSearch";
            this.cbSessionSearch.Size = new System.Drawing.Size(22, 26);
            this.cbSessionSearch.TabIndex = 12;
            // 
            // tbSessionService
            // 
            this.tbSessionService.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSessionService.Location = new System.Drawing.Point(3, 29);
            this.tbSessionService.Multiline = true;
            this.tbSessionService.Name = "tbSessionService";
            this.tbSessionService.Size = new System.Drawing.Size(178, 50);
            this.tbSessionService.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.Text = "Session Service Url:";
            // 
            // tpSlideColors
            // 
            this.tpSlideColors.Controls.Add(this.btnPrivateSlideColor);
            this.tpSlideColors.Controls.Add(this.btnPublicSlideColor);
            this.tpSlideColors.Controls.Add(this.lblSlideColorDescription);
            this.tpSlideColors.Controls.Add(this.lblPrivateSlideColor);
            this.tpSlideColors.Controls.Add(this.lblPublicSlideColor);
            this.tpSlideColors.Location = new System.Drawing.Point(4, 22);
            this.tpSlideColors.Name = "tpSlideColors";
            this.tpSlideColors.Size = new System.Drawing.Size(193, 187);
            this.tpSlideColors.Text = "Slide Colors";
            // 
            // btnPrivateSlideColor
            // 
            this.btnPrivateSlideColor.Location = new System.Drawing.Point(53, 70);
            this.btnPrivateSlideColor.Name = "btnPrivateSlideColor";
            this.btnPrivateSlideColor.Size = new System.Drawing.Size(121, 58);
            this.btnPrivateSlideColor.TabIndex = 5;
            this.btnPrivateSlideColor.Click += new System.EventHandler(this.btnPrivateSlideColor_Click);
            // 
            // btnPublicSlideColor
            // 
            this.btnPublicSlideColor.Location = new System.Drawing.Point(53, 6);
            this.btnPublicSlideColor.Name = "btnPublicSlideColor";
            this.btnPublicSlideColor.Size = new System.Drawing.Size(121, 58);
            this.btnPublicSlideColor.TabIndex = 4;
            this.btnPublicSlideColor.Click += new System.EventHandler(this.btnPublicSlideColor_Click);
            // 
            // lblSlideColorDescription
            // 
            this.lblSlideColorDescription.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSlideColorDescription.Location = new System.Drawing.Point(3, 134);
            this.lblSlideColorDescription.Name = "lblSlideColorDescription";
            this.lblSlideColorDescription.Size = new System.Drawing.Size(171, 20);
            this.lblSlideColorDescription.Text = "[Click to change color]";
            this.lblSlideColorDescription.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPrivateSlideColor
            // 
            this.lblPrivateSlideColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPrivateSlideColor.Location = new System.Drawing.Point(3, 67);
            this.lblPrivateSlideColor.Name = "lblPrivateSlideColor";
            this.lblPrivateSlideColor.Size = new System.Drawing.Size(50, 20);
            this.lblPrivateSlideColor.Text = "Private:";
            // 
            // lblPublicSlideColor
            // 
            this.lblPublicSlideColor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPublicSlideColor.Location = new System.Drawing.Point(3, 6);
            this.lblPublicSlideColor.Name = "lblPublicSlideColor";
            this.lblPublicSlideColor.Size = new System.Drawing.Size(44, 20);
            this.lblPublicSlideColor.Text = "Public:";
            // 
            // nudSessionInterval
            // 
            this.nudSessionInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSessionInterval.Location = new System.Drawing.Point(81, 124);
            this.nudSessionInterval.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nudSessionInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSessionInterval.Name = "nudSessionInterval";
            this.nudSessionInterval.Size = new System.Drawing.Size(100, 24);
            this.nudSessionInterval.TabIndex = 25;
            this.nudSessionInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(3, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.Text = "Interval (ms):";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(201, 245);
            this.Controls.Add(this.tcSession);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Text = "Configuration";
            this.panel1.ResumeLayout(false);
            this.tcSession.ResumeLayout(false);
            this.tpContext.ResumeLayout(false);
            this.tpSession.ResumeLayout(false);
            this.tpSlideColors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tcSession;
        private System.Windows.Forms.TabPage tpContext;
        private System.Windows.Forms.TextBox tbMocaWSUrl;
        private System.Windows.Forms.Label lblMoCAWSUrl;
        private System.Windows.Forms.TabPage tpSlideColors;
        private System.Windows.Forms.Label lblPublicSlideColor;
        private System.Windows.Forms.Label lblPrivateSlideColor;
        private System.Windows.Forms.Label lblSlideColorDescription;
        private System.Windows.Forms.Button btnPrivateSlideColor;
        private System.Windows.Forms.Button btnPublicSlideColor;
        private System.Windows.Forms.CheckBox chkUseContextRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRequestTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.TabPage tpSession;
        private System.Windows.Forms.TextBox tbSessionService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSessionSearch;
        private System.Windows.Forms.NumericUpDown nudSessionInterval;
        private System.Windows.Forms.Label label6;
    }
}