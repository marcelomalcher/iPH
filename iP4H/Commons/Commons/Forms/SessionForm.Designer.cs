namespace iPH.Commons.Forms
{
    partial class SessionForm
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcSession = new System.Windows.Forms.TabControl();
            this.tpSession = new System.Windows.Forms.TabPage();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.cbMulticastIP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nupPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblMulticastIP = new System.Windows.Forms.Label();
            this.tpParticipant = new System.Windows.Forms.TabPage();
            this.rdbViewer = new System.Windows.Forms.RadioButton();
            this.rdbContribuitor = new System.Windows.Forms.RadioButton();
            this.rdbMaster = new System.Windows.Forms.RadioButton();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMacAddress = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlBottom.SuspendLayout();
            this.tcSession.SuspendLayout();
            this.tpSession.SuspendLayout();
            this.tpParticipant.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 182);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(192, 26);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnCancel.Location = new System.Drawing.Point(117, 3);
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
            this.btnOk.Location = new System.Drawing.Point(39, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tcSession
            // 
            this.tcSession.Controls.Add(this.tpSession);
            this.tcSession.Controls.Add(this.tpParticipant);
            this.tcSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSession.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tcSession.Location = new System.Drawing.Point(0, 0);
            this.tcSession.Name = "tcSession";
            this.tcSession.SelectedIndex = 0;
            this.tcSession.Size = new System.Drawing.Size(192, 182);
            this.tcSession.TabIndex = 3;
            // 
            // tpSession
            // 
            this.tpSession.Controls.Add(this.txtKey);
            this.tpSession.Controls.Add(this.cbMulticastIP);
            this.tpSession.Controls.Add(this.label1);
            this.tpSession.Controls.Add(this.nupPort);
            this.tpSession.Controls.Add(this.lblPort);
            this.tpSession.Controls.Add(this.lblMulticastIP);
            this.tpSession.Location = new System.Drawing.Point(4, 22);
            this.tpSession.Name = "tpSession";
            this.tpSession.Size = new System.Drawing.Size(184, 156);
            this.tpSession.Text = "Session";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKey.Location = new System.Drawing.Point(3, 87);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(119, 19);
            this.txtKey.TabIndex = 7;
            // 
            // cbMulticastIP
            // 
            this.cbMulticastIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbMulticastIP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbMulticastIP.Items.Add("234.4.4.4");
            this.cbMulticastIP.Items.Add("234.5.5.4");
            this.cbMulticastIP.Items.Add("234.6.6.4");
            this.cbMulticastIP.Items.Add("234.7.7.4");
            this.cbMulticastIP.Items.Add("234.8.8.4");
            this.cbMulticastIP.Location = new System.Drawing.Point(3, 29);
            this.cbMulticastIP.Name = "cbMulticastIP";
            this.cbMulticastIP.Size = new System.Drawing.Size(119, 19);
            this.cbMulticastIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.Text = "Key (Optional):";
            // 
            // nupPort
            // 
            this.nupPort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.nupPort.Location = new System.Drawing.Point(128, 28);
            this.nupPort.Name = "nupPort";
            this.nupPort.Size = new System.Drawing.Size(54, 20);
            this.nupPort.TabIndex = 4;
            this.nupPort.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPort.Location = new System.Drawing.Point(128, 6);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 20);
            this.lblPort.Text = "Port:";
            // 
            // lblMulticastIP
            // 
            this.lblMulticastIP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMulticastIP.Location = new System.Drawing.Point(3, 6);
            this.lblMulticastIP.Name = "lblMulticastIP";
            this.lblMulticastIP.Size = new System.Drawing.Size(85, 20);
            this.lblMulticastIP.Text = "Multicast IP:";
            // 
            // tpParticipant
            // 
            this.tpParticipant.Controls.Add(this.rdbViewer);
            this.tpParticipant.Controls.Add(this.rdbContribuitor);
            this.tpParticipant.Controls.Add(this.rdbMaster);
            this.tpParticipant.Controls.Add(this.lblRole);
            this.tpParticipant.Controls.Add(this.txtName);
            this.tpParticipant.Controls.Add(this.txtMacAddress);
            this.tpParticipant.Controls.Add(this.lblName);
            this.tpParticipant.Controls.Add(this.lblMacAddress);
            this.tpParticipant.Location = new System.Drawing.Point(4, 22);
            this.tpParticipant.Name = "tpParticipant";
            this.tpParticipant.Size = new System.Drawing.Size(184, 156);
            this.tpParticipant.Text = "User";
            // 
            // rdbViewer
            // 
            this.rdbViewer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdbViewer.Location = new System.Drawing.Point(55, 124);
            this.rdbViewer.Name = "rdbViewer";
            this.rdbViewer.Size = new System.Drawing.Size(99, 20);
            this.rdbViewer.TabIndex = 23;
            this.rdbViewer.TabStop = false;
            this.rdbViewer.Text = "Viewer";
            // 
            // rdbContribuitor
            // 
            this.rdbContribuitor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdbContribuitor.Location = new System.Drawing.Point(55, 98);
            this.rdbContribuitor.Name = "rdbContribuitor";
            this.rdbContribuitor.Size = new System.Drawing.Size(99, 20);
            this.rdbContribuitor.TabIndex = 22;
            this.rdbContribuitor.TabStop = false;
            this.rdbContribuitor.Text = "Contribuitor";
            // 
            // rdbMaster
            // 
            this.rdbMaster.Checked = true;
            this.rdbMaster.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdbMaster.Location = new System.Drawing.Point(55, 72);
            this.rdbMaster.Name = "rdbMaster";
            this.rdbMaster.Size = new System.Drawing.Size(65, 20);
            this.rdbMaster.TabIndex = 21;
            this.rdbMaster.TabStop = false;
            this.rdbMaster.Text = "Master";
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRole.Location = new System.Drawing.Point(3, 72);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(46, 20);
            this.lblRole.Text = "Role:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtName.Location = new System.Drawing.Point(55, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 19);
            this.txtName.TabIndex = 13;
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Enabled = false;
            this.txtMacAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMacAddress.Location = new System.Drawing.Point(55, 6);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(126, 19);
            this.txtMacAddress.TabIndex = 9;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblName.Location = new System.Drawing.Point(3, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 23);
            this.lblName.Text = "Name:";
            // 
            // lblMacAddress
            // 
            this.lblMacAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMacAddress.Location = new System.Drawing.Point(3, 5);
            this.lblMacAddress.Name = "lblMacAddress";
            this.lblMacAddress.Size = new System.Drawing.Size(46, 20);
            this.lblMacAddress.Text = "MAC:";
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(192, 208);
            this.Controls.Add(this.tcSession);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "SessionForm";
            this.Text = "Session";
            this.pnlBottom.ResumeLayout(false);
            this.tcSession.ResumeLayout(false);
            this.tpSession.ResumeLayout(false);
            this.tpParticipant.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tcSession;
        private System.Windows.Forms.TabPage tpSession;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.ComboBox cbMulticastIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblMulticastIP;
        private System.Windows.Forms.TabPage tpParticipant;
        private System.Windows.Forms.RadioButton rdbViewer;
        private System.Windows.Forms.RadioButton rdbContribuitor;
        private System.Windows.Forms.RadioButton rdbMaster;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.MainMenu mainMenu1;

    }
}