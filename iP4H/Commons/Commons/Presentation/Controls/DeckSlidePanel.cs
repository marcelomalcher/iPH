using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LAC.Functions.Drawing;

namespace iPH.Commons.Presentation.Controls
{
    public partial class DeckSlidePanel : UserControl
    {
        #region Constants

        private const double RELATIONSIZE = 0.75;

        #endregion

        #region Members
        private DeckPanel myDeckPanel;
        private Slide mySlide;
        private Image myImage;

        #endregion

        #region Ctor

        private DeckSlidePanel()
        {
            InitializeComponent();
            //The default is Top
            this.Dock = DockStyle.Top;
        }

        public DeckSlidePanel(DeckPanel deckPanel, Slide slide)
            : this()
        {
            //Deck Panel
            this.myDeckPanel = deckPanel;
            //Setting the DeckPanel as parent 
            this.mySlide = slide;          
        }

        #endregion

        #region Properties

        public DeckPanel Owner
        {
            get
            {
                return this.myDeckPanel;
            }
            set
            {
                this.myDeckPanel = value;
            }
        }

        public Slide Slide
        {
            get
            {
                return this.mySlide;
            }
            set
            {
                this.mySlide = value;
            }
        }

        #endregion

        #region Methods

        public void Clear()
        {
            this.mySlide = null;
            this.Refresh();
        }

        private delegate void RefreshDelegate();
        public override void Refresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RefreshDelegate(Refresh), new Object[] { });
                return;
            }
            this.myImage = null;
            this.Invalidate();
        }

        #endregion

        #region On Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            
            e.Graphics.DrawImage(this.GetImageToDraw(), 0, 0);
        }

        #endregion

        #region On Paint Background

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #endregion

        #region OnResize

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = (int)(this.Width * RELATIONSIZE);
        }

        #endregion

        #region Mouse Events

        private void DeckPanelSlideItem_MouseDown(object sender, MouseEventArgs e)
        {
            this.myDeckPanel.SetDeckSlidePanel(this);
        }

        #endregion

        #region GUI Delegates

        private delegate DeckSlidePanel GetReferenceDelegate();
        public DeckSlidePanel GetReference()
        {
            if (this.InvokeRequired)
            {
                return (DeckSlidePanel)this.Invoke(new GetReferenceDelegate(GetReference), new Object[] { });
            }
            return this;
        }

        private delegate void UpdateControlDisposeDelegate();
        public void UpdateControlDispose()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlDisposeDelegate(UpdateControlDispose), new Object[] { });
                return;
            }
            this.Dispose();
        }
             
        #endregion

        #region Image to draw

        public Image GetImageToDraw()
        {
            //Checking if control's area changed
            if (this.myImage == null || this.myImage.Width != this.Width || this.myImage.Height != this.Height)
            {
                //Disposing this.myImage if it is assigned
                if (this.myImage != null)
                    this.myImage.Dispose();
                //Retrieving image
                this.myImage = this.GetImage();
            }
            //Returning this.myImage
            return this.myImage;
        }

        #endregion

        #region Image

        private Image GetImage()
        {
            //creating this.myImage
            if (this.myImage != null)
                this.myImage.Dispose();
            this.myImage = new Bitmap(this.Width, this.Height);
            //Retrieving graphics from this.myImage
            Graphics gImg = Graphics.FromImage(this.myImage);
            //Clearing this.myImage with control's back color
            gImg.Clear(this.BackColor);
            //Disposing g..
            gImg.Dispose();
            //if this.mySlide is not null
            if (this.mySlide != null)
            {
                Bitmap slideImage = (Bitmap)this.mySlide.GetImage(this.Width, this.Height, this.BackColor);
                this.myImage = (Bitmap)DrawingFunctions.CreateImageFromImage(slideImage, this.Width, this.Height, slideImage.Width, slideImage.Height, this.mySlide.BoardColor);
                if (slideImage != null)
                    slideImage.Dispose();
            }
            //Creating pen
            Pen pen = new Pen(Color.Black, 1);
            //Drawing black border
            Graphics gBorder = Graphics.FromImage(this.myImage);
            gBorder.DrawRectangle(pen, new Rectangle(0, 0, this.Width, this.Height));
            gBorder.Dispose();
            //Checking if its slide is the selected one
            if (this.mySlide != null && this.Owner.SelectedSlide != null && this.mySlide.Guid.Equals(this.Owner.SelectedSlide.Guid))
            {
                //Setting color and with for selection slide
                pen.Color = this.Owner.SelectedColor;
                pen.Width = this.Owner.SelectedWidth;
                //Drawing selected rectangle
                Graphics gSel = Graphics.FromImage(this.myImage);
                gSel.DrawRectangle(pen, new Rectangle(0, 0, this.Width, this.Height));
                gSel.Dispose();
            }
            //Disposing pen...
            pen.Dispose();
            //Returning this.myImage
            return this.myImage;
        }

        #endregion
    }
}
