using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Forms;

namespace iPH.Commons.Tests.EnergyTestLevel
{
    public partial class EnergyTestForm : Form
    {
        #region Members

        private string pdaDeckFile = "\\My Documents\\deck_100kb.idd";
        private string tpcDeckFile = "c://deck_100kb.idd";

        private int minAnim = 0;
        private int maxAnim = 10;

        private bool sentMainDeck = false;

        private Random rdm = new Random(1);

        private InteractivePresentationForm myForm;
        
        #endregion

        #region Ctors

        public EnergyTestForm(InteractivePresentationForm theForm, int time)
        {
            InitializeComponent();
            this.myForm = theForm;
            this.timerTest.Interval = time;

            this.pbSim.Minimum = minAnim;
            this.pbSim.Maximum = maxAnim;
        }

        #endregion

        #region Methods

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.EnableTimer(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.EnableTimer(false);
        }

        private void EnableTimer(bool flag)
        {
            this.timerTest.Enabled = flag;
            this.btnStart.Enabled = !flag;
            this.btnStop.Enabled = flag;
        }

        private void timerTest_Tick(object sender, EventArgs e)
        {
            this.ExecuteAction();
            if (this.pbSim.Value >= maxAnim)
                this.pbSim.Value = minAnim;            
            else
                this.pbSim.Value += 1;
        }

        private void ExecuteAction()
        {
            /*int command = rdm.Next(6);

            switch (command)
            {
                case 1:
                    //Carregar o deck
                    if (this.myForm.MainDeck.Slides.Count == 0)
                    {
                        if (System.Environment.OSVersion.Platform == PlatformID.WinCE)
                            this.myForm.AppendDeckFromFile(pdaDeckFile);
                        else
                            this.myForm.AppendDeckFromFile(tpcDeckFile);
                    }
                    break;
                case 2:
                    //Sending Deck
                    if (this.myForm.MainDeck.Slides.Count > 0 && !sentMainDeck)
                    {
                        this.myForm.SendMainDeck();
                        sentMainDeck = true;
                    }
                    break;
                case 3:
                    //Send itself
                    this.myForm.SendParticipant();
                    break;
                case 4:
                    //Send ping to participants
                    this.myForm.SendPingToParticipants();
                    break;
                case 5:
                    if (this.myForm.MainDeck.Slides.Count > 0)
                    {
                        int indSlide = rdm.Next(this.myForm.MainDeck.Slides.Count);
                        if (indSlide < 0 || indSlide >= this.myForm.MainDeck.Slides.Count)
                            indSlide = 0;
                        this.myForm.SelectSlideAtMainDeck(this.myForm.MainDeck.Slides[indSlide].Guid, true);
                    }
                    break;
                default:
                    if (this.myForm.MainDeck.Slides.Count > 0)
                    {
                        //Slide
                        int indSlide = rdm.Next(this.myForm.MainDeck.Slides.Count);
                        if (indSlide < 0 || indSlide >= this.myForm.MainDeck.Slides.Count)
                            indSlide = 0;                        
                        //Contribuicoes
                        LAC.Contribution.Contributions cont = new LAC.Contribution.Contributions();
                        int max = rdm.Next(5);
                        for (int i = 0; i < max; i++)
                        {
                            LAC.Contribution.Objects.ContributionBaseObject obj = null;
                            if ((i % 2) == 0)
                            {
                                Point[] points = new Point[10];
                                for (int j = 0; j < 10; j++)
                                {
                                    points[j] = new Point(rdm.Next(this.myForm.SlidePanel.Width), rdm.Next(this.myForm.SlidePanel.Height));
                                }
                                obj = new LAC.Contribution.Objects.Stroke(this.myForm.SlidePanel.Width, this.myForm.SlidePanel.Height, points, Color.Black, 3);
                            }
                            else
                            {
                                obj = new LAC.Contribution.Objects.Text(this.myForm.SlidePanel.Width, this.myForm.SlidePanel.Height, new Point(rdm.Next(this.myForm.SlidePanel.Width), rdm.Next(this.myForm.SlidePanel.Height)), "TEST IPH", new Font("Tahoma", 10, FontStyle.Regular), Color.Black);
                            }
                            cont.InsertContribution(obj, true);
                        }
                        this.myForm.AddContributions(this.myForm.MainDeck.Slides[indSlide].Guid, cont);
                    }
                    break;                                
            }
             */
        }

        #endregion
    }
}