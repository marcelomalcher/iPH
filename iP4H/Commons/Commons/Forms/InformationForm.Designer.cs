namespace iPH.Commons.Forms
{
    partial class InformationForm
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcInfo = new System.Windows.Forms.TabControl();
            this.tpDevice = new System.Windows.Forms.TabPage();
            this.pbEnergyLevel = new System.Windows.Forms.ProgressBar();
            this.pbCPUUsage = new System.Windows.Forms.ProgressBar();
            this.lblAreaValue = new System.Windows.Forms.Label();
            this.lblEnergyLevelValue = new System.Windows.Forms.Label();
            this.lblFreeMemoryValue = new System.Windows.Forms.Label();
            this.lblCpuUsageValue = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblEnergyLevel = new System.Windows.Forms.Label();
            this.lblFreeMemory = new System.Windows.Forms.Label();
            this.lblCpuUsage = new System.Windows.Forms.Label();
            this.tpNetwork = new System.Windows.Forms.TabPage();
            this.lblCurrentAPValue = new System.Windows.Forms.Label();
            this.lblCurrentAP = new System.Windows.Forms.Label();
            this.lblMACAddressValue = new System.Windows.Forms.Label();
            this.lblMACAddress = new System.Windows.Forms.Label();
            this.lblIPMaskValue = new System.Windows.Forms.Label();
            this.lblIPMask = new System.Windows.Forms.Label();
            this.lblIPAddressValue = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlBottom.SuspendLayout();
            this.tcInfo.SuspendLayout();
            this.tpDevice.SuspendLayout();
            this.tpNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 182);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(192, 26);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRefresh.Location = new System.Drawing.Point(4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 20);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOk.Location = new System.Drawing.Point(117, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 20);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            // 
            // tcInfo
            // 
            this.tcInfo.Controls.Add(this.tpDevice);
            this.tcInfo.Controls.Add(this.tpNetwork);
            this.tcInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tcInfo.Location = new System.Drawing.Point(0, 0);
            this.tcInfo.Name = "tcInfo";
            this.tcInfo.SelectedIndex = 0;
            this.tcInfo.Size = new System.Drawing.Size(192, 182);
            this.tcInfo.TabIndex = 1;
            // 
            // tpDevice
            // 
            this.tpDevice.Controls.Add(this.pbEnergyLevel);
            this.tpDevice.Controls.Add(this.pbCPUUsage);
            this.tpDevice.Controls.Add(this.lblAreaValue);
            this.tpDevice.Controls.Add(this.lblEnergyLevelValue);
            this.tpDevice.Controls.Add(this.lblFreeMemoryValue);
            this.tpDevice.Controls.Add(this.lblCpuUsageValue);
            this.tpDevice.Controls.Add(this.lblArea);
            this.tpDevice.Controls.Add(this.lblEnergyLevel);
            this.tpDevice.Controls.Add(this.lblFreeMemory);
            this.tpDevice.Controls.Add(this.lblCpuUsage);
            this.tpDevice.Location = new System.Drawing.Point(4, 22);
            this.tpDevice.Name = "tpDevice";
            this.tpDevice.Size = new System.Drawing.Size(184, 156);
            this.tpDevice.Text = "Device";
            // 
            // pbEnergyLevel
            // 
            this.pbEnergyLevel.Location = new System.Drawing.Point(7, 72);
            this.pbEnergyLevel.Name = "pbEnergyLevel";
            this.pbEnergyLevel.Size = new System.Drawing.Size(174, 18);
            // 
            // pbCPUUsage
            // 
            this.pbCPUUsage.Location = new System.Drawing.Point(7, 30);
            this.pbCPUUsage.Name = "pbCPUUsage";
            this.pbCPUUsage.Size = new System.Drawing.Size(174, 18);
            // 
            // lblAreaValue
            // 
            this.lblAreaValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblAreaValue.Location = new System.Drawing.Point(90, 128);
            this.lblAreaValue.Name = "lblAreaValue";
            this.lblAreaValue.Size = new System.Drawing.Size(91, 18);
            // 
            // lblEnergyLevelValue
            // 
            this.lblEnergyLevelValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblEnergyLevelValue.Location = new System.Drawing.Point(90, 54);
            this.lblEnergyLevelValue.Name = "lblEnergyLevelValue";
            this.lblEnergyLevelValue.Size = new System.Drawing.Size(91, 18);
            // 
            // lblFreeMemoryValue
            // 
            this.lblFreeMemoryValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFreeMemoryValue.Location = new System.Drawing.Point(90, 103);
            this.lblFreeMemoryValue.Name = "lblFreeMemoryValue";
            this.lblFreeMemoryValue.Size = new System.Drawing.Size(91, 18);
            // 
            // lblCpuUsageValue
            // 
            this.lblCpuUsageValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCpuUsageValue.Location = new System.Drawing.Point(90, 12);
            this.lblCpuUsageValue.Name = "lblCpuUsageValue";
            this.lblCpuUsageValue.Size = new System.Drawing.Size(91, 18);
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblArea.Location = new System.Drawing.Point(7, 128);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(77, 18);
            this.lblArea.Text = "Area:";
            // 
            // lblEnergyLevel
            // 
            this.lblEnergyLevel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblEnergyLevel.Location = new System.Drawing.Point(7, 54);
            this.lblEnergyLevel.Name = "lblEnergyLevel";
            this.lblEnergyLevel.Size = new System.Drawing.Size(77, 18);
            this.lblEnergyLevel.Text = "Energy Level:";
            // 
            // lblFreeMemory
            // 
            this.lblFreeMemory.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFreeMemory.Location = new System.Drawing.Point(7, 103);
            this.lblFreeMemory.Name = "lblFreeMemory";
            this.lblFreeMemory.Size = new System.Drawing.Size(77, 18);
            this.lblFreeMemory.Text = "Free Memory:";
            // 
            // lblCpuUsage
            // 
            this.lblCpuUsage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCpuUsage.Location = new System.Drawing.Point(7, 12);
            this.lblCpuUsage.Name = "lblCpuUsage";
            this.lblCpuUsage.Size = new System.Drawing.Size(77, 18);
            this.lblCpuUsage.Text = "CPU Usage:";
            // 
            // tpNetwork
            // 
            this.tpNetwork.Controls.Add(this.lblCurrentAPValue);
            this.tpNetwork.Controls.Add(this.lblCurrentAP);
            this.tpNetwork.Controls.Add(this.lblMACAddressValue);
            this.tpNetwork.Controls.Add(this.lblMACAddress);
            this.tpNetwork.Controls.Add(this.lblIPMaskValue);
            this.tpNetwork.Controls.Add(this.lblIPMask);
            this.tpNetwork.Controls.Add(this.lblIPAddressValue);
            this.tpNetwork.Controls.Add(this.lblIPAddress);
            this.tpNetwork.Location = new System.Drawing.Point(4, 22);
            this.tpNetwork.Name = "tpNetwork";
            this.tpNetwork.Size = new System.Drawing.Size(184, 156);
            this.tpNetwork.Text = "Network";
            // 
            // lblCurrentAPValue
            // 
            this.lblCurrentAPValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCurrentAPValue.Location = new System.Drawing.Point(78, 121);
            this.lblCurrentAPValue.Name = "lblCurrentAPValue";
            this.lblCurrentAPValue.Size = new System.Drawing.Size(103, 18);
            // 
            // lblCurrentAP
            // 
            this.lblCurrentAP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCurrentAP.Location = new System.Drawing.Point(7, 121);
            this.lblCurrentAP.Name = "lblCurrentAP";
            this.lblCurrentAP.Size = new System.Drawing.Size(65, 18);
            this.lblCurrentAP.Text = "Current AP:";
            // 
            // lblMACAddressValue
            // 
            this.lblMACAddressValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMACAddressValue.Location = new System.Drawing.Point(78, 78);
            this.lblMACAddressValue.Name = "lblMACAddressValue";
            this.lblMACAddressValue.Size = new System.Drawing.Size(103, 18);
            // 
            // lblMACAddress
            // 
            this.lblMACAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMACAddress.Location = new System.Drawing.Point(7, 78);
            this.lblMACAddress.Name = "lblMACAddress";
            this.lblMACAddress.Size = new System.Drawing.Size(65, 29);
            this.lblMACAddress.Text = "MAC Address:";
            // 
            // lblIPMaskValue
            // 
            this.lblIPMaskValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIPMaskValue.Location = new System.Drawing.Point(78, 38);
            this.lblIPMaskValue.Name = "lblIPMaskValue";
            this.lblIPMaskValue.Size = new System.Drawing.Size(103, 18);
            // 
            // lblIPMask
            // 
            this.lblIPMask.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIPMask.Location = new System.Drawing.Point(7, 38);
            this.lblIPMask.Name = "lblIPMask";
            this.lblIPMask.Size = new System.Drawing.Size(65, 18);
            this.lblIPMask.Text = "Mask:";
            // 
            // lblIPAddressValue
            // 
            this.lblIPAddressValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIPAddressValue.Location = new System.Drawing.Point(78, 12);
            this.lblIPAddressValue.Name = "lblIPAddressValue";
            this.lblIPAddressValue.Size = new System.Drawing.Size(103, 18);
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblIPAddress.Location = new System.Drawing.Point(7, 12);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(65, 18);
            this.lblIPAddress.Text = "IP Address:";
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(192, 208);
            this.Controls.Add(this.tcInfo);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "InformationForm";
            this.Text = "Informations...";
            this.pnlBottom.ResumeLayout(false);
            this.tcInfo.ResumeLayout(false);
            this.tpDevice.ResumeLayout(false);
            this.tpNetwork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tcInfo;
        private System.Windows.Forms.TabPage tpDevice;
        private System.Windows.Forms.TabPage tpNetwork;
        private System.Windows.Forms.Label lblAreaValue;
        private System.Windows.Forms.Label lblEnergyLevelValue;
        private System.Windows.Forms.Label lblFreeMemoryValue;
        private System.Windows.Forms.Label lblCpuUsageValue;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblEnergyLevel;
        private System.Windows.Forms.Label lblFreeMemory;
        private System.Windows.Forms.Label lblCpuUsage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCurrentAPValue;
        private System.Windows.Forms.Label lblCurrentAP;
        private System.Windows.Forms.Label lblMACAddressValue;
        private System.Windows.Forms.Label lblMACAddress;
        private System.Windows.Forms.Label lblIPMaskValue;
        private System.Windows.Forms.Label lblIPMask;
        private System.Windows.Forms.Label lblIPAddressValue;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.ProgressBar pbEnergyLevel;
        private System.Windows.Forms.ProgressBar pbCPUUsage;
        private System.Windows.Forms.MainMenu mainMenu1;
    }
}