namespace CCXP.Capabilities.CP.Ink
{
    partial class InkFMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnChangeControl = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.sbConnection = new System.Windows.Forms.StatusBar();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnMacAddress = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMacAddress);
            this.panel1.Controls.Add(this.btnColor);
            this.panel1.Controls.Add(this.btnChangeControl);
            this.panel1.Controls.Add(this.btnPing);
            this.panel1.Controls.Add(this.txtNick);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 29);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(303, 3);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(63, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Color";
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnChangeControl
            // 
            this.btnChangeControl.Location = new System.Drawing.Point(230, 3);
            this.btnChangeControl.Name = "btnChangeControl";
            this.btnChangeControl.Size = new System.Drawing.Size(63, 23);
            this.btnChangeControl.TabIndex = 3;
            this.btnChangeControl.Text = "Change";
            this.btnChangeControl.Click += new System.EventHandler(this.btnChangeControl_Click);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(161, 3);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(63, 23);
            this.btnPing.TabIndex = 2;
            this.btnPing.Text = "Ping!";
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(3, 3);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(85, 23);
            this.txtNick.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(94, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(63, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // sbConnection
            // 
            this.sbConnection.Location = new System.Drawing.Point(0, 296);
            this.sbConnection.Name = "sbConnection";
            this.sbConnection.Size = new System.Drawing.Size(570, 24);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 29);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(570, 267);
            // 
            // btnMacAddress
            // 
            this.btnMacAddress.Location = new System.Drawing.Point(372, 3);
            this.btnMacAddress.Name = "btnMacAddress";
            this.btnMacAddress.Size = new System.Drawing.Size(63, 23);
            this.btnMacAddress.TabIndex = 5;
            this.btnMacAddress.Text = "MAC";
            this.btnMacAddress.Click += new System.EventHandler(this.btnMacAddress_Click);
            // 
            // InkFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(570, 320);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.sbConnection);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "InkFMain";
            this.Text = "InkFMain";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.StatusBar sbConnection;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button btnChangeControl;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnMacAddress;
    }
}