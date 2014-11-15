using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.User;
using iPH.Commons.User.Role;

using LAC.ContextInformation;

namespace iPH.Commons.Forms
{
    public partial class ParticipantsForm : Form
    {
        #region Constants

        private const int IMAGE_INDEX_PARTICIPANT = 0;
        private const int IMAGE_INDEX_VIEWER = 1;

        private const int IMAGE_INDEX_AREA = 2;
        private const int IMAGE_INDEX_CPU_USAGE = 3;
        private const int IMAGE_INDEX_ENERGY_LEVEL = 4;
        private const int IMAGE_INDEX_FREE_MEMORY = 5;
        private const int IMAGE_INDEX_IP_ADDRESS = 6;
        private const int IMAGE_INDEX_IP_MASK = 7;
        private const int IMAGE_INDEX_MAC_ADDRESS = 8;
        private const int IMAGE_INDEX_CURRENT_AP = 9;

        #endregion

        #region Members

        private InteractivePresentationForm myForm;

        #endregion

        #region Ctor

        private ParticipantsForm()
        {
            InitializeComponent();
        }

        public ParticipantsForm(InteractivePresentationForm form)
            : this()
        {
            this.myForm = form;
            //Calling show data
            this.ShowData();
        }

        #endregion

        #region Methods

        private void ShowData()
        {
            ContextWrapper contextWrapper = null;

            //Clearing tree view
            this.tvParticipants.Nodes.Clear();

            bool connected = false;
            //Used to access MoCA Web Service            
            try
            {
                contextWrapper = new ContextWrapper(this.myForm.Configuration.MocaWebServiceURL);
                connected = contextWrapper.isConnected();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error has occurred while creating the wrapper object to connect to the MoCA/WS: " + e.Message, "Information");
            }                         
            
            //Error panel
            this.pnlTopInfo.Visible = !connected;
            
            //Iterating through participants
            foreach (Participant p in this.myForm.ParticipantsManager.List)
            {
                //Getting the specific device context...
                DeviceContext dvcContext = null;
                string area = "N/A";
                try
                {
                    if (connected)
                    {
                        dvcContext = contextWrapper != null ? contextWrapper.GetDeviceContext(p.MacAddress) : null;
                        area = contextWrapper != null ? contextWrapper.GetAreaFromDevice(p.MacAddress) : "N/A";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show("Error while recovering device context information.\n" + e.Message, "Information");
                }

                //Adding Node
                TreeNode participantNode = new TreeNode(p.NickName);
                int participantImageIndex = IMAGE_INDEX_PARTICIPANT;
                if (p.Role.GetType().Equals(Contribuitor.Instance.GetType()))
                {
                    participantImageIndex = IMAGE_INDEX_PARTICIPANT;
                }
                else if (p.Role.GetType().Equals(Viewer.Instance.GetType()))
                {
                    participantImageIndex = IMAGE_INDEX_VIEWER;
                }
                participantNode.ImageIndex = participantImageIndex;
                participantNode.SelectedImageIndex = participantImageIndex;

                TreeNode contextInformationNode;

                contextInformationNode = new TreeNode();                
                contextInformationNode.Text = "Area: " + area;
                contextInformationNode.ImageIndex = IMAGE_INDEX_AREA;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_AREA;
                participantNode.Nodes.Add(contextInformationNode);
                                
                string information = "Unknown"; 

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.CpuUsage.ToString() + " %" : "N/A"; 
                contextInformationNode.Text = "CPU Usage: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_CPU_USAGE;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_CPU_USAGE;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.EnergyLevel.ToString() + " %" : "N/A";
                contextInformationNode.Text = "Energy Level: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_ENERGY_LEVEL;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_ENERGY_LEVEL;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.FreeMemory.ToString() + " KBs" : "N/A";
                contextInformationNode.Text = "Free Memory: " + information ;
                contextInformationNode.ImageIndex = IMAGE_INDEX_FREE_MEMORY;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_FREE_MEMORY;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.MobileHostIPAddress : "N/A";
                contextInformationNode.Text = "IP Address: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_IP_ADDRESS;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_IP_ADDRESS;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.NetworkMask : "N/A";
                contextInformationNode.Text = "IP Mask: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_IP_MASK;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_IP_MASK;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.MobileHostIPAddress : "N/A";
                contextInformationNode.Text = "MAC Address: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_MAC_ADDRESS;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_MAC_ADDRESS;
                participantNode.Nodes.Add(contextInformationNode);

                contextInformationNode = new TreeNode();
                information = dvcContext != null ? dvcContext.CurrentAPMacAddress : "N/A";
                contextInformationNode.Text = "Current A. P.: " + information;
                contextInformationNode.ImageIndex = IMAGE_INDEX_CURRENT_AP;
                contextInformationNode.SelectedImageIndex = IMAGE_INDEX_CURRENT_AP;
                participantNode.Nodes.Add(contextInformationNode);

                //Adding node to tree view
                this.tvParticipants.Nodes.Add(participantNode);
            }
            this.tvParticipants.Refresh();
        }

        #endregion

        #region Context menu events

        private void miClear_Click(object sender, EventArgs e)
        {
            //
            this.myForm.ParticipantsManager.Clear();
            //
            this.ShowData();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            //
            this.ShowData();
        }

        private void miPing_Click(object sender, EventArgs e)
        {
            //
            this.myForm.SendPingToParticipants();            
        }

        #endregion
    }
}