using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using LAC.Contribution;
using LAC.Functions.Drawing;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace LAC.Contribution.Objects
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Text : ContributionBaseObject, ICSerializable, ICloneable
    {
        #region Members

        private string myText;

        private Font myFont;

        private Font myOriginalFont;

        private Color myColor;

        private Point myLocation;

        private Point myOriginalLocation;

        private SizeF mySizeF;

        private SizeF myOriginalSizeF;

        #endregion

        #region Constructors

        //No-args constructor
        public Text()
            : base()
        {
        }

        public Text(int baseWidth, int baseHeight, Point point, string text, Font font, Color color)
            : base(baseWidth, baseHeight)
        {
            this.myLocation = point;
            this.myOriginalLocation = new Point(this.myLocation.X, this.myLocation.Y);
            this.myText = text;
            this.myFont = font;
            this.myOriginalFont = (Font)this.myFont.Clone();
            this.myColor = color;
        }

        #endregion

        #region Properties

        #endregion

        #region Draw

        public override void Draw(Graphics graphicControl)
        {
            //if sizeF isn't calculated yet..
            if (this.mySizeF == SizeF.Empty)
            {
                //Measuring original string draw...
                this.mySizeF = graphicControl.MeasureString(this.myText, this.myFont);
                //Setting original SizeF
                this.myOriginalSizeF.Width = this.mySizeF.Width;
                this.myOriginalSizeF.Height = this.mySizeF.Height;
            }                      

            //Creating image
            Bitmap textImage = new Bitmap((int)Math.Round(this.myOriginalSizeF.Width), (int)Math.Round(this.myOriginalSizeF.Height));
            Graphics g = Graphics.FromImage(textImage);
            g.Clear(Color.Transparent);
            g.DrawString(this.myText, this.myOriginalFont, new SolidBrush(this.myColor), 0, 0);
            g.Dispose();       
            //Resizing image to new size
            Bitmap newTextImage = (Bitmap)DrawingFunctions.CreateImageFromImage(textImage, (int)Math.Round(this.mySizeF.Width), (int)Math.Round(this.mySizeF.Height), (int)Math.Round(this.mySizeF.Width), (int)Math.Round(this.mySizeF.Height), Color.Transparent);
            //Drawing image
            graphicControl.DrawImage(newTextImage, this.myLocation.X, this.myLocation.Y);
            //Disposing image
            newTextImage.Dispose();
        }

        #endregion

        #region Intersect

        public override bool IntersectObject(Point point, double radius)
        {
            if (!this.mySizeF.IsEmpty)
            {
                Rectangle textRect = new Rectangle(this.myLocation.X, this.myLocation.Y, (int)this.mySizeF.Width, (int)this.mySizeF.Height);
                return textRect.Contains(point);
            }
            return false;
        }

        #endregion

        #region Scale

        public override void ScaleObject(int newWidth, int newHeight)
        {
            //Passing original values
            this.myLocation = new Point(this.myOriginalLocation.X, this.myOriginalLocation.Y);
            this.myFont = (Font)this.myOriginalFont.Clone();

            this.mySizeF.Width = this.myOriginalSizeF.Width;
            this.mySizeF.Height = this.myOriginalSizeF.Height;

            double relWidth = (double)newWidth / (double)this.BaseWidth;
            double relHeight = (double)newHeight / (double)this.BaseHeight;

            int newX = (int)Math.Round((double)this.myLocation.X * relWidth, 0);
            int newY = (int)Math.Round((double)this.myLocation.Y * relHeight, 0);

            if (this.mySizeF != SizeF.Empty)
            {
                this.mySizeF.Width = (float)(relWidth * (double)this.mySizeF.Width);
                this.mySizeF.Height = (float)(relHeight * (double)this.mySizeF.Height);
            }
            
            this.myLocation = new Point(newX, newY);

            double newSize = ((relWidth * relHeight) * (double)this.myFont.Size);

            this.myFont = new Font(this.myFont.Name, (float)newSize, this.myFont.Style);
        }

        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            //Text
            string cText = (string)parent.Deserialize(stream);
            //Font Name
            string cFontName = (string)parent.Deserialize(stream);
            //Font Size
            float cFontSize = (float)parent.Deserialize(stream);
            //Font Style
            FontStyle cFontStyle = (FontStyle)((int)parent.Deserialize(stream));
            //Color
            byte cColorR = (byte)parent.Deserialize(stream);
            byte cColorG = (byte)parent.Deserialize(stream);
            byte cColorB = (byte)parent.Deserialize(stream);
            //Location
            int cX = (int)parent.Deserialize(stream);
            int cY = (int)parent.Deserialize(stream);
            //Original SizeF
            float cWidth = (float)parent.Deserialize(stream);
            float cHeight = (float)parent.Deserialize(stream);

            this.myText = cText;
            this.myOriginalFont = new Font(cFontName, cFontSize, cFontStyle);
            this.myFont = (Font)this.myOriginalFont.Clone();
            this.myColor = Color.FromArgb(cColorR, cColorG, cColorB); ;
            this.myOriginalLocation = new Point(cX, cY);
            this.myLocation = new Point(this.myOriginalLocation.X, this.myOriginalLocation.Y);
            this.myOriginalSizeF.Width = cWidth;
            this.myOriginalSizeF.Height = cHeight;
            this.mySizeF.Width = this.myOriginalSizeF.Width;
            this.mySizeF.Height = this.myOriginalSizeF.Height;
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            //Text
            parent.Serialize(stream, this.myText);
            //Font Name
            parent.Serialize(stream, this.myOriginalFont.Name);
            //Font Size
            parent.Serialize(stream, this.myOriginalFont.Size);
            //Font Style
            parent.Serialize(stream, unchecked((int)this.myOriginalFont.Style));
            //Color
            parent.Serialize(stream, this.myColor.R);
            parent.Serialize(stream, this.myColor.G);
            parent.Serialize(stream, this.myColor.B);
            //Location
            parent.Serialize(stream, this.myOriginalLocation.X);
            parent.Serialize(stream, this.myOriginalLocation.Y);
            //OriginalSizeF
            parent.Serialize(stream, this.myOriginalSizeF.Width);
            parent.Serialize(stream, this.myOriginalSizeF.Height);
        }

        #endregion

        #region ICloneable Members

        public override object Clone()
        {
            Text newInstance = new Text();
            //Base
            newInstance.Guid = this.Guid;
            newInstance.BaseWidth = this.BaseWidth;
            newInstance.BaseHeight = this.BaseHeight;
            newInstance.Timestamp = this.Timestamp;
            //Text
            newInstance.myColor = Color.FromArgb(this.myColor.R, this.myColor.G, this.myColor.B);
            newInstance.myLocation = new Point(this.myLocation.X, this.myLocation.Y);
            newInstance.myOriginalLocation = new Point(this.myOriginalLocation.X, this.myOriginalLocation.Y);
            newInstance.myFont = (Font)this.myFont.Clone();
            newInstance.myOriginalFont = (Font)this.myOriginalFont.Clone();
            newInstance.myText = (string)this.myText.Clone();
            newInstance.myOriginalSizeF.Width = this.myOriginalSizeF.Width;
            newInstance.myOriginalSizeF.Height = this.myOriginalSizeF.Height;
            return newInstance;   
        }

        #endregion

    }
}
