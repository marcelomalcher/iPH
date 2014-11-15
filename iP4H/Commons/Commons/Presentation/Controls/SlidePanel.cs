using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using iPH.Commons.Presentation;
using LAC.Functions.Drawing;
using LAC.Contribution;
using LAC.Contribution.Controls;

namespace iPH.Commons.Presentation.Controls
{
    public partial class SlidePanel : ContributionBaseControl
    {
        #region Members

        private Slide mySlide;

        #endregion

        #region Constructor

        public SlidePanel()
        {
            InitializeComponent();
        }

        public SlidePanel(Slide currentSlide)
            : this()
        {
            this.mySlide = currentSlide;
        }

        #endregion

        #region Properties

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

        #region Control Methods

        public override void Clear()
        {
            //setting null to slide
            this.mySlide = null;
            //calling base.Clear 
            base.Clear();
        }

        private delegate void RefreshDelegate();
        public override void Refresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RefreshDelegate(Refresh), new Object[] {});
                return;
            }
            //Calling base.Refresh
            base.Refresh();
        }

        #endregion

        #region Contribution Base Control Methods

        public override Size GetSize()
        {
            return DrawingFunctions.GetRelativeSize(this.Width, this.Height, iPH.Commons.Presentation.Slide.RELATION_WIDTH, iPH.Commons.Presentation.Slide.RELATION_HEIGHT);
        }

        public override Image GetImage()
        {
            //Creating image like the base method
            if (this.Image != null)
                this.Image.Dispose();
            this.Image = base.GetImage();
            //if this.mySlide is not null
            if (this.mySlide != null)
            {
                Bitmap slideImage = (Bitmap)this.mySlide.GetImage(this.Width, this.Height, this.BackColor);
                this.Image = (Bitmap)DrawingFunctions.CreateImageFromImage(slideImage, this.Width, this.Height, slideImage.Width, slideImage.Height, this.mySlide.BoardColor);
                if (slideImage != null)
                    slideImage.Dispose();
            }
            //Returning this.Image
            return this.Image;
        }

        #endregion

    }
}
