using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LAC.Contribution.Controls
{
    public partial class ContributionBaseControl : UserControl
    {
        #region Members

        private Image myImage;

        private ContributionComponent myContributionComponent;

        #endregion

        #region Ctors
        public ContributionBaseControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public Image Image
        {
            get
            {
                return this.myImage;
            }
            set
            {
                this.myImage = value;
            }
        }

        public ContributionComponent ContributionComponent
        {
            get
            {
                return this.myContributionComponent;
            }
            set
            {
                this.myContributionComponent = value;
            }
        }

        #endregion

        #region Control Methods

        public virtual void Clear()
        {
            //setting null to image and component
            this.myImage = null;
            this.myContributionComponent = null;
            //calling invalidate to repaint control
            this.ControlInvalidate();
        }

        public override void Refresh()
        {
            //setting null to image
            this.myImage = null;
            //calling invalidate to repaint control
            this.ControlInvalidate();
        }

        #endregion

        #region Control Events

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.GetImageToDraw(), 0, 0);
        }

        #endregion

        #region OnPaintBackGround

        protected override void OnPaintBackground(PaintEventArgs e)
        { }

        #endregion

        #region OnResize

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

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
                //Checking if a contribution component is attached to control
                if (this.myContributionComponent != null)
                {
                    //Checking if it is needed to resize contributions
                    Size myCurrentSize = this.GetSize();
                    //scaling contributions
                    this.myContributionComponent.Contributions.ScaleObject(myCurrentSize.Width, myCurrentSize.Height);
                    //Recovering graphics from image
                    Graphics g = Graphics.FromImage(this.myImage);
                    //redrawing contributions
                    this.myContributionComponent.Contributions.Draw(g);
                    //Disposing object
                    g.Dispose();
                }
            }
            //Returning this.myImage
            return this.myImage;
        }

        #endregion

        #region Graphics

        public Graphics GetGraphics()
        {
            return Graphics.FromImage(this.GetImageToDraw());
        }

        #endregion

        #region Virtual Methods

        //
        public virtual Size GetSize()
        {
            return new Size(this.Width, this.Height);
        }

        //
        public virtual Image GetImage()
        {
            //creating this.myImage
            if (this.myImage != null)
                this.myImage.Dispose();
            this.myImage = new Bitmap(this.Width, this.Height);
            //Retrieving graphics from this.myImage
            Graphics g = Graphics.FromImage(this.myImage);
            //Clearing this.myImage with control's back color
            g.Clear(this.BackColor);
            //Disposing graphics
            g.Dispose();
            //Returning this.myImage
            return this.myImage;
        }

        #endregion

        #region Delegates
        private delegate void ControlInvalidateDelegate();
        public void ControlInvalidate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ControlInvalidateDelegate(ControlInvalidate));
                return;
            }
            this.Invalidate();                                                      
        }
        #endregion
    }
}
