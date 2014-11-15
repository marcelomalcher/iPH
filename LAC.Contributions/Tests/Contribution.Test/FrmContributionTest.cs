using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAC.Contribution;

namespace Contribution.Test
{
    public partial class FrmContributionTest : Form
    {
        private ContributionManager manager;

        public FrmContributionTest()
        {
            InitializeComponent();
            
            manager = new ContributionManager(panelBoard);
            manager.Enabled = true;
        }       
    }
}