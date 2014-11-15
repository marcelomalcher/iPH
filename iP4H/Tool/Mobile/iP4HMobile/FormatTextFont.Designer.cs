namespace iPH.Tool.Mobile
{
    partial class FormatTextFont
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcSession = new System.Windows.Forms.TabControl();
            this.tpFont = new System.Windows.Forms.TabPage();
            this.rdbTahoma = new System.Windows.Forms.RadioButton();
            this.rdbArial = new System.Windows.Forms.RadioButton();
            this.nupSize = new System.Windows.Forms.NumericUpDown();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblMulticastIP = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlBottom.SuspendLayout();
            this.tcSession.SuspendLayout();
            this.tpFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 170);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(183, 26);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnCancel.Location = new System.Drawing.Point(108, 3);
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
            this.btnOk.Location = new System.Drawing.Point(30, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tcSession
            // 
            this.tcSession.Controls.Add(this.tpFont);
            this.tcSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSession.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tcSession.Location = new System.Drawing.Point(0, 0);
            this.tcSession.Name = "tcSession";
            this.tcSession.SelectedIndex = 0;
            this.tcSession.Size = new System.Drawing.Size(183, 170);
            this.tcSession.TabIndex = 4;
            // 
            // tpFont
            // 
            this.tpFont.Controls.Add(this.rdbTahoma);
            this.tpFont.Controls.Add(this.rdbArial);
            this.tpFont.Controls.Add(this.nupSize);
            this.tpFont.Controls.Add(this.lblSize);
            this.tpFont.Controls.Add(this.lblMulticastIP);
            this.tpFont.Location = new System.Drawing.Point(4, 22);
            this.tpFont.Name = "tpFont";
            this.tpFont.Size = new System.Drawing.Size(175, 144);
            this.tpFont.Text = "Font Name & Size";
            // 
            // rdbTahoma
            // 
            this.rdbTahoma.Checked = true;
            this.rdbTahoma.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rdbTahoma.Location = new System.Drawing.Point(18, 52);
            this.rdbTahoma.Name = "rdbTahoma";
            this.rdbTahoma.Size = new System.Drawing.Size(100, 20);
            this.rdbTahoma.TabIndex = 12;
            this.rdbTahoma.Text = "Tahoma";
            // 
            // rdbArial
            // 
            this.rdbArial.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.rdbArial.Location = new System.Drawing.Point(18, 27);
            this.rdbArial.Name = "rdbArial";
            this.rdbArial.Size = new System.Drawing.Size(100, 20);
            this.rdbArial.TabIndex = 11;
            this.rdbArial.TabStop = false;
            this.rdbArial.Text = "Arial";
            // 
            // nupSize
            // 
            this.nupSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.nupSize.Location = new System.Drawing.Point(14, 107);
            this.nupSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupSize.Name = "nupSize";
            this.nupSize.Size = new System.Drawing.Size(74, 20);
            this.nupSize.TabIndex = 4;
            this.nupSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSize.Location = new System.Drawing.Point(3, 84);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 20);
            this.lblSize.Text = "Size:";
            // 
            // lblMulticastIP
            // 
            this.lblMulticastIP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMulticastIP.Location = new System.Drawing.Point(3, 6);
            this.lblMulticastIP.Name = "lblMulticastIP";
            this.lblMulticastIP.Size = new System.Drawing.Size(85, 20);
            this.lblMulticastIP.Text = "Font:";
            // 
            // FormatTextFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(183, 196);
            this.Controls.Add(this.tcSession);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "FormatTextFont";
            this.Text = "Choose Font...";
            this.pnlBottom.ResumeLayout(false);
            this.tcSession.ResumeLayout(false);
            this.tpFont.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tcSession;
        private System.Windows.Forms.TabPage tpFont;
        private System.Windows.Forms.NumericUpDown nupSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblMulticastIP;
        private System.Windows.Forms.RadioButton rdbTahoma;
        private System.Windows.Forms.RadioButton rdbArial;
        private System.Windows.Forms.MainMenu mainMenu1;

    }
}