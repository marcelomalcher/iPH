using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Forms;

namespace iPH.Commons.Tests
{
    public partial class CommTestForm : Form
    {
        #region Members

        private int number = 0;

        private int totalNumber;

        private int typeTest = 0; //0-Deck;1-Sync;2=Subm

        private bool drawContrib = true;

        private InteractivePresentationForm myForm;
        
        #endregion

        public CommTestForm(InteractivePresentationForm theForm, int time, int messageNumber, int typeTest)
        {
            InitializeComponent();

            this.myForm = theForm;

            this.numericUpDown1.Value = time;
            this.timerTest.Interval = time;

            this.totalNumber = messageNumber;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = messageNumber;

            this.typeTest = typeTest;
            if (typeTest == 0)
                lblType.Text = "Deck Test";
            else if (typeTest == 1)
                lblType.Text = "Sync Test";
            else if (typeTest == 2)
                lblType.Text = "Submit Test";
            else
                throw new Exception("Tipo de teste inválido");

            this.lblNM.Text = messageNumber.ToString();
        }

        private void timerTest_Tick(object sender, EventArgs e)
        {
            this.DoAction(typeTest);
            
            this.number += 1;
            this.progressBar1.Value += 1;
            int numberLeft = this.totalNumber - this.number;
            this.lblNM.Text = numberLeft.ToString();

            if (number >= totalNumber)
                this.EnableTimer(false);
        }

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

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                TestManager manager = TestManager.getInstance();
                manager.CreateFile(sfdResult.FileName);
            }            
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.timerTest.Interval = (int)this.numericUpDown1.Value;
        }

        private void DoAction(int type)
        {
            if (type == 0)
                this.DoDeckTest();
            else if (type == 1)
                this.DoSyncTest();
            else if (type == 2)
                this.DoSubmitTest();            
        }

        private void DoDeckTest()
        {
            //this.myForm.SendMainDeck();
        }

        private void DoSyncTest()
        {
            //this.myForm.SendNextSelectSlide();           
        }

        private void DoSubmitTest()
        {
            /*if (drawContrib)
            {
                LAC.Contribution.Contributions cont = new LAC.Contribution.Contributions();

                Point[] points = new Point[4];
                points[0] = new Point(10, 10);
                points[1] = new Point(this.myForm.SlidePanel.Width - 10, 10);
                points[2] = new Point(this.myForm.SlidePanel.Width - 10, this.myForm.SlidePanel.Height - 10);
                points[3] = new Point(10, this.myForm.SlidePanel.Height - 10);

                LAC.Contribution.Objects.Stroke stroke = new LAC.Contribution.Objects.Stroke(this.myForm.SlidePanel.Width, this.myForm.SlidePanel.Height, points, Color.Black, 3);

                LAC.Contribution.Objects.Text text = new LAC.Contribution.Objects.Text(this.myForm.SlidePanel.Width, this.myForm.SlidePanel.Height, new Point((int)Math.Round((double)(this.myForm.SlidePanel.Width / 2)), (int)Math.Round((double)(this.myForm.SlidePanel.Height / 2))), "LAC iPH", new Font("Tahoma", 10, FontStyle.Regular), Color.Black);

                cont.InsertContribution(stroke, false);

                cont.InsertContribution(text, false);

                this.myForm.AddContributions(this.myForm.CurrentSlide.Guid, cont);
            }
            drawContrib = false;

            //
            this.myForm.SendSubmissionToMaster();
             */ 
        }
    }
}