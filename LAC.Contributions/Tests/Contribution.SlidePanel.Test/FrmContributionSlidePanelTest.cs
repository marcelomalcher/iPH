using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iP4H.Commons.SlideControl;
using LAC.Contribution;

namespace Contribution.SlidePanel.Test
{
    public partial class FrmContributionSlidePanelTest : Form
    {

        iP4H.Commons.SlideControl.SlidePanel slidePanel;
        iP4H.Commons.SlideControl.PresentationSlide presentationSlide;

        ContributionManager contribution;

        public FrmContributionSlidePanelTest()
        {
            InitializeComponent();
            InitializeSlide();
            InitializeContribution();
        }

        private void InitializeSlide()
        {
            this.slidePanel = new iP4H.Commons.SlideControl.SlidePanel();
            this.slidePanel.Parent = this;
            this.slidePanel.Dock = DockStyle.Fill;

            this.presentationSlide = new PresentationSlide();
            this.presentationSlide.BoardColor = Color.Wheat;
            this.presentationSlide.Image = new Bitmap("C://Marcelo//PUC//Computação Móvel//Monografia//AN//app//Slides//Main//Slide1.jpg");

            this.slidePanel.Clear();
            this.slidePanel.Slide = this.presentationSlide;
            this.slidePanel.Refresh();
        }

        private void InitializeContribution()
        {
            this.contribution = new ContributionManager(this.slidePanel);
            this.contribution.Enabled = true;
            this.contribution.InkColor = Color.Aquamarine;
            this.contribution.InkWidth = 10;

            this.slidePanel.Manager = this.contribution;
        }
    }
}