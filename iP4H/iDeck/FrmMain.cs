using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using iPH.Commons.Presentation;
using iPH.Commons.Presentation.Controls;
using iPH.Commons.Presentation.Arguments;
using LAC.Functions.Forms;
using CompactFormatter;

namespace iPH.iDeck
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class FrmMain : Form
    {
        #region Members

        private const string IDECK_NAME = "iDeck";

        private Deck workDeck;

        private Deck savedDeck;

        private DeckPanel myDeckPanel;
            
        private SlidePanel mySlidePanel;

        private Slide currentSlide;

        private Slide copySlide = null;

        private Color currentColor = Color.Wheat;

        private const string SLIDEIMGEXT = "jpg";
        private const int SLIDEWIDTH = 800;
        private const int SLIDEHEIGHT = 600;
        private Size slideSize = new Size(SLIDEWIDTH, SLIDEHEIGHT);

        private string deckFileOpened = "";

        #endregion

        #region Ctors

        public FrmMain()
        {
            InitializeComponent();
            InitializePanel();
            InitializeDeck();
        }

        #endregion

        #region Initializer

        public void InitializePanel()
        {
            myDeckPanel = new DeckPanel();
            myDeckPanel.Parent = containerMain.Panel1;
            myDeckPanel.Dock = DockStyle.Fill;
            myDeckPanel.SelectedSlideEvent += new DeckPanel.SelectedSlideEventHandler(this.SelectedSlide);

            mySlidePanel = new SlidePanel();
            mySlidePanel.Parent = containerMain.Panel2;
            mySlidePanel.Dock = DockStyle.Fill;
        }

        #endregion

        #region Deck Operations

        public void InitializeDeck()
        {
            //New instance of Deck
            workDeck = new Deck();
            //Clear deck panel...
            myDeckPanel.Clear();
            myDeckPanel.Deck = workDeck;
            //Clear slide panel...
            mySlidePanel.Clear();
            //Copying deck to compare when closing 
            savedDeck = (Deck)workDeck.Clone();          
            //Deck File name 
            deckFileOpened = "";            
            //Updating current slide in panel
            this.UpdateCurrentSlide(null, true, false);
        }

        /// <summary>
        /// Closes current deck, saving if the deck was modified, and creating a new deck to work.
        /// </summary>
        /// <returns>Returns true if deck was closed, and false if not.</returns>
        public bool CloseDeck()
        {
            if (workDeck.Equals(savedDeck) || this.currentSlide == null)
            {
                this.InitializeDeck();
                return true;
            }
            
            DialogResult result = MessageBox.Show("Save current Deck?", IDECK_NAME, MessageBoxButtons.YesNoCancel);
            
            switch (result)
            {
                case DialogResult.Yes:
                    SaveDeck(false);
                    InitializeDeck();
                    return true;
                case DialogResult.No:
                    InitializeDeck();
                    return true;
                default:
                    return false;
            }
        }

        public void SaveDeck(bool newFile)
        {
            string fileName = "";
            if ((newFile && this.deckFileOpened == "") || (!newFile))
            {
                sfdIDD.FileName = this.deckFileOpened;
                if (sfdIDD.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfdIDD.FileName;
                }
                else
                    return;
            }
            else
            {
                fileName = this.deckFileOpened;
            }
            //Deck.SaveToFile(this.workDeck, fileName);
            FileStream fs = new FileStream(fileName, FileMode.Create);            
            BinaryWriter br = new BinaryWriter(fs);
            this.workDeck.SaveDeckToWriter(br);
            br.Close();
            fs.Close();
            //
            this.savedDeck = (Deck)this.workDeck.Clone();
            this.deckFileOpened = fileName;
        }

        public void LoadDeck(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            this.workDeck = Deck.GetDeckFromReader(br);
            br.Close();
            fs.Close();
            this.savedDeck = (Deck)workDeck.Clone();
            this.myDeckPanel.Deck = this.workDeck;
            this.deckFileOpened = fileName;            
            this.UpdateCurrentSlide(this.workDeck.Slides[0], true, false);
        }

        public void InsertSlide(int index, Slide s)
        {
            this.workDeck.Slides.InsertSlide(index, s);
        }

        public int AddSlide(Slide slide)
        {
            slide.BoardColor = this.currentColor;
            InputBoxForm inputBox = new InputBoxForm("Slide", "Title:", "", false);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {                
                string slideTitle = inputBox.Result;
                inputBox.Dispose();
                slide.Title = slideTitle;
                int index = 0 ;
                if (this.currentSlide == null)
                {
                    this.InsertSlide(0, slide);
                }
                else
                {
                    index = this.workDeck.Slides.IndexOf(this.currentSlide) + 1;
                    this.InsertSlide(index, slide);
                }
                this.UpdateCurrentSlide(slide, true, false);
                return index;
            }
            else
            {
                inputBox.Dispose();
                return -1;
            }
        }

        public Slide RemoveSlide(Slide removeSlide)
        {
            if (removeSlide == null)
                return null;
            int index = this.workDeck.Slides.IndexOf(removeSlide);
            if (removeSlide.Equals(this.workDeck.Slides.LastSlide()))
                index = index - 1;
            Slide s = this.workDeck.Slides.RemoveSlide(removeSlide);
            if (this.workDeck.Slides.Count <= 0)
            {
                this.UpdateCurrentSlide(null, true, false);             
            }
            else
            {
                this.UpdateCurrentSlide(this.workDeck.Slides[index], true, false);                
            }
            return s;
        }

        public void NextSlide(Slide baseSlide)
        {
            if (baseSlide == null)
                return;

            Slide s = this.workDeck.Slides.NextSlide(baseSlide);

            this.UpdateCurrentSlide(s, true, false);
        }

        public void PreviousSlide(Slide baseSlide)
        {
            if (baseSlide == null)
                return;

            Slide s = this.workDeck.Slides.PreviousSlide(baseSlide);

            this.UpdateCurrentSlide(s, true, false);
        }

        public void AppendSlidesFromPPT(string fileName)
        {
            SlidePPTManager manager = new SlidePPTManager(fileName, SLIDEIMGEXT, new Size(SLIDEWIDTH, SLIDEHEIGHT));
            Slide[] slides = manager.GetSlides();            

            int index = 0;
            if (this.currentSlide != null)
            {
                index = this.workDeck.Slides.IndexOf(this.currentSlide) + 1;
            }

            int indexAdd = index;

            foreach (Slide s in slides)
            {
                s.BoardColor = this.currentColor;
                this.InsertSlide(indexAdd, s);
                indexAdd = indexAdd + 1;                
            }

            Slide slide = this.workDeck.Slides[index];

            this.UpdateCurrentSlide(slide, true, false);
        }

        #endregion

        #region Update

        public void UpdateCurrentSlide(Slide selectedSlide, bool invalidate, bool deckPanelChange)
        {            
            this.currentSlide = selectedSlide;
            this.mySlidePanel.Slide = this.currentSlide;
            if (!deckPanelChange)
                this.myDeckPanel.SelectedSlide = this.currentSlide;
            this.UpdateInfo();
            if (invalidate)
            {
                if (selectedSlide == null)
                {
                    this.mySlidePanel.Clear();
                }
                else
                {
                    this.mySlidePanel.Refresh();
                }                 
            }
        }

        public void UpdateInfo()
        {
            string slideName = "";
            string slideType = "";
            string slideMod = "";
            string slideCount = "0/0";
            string slideInfo = "";
            string slideSize = "";

            if (this.currentSlide != null)
            {
                //Title
                slideName = this.currentSlide.Title;
                //Type and Mod
                if (this.currentSlide is PresentationSlide)
                {
                    slideType = "Presentation";
                    slideMod = "Public";
                }
                else
                {
                    slideType = "Whiteboard";
                    if (this.currentSlide is PublicWhiteBoard)
                        slideMod = "Public";
                    else
                        slideMod = "Private";
                }
                //Count
                if (this.workDeck.Slides.Count > 0)
                {
                    slideCount = (this.workDeck.Slides.IndexOf(currentSlide) + 1).ToString() + "/" + this.workDeck.Slides.Count.ToString();
                }
                //Info
                slideInfo = this.currentSlide.Info;
            }
            // Displaying the information on the proper labels
            tbPanelSlideTitleValue.Text = slideName;
            tbPanelSlideTypeValue.Text = slideType;
            tbPanelSlideModValue.Text = slideMod;
            tbPanelSlideCountValue.Text = slideCount;
            tbPanelSlideSizeValue.Text = slideSize;
            tbSlideInfo.Text = slideInfo;
        }

        #endregion

        #region Events

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.PreviousSlide(this.currentSlide);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.NextSlide(this.currentSlide);
        }

        private void btnSlideAdd_Click(object sender, EventArgs e)
        {
            this.AddSlide(new PublicWhiteBoard());
        }

        private void btnPrivateSlideAdd_Click(object sender, EventArgs e)
        {
            this.AddSlide(new PrivateWhiteBoard());
        }

        private void tmiChangeSlideColor_Click(object sender, EventArgs e)
        {
            cdSlide.FullOpen = false;
            if (cdSlide.ShowDialog() == DialogResult.OK)
            {
                this.currentColor = cdSlide.Color;
                if (this.currentSlide != null)
                {
                    this.currentSlide.BoardColor = this.currentColor;
                    this.mySlidePanel.Refresh();
                    this.myDeckPanel.RefreshDeckSlidePanel(this.currentSlide);
                }
            }
        }

        private void btnSlideRemove_Click(object sender, EventArgs e)
        {
            this.RemoveSlide(currentSlide);
        }

        private void tmiChangeSlideTitle_Click(object sender, EventArgs e)
        {
            if (this.currentSlide != null)
            {
                InputBoxForm inputBox = new InputBoxForm("Slide", "Title:", this.currentSlide.Title, false);
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    this.currentSlide.Title = inputBox.Result;
                    this.UpdateCurrentSlide(this.currentSlide, false, false);
                }
                inputBox.Dispose();
            }
        }

        private void tmiChangeSlideInfo_Click(object sender, EventArgs e)
        {
            if (this.currentSlide != null)
            {
                InputBoxForm inputBox = new InputBoxForm("Slide", "Info:", this.currentSlide.Info, true);
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    this.currentSlide.Info = inputBox.Result;
                    this.UpdateCurrentSlide(this.currentSlide, false, false);
                }
                inputBox.Dispose();
            }
        }

        private void tmiInformationBar_CheckedChanged(object sender, EventArgs e)
        {
            pnlSlideInfo.Visible = tmiInformationBar.Checked;
            this.mySlidePanel.Refresh();
        }


        private void tmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm("iPH - Interactive Presenter for Handhelds 2007 - iDeck 0.1", "Copyright © 2007", "LAC/PUC-Rio and Marcelo Malcher");            
            aboutForm.ShowDialog();
            aboutForm.Dispose();
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmiAppend_Click(object sender, EventArgs e)
        {
            if (ofdPPT.ShowDialog() == DialogResult.OK)
            {
                string pptFileName = ofdPPT.FileName;
                if (Path.GetExtension(pptFileName) != ".ppt")
                    throw new ArgumentException("Input file must be a PowerPoint (.ppt) file");
                this.AppendSlidesFromPPT(pptFileName);
            }
        }

        private void tmiCopy_Click(object sender, EventArgs e)
        {
            if (this.currentSlide == null)
                return;
            this.copySlide = (Slide)this.currentSlide.Clone();
            this.copySlide.GenerateNewGuid();
            tmiPaste.Enabled = true;
        }

        private void tmiPaste_Click(object sender, EventArgs e)
        {
            if (this.copySlide == null)
                return;
            int index = 0;
            if (this.currentSlide != null)
                index = this.workDeck.Slides.IndexOf(this.currentSlide) + 1;
            this.InsertSlide(index, this.copySlide);
            this.UpdateCurrentSlide(this.copySlide, true, false);
            this.copySlide = null;
            tmiPaste.Enabled = false;
        }

        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.CloseDeck();
        }

        private void tmiSave_Click(object sender, EventArgs e)
        {
            if (this.currentSlide == null)
            {
                MessageBox.Show("There are not slides to save.", IDECK_NAME);
                return;
            }
            this.SaveDeck(true);
        }

        private void tmiSaveAs_Click(object sender, EventArgs e)
        {
            if (this.currentSlide == null)
            {
                MessageBox.Show("There are not slides to save.", IDECK_NAME);
                return;
            }
            this.SaveDeck(false);
        }

        private void tmiOpen_Click(object sender, EventArgs e)
        {
            if (!this.CloseDeck())
                return;          
            
            if (ofdIDD.ShowDialog() == DialogResult.OK)
            {
                string iddFileName = ofdIDD.FileName;
                if (Path.GetExtension(iddFileName) != ".idd")
                    throw new ArgumentException("Input file must be a Interactive Deck Document (.idd) file");
                this.LoadDeck(iddFileName);
            }
        }

        #region DeckPanel Events

        private void SelectedSlide(object sender, SelectedSlideArgs e)
        {
            this.UpdateCurrentSlide(e.Slide, true, true);
        }

        #endregion

        #endregion
    }
}