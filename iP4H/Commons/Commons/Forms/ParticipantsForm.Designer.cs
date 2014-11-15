namespace iPH.Commons.Forms
{
    partial class ParticipantsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipantsForm));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmParticipants = new System.Windows.Forms.ContextMenu();
            this.miPing = new System.Windows.Forms.MenuItem();
            this.miClear = new System.Windows.Forms.MenuItem();
            this.miRefresh = new System.Windows.Forms.MenuItem();
            this.ilParticipants = new System.Windows.Forms.ImageList();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlTopInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tvParticipants = new System.Windows.Forms.TreeView();
            this.pnlBottom.SuspendLayout();
            this.pnlTopInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 213);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(201, 26);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOk.Location = new System.Drawing.Point(126, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            // 
            // cmParticipants
            // 
            this.cmParticipants.MenuItems.Add(this.miPing);
            this.cmParticipants.MenuItems.Add(this.miClear);
            this.cmParticipants.MenuItems.Add(this.miRefresh);
            // 
            // miPing
            // 
            this.miPing.Text = "Ping";
            this.miPing.Click += new System.EventHandler(this.miPing_Click);
            // 
            // miClear
            // 
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.miClear_Click);
            // 
            // miRefresh
            // 
            this.miRefresh.Text = "Refresh";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            this.ilParticipants.Images.Clear();
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource8"))));
            this.ilParticipants.Images.Add(((System.Drawing.Image)(resources.GetObject("resource9"))));
            // 
            // pnlTopInfo
            // 
            this.pnlTopInfo.Controls.Add(this.lblInfo);
            this.pnlTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopInfo.Name = "pnlTopInfo";
            this.pnlTopInfo.Size = new System.Drawing.Size(201, 50);
            this.pnlTopInfo.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(3, 4);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(195, 43);
            this.lblInfo.Text = "An error has occurred while attempting to connect to the MoCA/WS. No context info" +
                "rmation is available.";
            // 
            // tvParticipants
            // 
            this.tvParticipants.ContextMenu = this.cmParticipants;
            this.tvParticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvParticipants.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tvParticipants.ImageIndex = 0;
            this.tvParticipants.ImageList = this.ilParticipants;
            this.tvParticipants.Location = new System.Drawing.Point(0, 50);
            this.tvParticipants.Name = "tvParticipants";
            this.tvParticipants.SelectedImageIndex = 0;
            this.tvParticipants.Size = new System.Drawing.Size(201, 163);
            this.tvParticipants.TabIndex = 9;
            // 
            // ParticipantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(201, 239);
            this.ContextMenu = this.cmParticipants;
            this.Controls.Add(this.tvParticipants);
            this.Controls.Add(this.pnlTopInfo);
            this.Controls.Add(this.pnlBottom);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ParticipantsForm";
            this.Text = "Participants";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTopInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenu cmParticipants;
        private System.Windows.Forms.MenuItem miPing;
        private System.Windows.Forms.MenuItem miClear;
        private System.Windows.Forms.MenuItem miRefresh;
        private System.Windows.Forms.ImageList ilParticipants;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Panel pnlTopInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TreeView tvParticipants;
    }
}