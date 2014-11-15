namespace CCXP.Capabilities.CP.Chat
{
    partial class ChatFMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpChat = new System.Windows.Forms.TabPage();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.TextBox();
            this.textReceive = new System.Windows.Forms.TextBox();
            this.tpConn = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpChat.SuspendLayout();
            this.tpConn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpChat);
            this.tabControl1.Controls.Add(this.tpConn);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 1;
            // 
            // tpChat
            // 
            this.tpChat.Controls.Add(this.buttonSend);
            this.tpChat.Controls.Add(this.textSend);
            this.tpChat.Controls.Add(this.textReceive);
            this.tpChat.Location = new System.Drawing.Point(4, 25);
            this.tpChat.Name = "tpChat";
            this.tpChat.Size = new System.Drawing.Size(232, 239);
            this.tpChat.Text = "Chat";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(195, 198);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(34, 38);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "OK";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textSend
            // 
            this.textSend.Location = new System.Drawing.Point(4, 198);
            this.textSend.Multiline = true;
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(185, 38);
            this.textSend.TabIndex = 2;
            // 
            // textReceive
            // 
            this.textReceive.Dock = System.Windows.Forms.DockStyle.Top;
            this.textReceive.Location = new System.Drawing.Point(0, 0);
            this.textReceive.Multiline = true;
            this.textReceive.Name = "textReceive";
            this.textReceive.ReadOnly = true;
            this.textReceive.Size = new System.Drawing.Size(232, 192);
            this.textReceive.TabIndex = 1;
            // 
            // tpConn
            // 
            this.tpConn.Controls.Add(this.txtName);
            this.tpConn.Controls.Add(this.btnConnect);
            this.tpConn.Controls.Add(this.txtConnect);
            this.tpConn.Location = new System.Drawing.Point(4, 25);
            this.tpConn.Name = "tpConn";
            this.tpConn.Size = new System.Drawing.Size(232, 239);
            this.tpConn.Text = "Connection";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 7);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 22);
            this.txtName.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 35);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(71, 21);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect!";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(7, 62);
            this.txtConnect.Multiline = true;
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.ReadOnly = true;
            this.txtConnect.Size = new System.Drawing.Size(222, 169);
            this.txtConnect.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 268);
            // 
            // ChatFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "ChatFMain";
            this.Text = "Chat";
            this.tabControl1.ResumeLayout(false);
            this.tpChat.ResumeLayout(false);
            this.tpConn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpChat;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textSend;
        private System.Windows.Forms.TextBox textReceive;
        private System.Windows.Forms.TabPage tpConn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.TextBox txtName;

    }
}