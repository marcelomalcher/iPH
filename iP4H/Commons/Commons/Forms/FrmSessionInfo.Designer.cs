namespace iP4H.Commons.Forms
{
    partial class FrmSessionInfo
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
            this.tcSession = new System.Windows.Forms.TabControl();
            this.tpSession = new System.Windows.Forms.TabPage();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbMulticastIP = new System.Windows.Forms.ComboBox();
            this.lblMulticastIP = new System.Windows.Forms.Label();
            this.tpParticipant = new System.Windows.Forms.TabPage();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMacAddress = new System.Windows.Forms.Label();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.rdbMaster = new System.Windows.Forms.RadioButton();
            this.rdbContribuitor = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rdbViewer = new System.Windows.Forms.RadioButton();
            this.tcSession.SuspendLayout();
            this.tpSession.SuspendLayout();
            this.tpParticipant.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSession
            // 
            this.tcSession.Controls.Add(this.tpSession);
            this.tcSession.Controls.Add(this.tpParticipant);
            this.tcSession.Location = new System.Drawing.Point(3, 3);
            this.tcSession.Name = "tcSession";
            this.tcSession.SelectedIndex = 0;
            this.tcSession.Size = new System.Drawing.Size(200, 184);
            this.tcSession.TabIndex = 2;
            // 
            // tpSession
            // 
            this.tpSession.Controls.Add(this.btnCancel);
            this.tpSession.Controls.Add(this.btnOk);
            this.tpSession.Controls.Add(this.txtKey);
            this.tpSession.Controls.Add(this.label1);
            this.tpSession.Controls.Add(this.nupPort);
            this.tpSession.Controls.Add(this.lblPort);
            this.tpSession.Controls.Add(this.cbMulticastIP);
            this.tpSession.Controls.Add(this.lblMulticastIP);
            this.tpSession.Location = new System.Drawing.Point(4, 25);
            this.tpSession.Name = "tpSession";
            this.tpSession.Size = new System.Drawing.Size(192, 155);
            this.tpSession.Text = "Session";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(3, 87);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(126, 23);
            this.txtKey.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.Text = "Key (Optional):";
            // 
            // nupPort
            // 
            this.nupPort.Location = new System.Drawing.Point(135, 28);
            this.nupPort.Name = "nupPort";
            this.nupPort.Size = new System.Drawing.Size(54, 24);
            this.nupPort.TabIndex = 4;
            this.nupPort.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(135, 6);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 20);
            this.lblPort.Text = "Port:";
            // 
            // cbMulticastIP
            // 
            this.cbMulticastIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbMulticastIP.Items.Add("234.4.4.4");
            this.cbMulticastIP.Items.Add("234.5.5.4");
            this.cbMulticastIP.Items.Add("234.6.6.4");
            this.cbMulticastIP.Items.Add("234.7.7.4");
            this.cbMulticastIP.Items.Add("234.8.8.4");
            this.cbMulticastIP.Location = new System.Drawing.Point(3, 29);
            this.cbMulticastIP.Name = "cbMulticastIP";
            this.cbMulticastIP.Size = new System.Drawing.Size(126, 23);
            this.cbMulticastIP.TabIndex = 1;
            // 
            // lblMulticastIP
            // 
            this.lblMulticastIP.Location = new System.Drawing.Point(3, 6);
            this.lblMulticastIP.Name = "lblMulticastIP";
            this.lblMulticastIP.Size = new System.Drawing.Size(35, 20);
            this.lblMulticastIP.Text = "IP:";
            // 
            // tpParticipant
            // 
            this.tpParticipant.Controls.Add(this.rdbViewer);
            this.tpParticipant.Controls.Add(this.rdbContribuitor);
            this.tpParticipant.Controls.Add(this.rdbMaster);
            this.tpParticipant.Controls.Add(this.lblRole);
            this.tpParticipant.Controls.Add(this.txtName);
            this.tpParticipant.Controls.Add(this.lblName);
            this.tpParticipant.Controls.Add(this.lblMacAddress);
            this.tpParticipant.Controls.Add(this.txtMacAddress);
            this.tpParticipant.Location = new System.Drawing.Point(4, 25);
            this.tpParticipant.Name = "tpParticipant";
            this.tpParticipant.Size = new System.Drawing.Size(192, 155);
            this.tpParticipant.Text = "Participant";
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(3, 72);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(46, 20);
            this.lblRole.Text = "Role:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 23);
            this.txtName.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(3, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 23);
            this.lblName.Text = "Name:";
            // 
            // lblMacAddress
            // 
            this.lblMacAddress.Location = new System.Drawing.Point(3, 6);
            this.lblMacAddress.Name = "lblMacAddress";
            this.lblMacAddress.Size = new System.Drawing.Size(46, 20);
            this.lblMacAddress.Text = "MAC:";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtMacAddress.Enabled = false;
            this.txtMacAddress.Location = new System.Drawing.Point(55, 6);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(134, 23);
            this.txtMacAddress.TabIndex = 9;
            // 
            // rdbMaster
            // 
            this.rdbMaster.Checked = true;
            this.rdbMaster.Location = new System.Drawing.Point(55, 72);
            this.rdbMaster.Name = "rdbMaster";
            this.rdbMaster.Size = new System.Drawing.Size(65, 20);
            this.rdbMaster.TabIndex = 21;
            this.rdbMaster.TabStop = false;
            this.rdbMaster.Text = "Master";
            // 
            // rdbContribuitor
            // 
            this.rdbContribuitor.Location = new System.Drawing.Point(55, 98);
            this.rdbContribuitor.Name = "rdbContribuitor";
            this.rdbContribuitor.Size = new System.Drawing.Size(99, 20);
            this.rdbContribuitor.TabIndex = 22;
            this.rdbContribuitor.TabStop = false;
            this.rdbContribuitor.Text = "Contribuitor";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(117, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(39, 127);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rdbViewer
            // 
            this.rdbViewer.Location = new System.Drawing.Point(55, 124);
            this.rdbViewer.Name = "rdbViewer";
            this.rdbViewer.Size = new System.Drawing.Size(99, 20);
            this.rdbViewer.TabIndex = 23;
            this.rdbViewer.TabStop = false;
            this.rdbViewer.Text = "Viewer";
            // 
            // FrmSessionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(207, 190);
            this.Controls.Add(this.tcSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSessionInfo";
            this.Text = "Session";
            this.tcSession.ResumeLayout(false);
            this.tpSession.ResumeLayout(false);
            this.tpParticipant.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSession;
        private System.Windows.Forms.TabPage tpSession;
        private System.Windows.Forms.TabPage tpParticipant;
        private System.Windows.Forms.ComboBox cbMulticastIP;
        private System.Windows.Forms.Label lblMulticastIP;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.RadioButton rdbMaster;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rdbViewer;
        private System.Windows.Forms.RadioButton rdbContribuitor;
    }
}