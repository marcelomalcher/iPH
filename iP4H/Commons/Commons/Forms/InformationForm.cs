using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using iPH.Commons.Configuration;
using iPH.Commons.User;

using LAC.ContextInformation;

namespace iPH.Commons.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InformationForm : Form
    {
        #region Members

        private string myMocaWebServiceURL;

        private string myMacAddress;

        private bool isSearching = false;

        #endregion

        #region Constructors

        private InformationForm()
        {
            InitializeComponent();
        }

        public InformationForm(string mocaWebServiceURL, string macAddress)
            : this()
        {
            this.myMocaWebServiceURL = mocaWebServiceURL;
            this.myMacAddress = macAddress;
            //Updating
            this.ShowDeviceData();
        }

        #endregion

        #region Methods

        private void ShowDeviceData()
        {
            Thread deviceThread = new Thread(new ThreadStart(ContextDeviceThread));
            deviceThread.Name = "Context Device Information Thread";
            deviceThread.IsBackground = true;
            deviceThread.Start();
        }

        private void ContextDeviceThread()
        {
            this.isSearching = true;

            ContextWrapper contextWrapper = null;
            bool connected = false;
            //Used to access MoCA Web Service            
            try
            {
                contextWrapper = new ContextWrapper(this.myMocaWebServiceURL);
                connected = contextWrapper.isConnected();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error has occurred while creating the wrapper object to connect to the MoCA/WS: " + e.Message, "Information");
            }

            if (!connected)
            {
                MessageBox.Show("An error has occurred while attempting to connect to the MoCA/WS. No context information is available.", "Information");
            }

            //Getting the specific device context...
            DeviceContext dvcContext = null;
            string area = "N/A";
            try
            {
                if (connected)
                {
                    dvcContext = contextWrapper != null ? contextWrapper.GetDeviceContext(this.myMacAddress) : null;
                    area = contextWrapper != null ? contextWrapper.GetAreaFromDevice(this.myMacAddress) : "N/A";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error while recovering device context information.\n" + e.Message, "Information");
            }
            //Device Tab
            
            string cpuUsageText = dvcContext != null ? dvcContext.CpuUsage.ToString() + " %" : "N/A";
            int cpuUsage = dvcContext != null ? dvcContext.CpuUsage : 0;
            string energyLevelText = dvcContext != null ? dvcContext.EnergyLevel.ToString() + " %" : "N/A";
            int energyLevel = dvcContext != null ? dvcContext.EnergyLevel : 0;
            string freeMemory = dvcContext != null ? dvcContext.FreeMemory.ToString() + " KBs" : "N/A";
            //Network Tab
            string ipAddress = dvcContext != null ? dvcContext.MobileHostIPAddress : "N/A";
            string networkMask = dvcContext != null ? dvcContext.NetworkMask : "N/A";
            string macAddress = dvcContext != null ? dvcContext.MobileHostMacAddress : "N/A";
            string currentAPMacAddress = dvcContext != null ? dvcContext.CurrentAPMacAddress : "N/A";
            //
            this.isSearching = false;
            
            //Updating controls..
            this.UpdateControls(cpuUsageText, cpuUsage, energyLevelText, energyLevel, freeMemory, area, ipAddress, networkMask, macAddress, currentAPMacAddress);
        }

        private delegate void UpdateControlsDelegate(string cpuUsageText, int cpuUsage,
                                    string energyLevelText, int energyLevel,
                                    string freeMemory,
                                    string area,
                                    string ipAddress, string networkMask, string macAddress, string currentAPMacAddress);
        private void UpdateControls(string cpuUsageText, int cpuUsage, 
                                    string energyLevelText, int energyLevel,
                                    string freeMemory,
                                    string area,
                                    string ipAddress, string networkMask, string macAddress, string currentAPMacAddress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsDelegate(UpdateControls), new Object[] { cpuUsageText, cpuUsage, energyLevelText, energyLevel, freeMemory, area, ipAddress, networkMask, macAddress, currentAPMacAddress });
                return;
            }

            lblCpuUsageValue.Text = cpuUsageText;
            pbCPUUsage.Value = cpuUsage;
            lblEnergyLevelValue.Text = energyLevelText;
            pbEnergyLevel.Value = energyLevel;
            lblFreeMemoryValue.Text = freeMemory;
            lblAreaValue.Text = area;
            //Network Tab
            lblIPAddressValue.Text = ipAddress;
            lblIPMaskValue.Text = networkMask;
            lblMACAddressValue.Text = macAddress;
            lblCurrentAPValue.Text = currentAPMacAddress;
        }

        #endregion

        #region Button Clicks

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!isSearching)
                this.ShowDeviceData();
        }

        #endregion
    }
}