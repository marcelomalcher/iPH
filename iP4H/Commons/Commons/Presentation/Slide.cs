using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using LAC.Functions.Drawing;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Presentation
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class Slide: ICSerializable, ICloneable
    {
        #region Members

        #region Const

        public static readonly int RELATION_WIDTH = 800;

        public static readonly int RELATION_HEIGHT = 600;

        protected static readonly Color DEFAULT_COLOR = Color.Wheat;

        #endregion

        #region Private

        private Deck myDeck;
              
        private string myTitle;
        
        private string myInfo = "";
        
        private Color boardColor;
       
        #endregion

        #region Protected
        
        protected Guid myGuid;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public Slide()
        {
            this.GenerateNewGuid();
            this.BoardColor = DEFAULT_COLOR;
        }
        
        public Slide(string slideTitle)
            : this()
        {
            this.myTitle = slideTitle;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public Deck Deck
        {
            get
            {
                return this.myDeck;
            }
            set
            {
                this.myDeck = value;
            }
        }

        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
        }

        public string Title
        {
            get
            {
                return this.myTitle;
            }
            set
            {
                this.myTitle = value;
            }
        }

        public string Info
        {
            get
            {
                return this.myInfo;
            }
            set
            {
                this.myInfo = value;
            }
        }

        public Color BoardColor
        {
            get
            {
                return this.boardColor;
            }
            set
            {
                this.boardColor = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Abstract

        public abstract Image GetImage(int width, int height, Color controlColor);

        #region ICloneable Method

        public abstract object Clone();

        #endregion

        #endregion

        #region Virtual

        public virtual bool SendContributions()
        {
            return true;
        }

        #endregion

        #region Overrides Equals & HashCode

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Slide objSlide = (Slide)obj;

            if (!this.myGuid.Equals(objSlide.myGuid)) return false;

            if (!this.myTitle.Equals(objSlide.myTitle)) return false;

            if (!this.myInfo.Equals(objSlide.myInfo)) return false;

            if (!this.boardColor.Equals(objSlide.boardColor)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region ICSerializable Methods

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            string cGuid = (string)parent.Deserialize(stream);
            string cTitle = (string)parent.Deserialize(stream);
            string cInfo = (string)parent.Deserialize(stream);
            byte cColorB = (byte)parent.Deserialize(stream);
            byte cColorG = (byte)parent.Deserialize(stream);
            byte cColorR = (byte)parent.Deserialize(stream);

            this.myGuid = new Guid(cGuid);
            this.myTitle = cTitle;
            this.myInfo = cInfo;
            this.boardColor = Color.FromArgb(cColorR, cColorG, cColorB);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, myGuid.ToString());
            parent.Serialize(stream, myTitle);
            parent.Serialize(stream, myInfo);
            parent.Serialize(stream, boardColor.B);
            parent.Serialize(stream, boardColor.G);
            parent.Serialize(stream, boardColor.R);
        }

        #endregion        
        
        public void GenerateNewGuid()
        {
            this.myGuid = System.Guid.NewGuid();
        }

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class WhiteBoard : Slide
    {
        #region Methods

        #region Overrides

        public override Image GetImage(int width, int height, Color controlColor)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(controlColor);

            Size imageSize = DrawingFunctions.GetRelativeSize(width, height, RELATION_WIDTH, RELATION_HEIGHT);
            
            Bitmap slideImage = new Bitmap(imageSize.Width, imageSize.Height);
            Graphics gSI = Graphics.FromImage(slideImage);
            gSI.Clear(this.BoardColor);
            gSI.Dispose();

            g.DrawImage(slideImage, 0, 0);
            g.Dispose();

            return image;
        }

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class PublicWhiteBoard : WhiteBoard
    {
        #region Methods

        #region Public

        #region Overrides ICloneable Methods

        public override object Clone()
        {
            PublicWhiteBoard newInstance = new PublicWhiteBoard();
            newInstance.myGuid = this.Guid;
            newInstance.Deck = this.Deck;
            newInstance.Title = this.Title;
            newInstance.Info = this.Info;
            newInstance.BoardColor = this.BoardColor;
            return newInstance;
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class PrivateWhiteBoard : WhiteBoard
    {
        #region Methods

        #region Public

        #region Overrides Virtual

        public override bool SendContributions()
        {
            return false;
        }

        #endregion

        #region Overrides ICloneable Methods

        public override object Clone()
        {
            PrivateWhiteBoard newInstance = new PrivateWhiteBoard();
            newInstance.myGuid = this.Guid;
            newInstance.Deck = this.Deck;
            newInstance.Title = this.Title;
            newInstance.Info = this.Info;
            newInstance.BoardColor = this.BoardColor;
            return newInstance;
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class PresentationSlide : Slide
    {
        #region Members

        #region Private

        private byte[] slideImageBytes;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public PresentationSlide()
            : base()
        {
        }

        public PresentationSlide(String myTitle, byte[] slideImageBytes) : 
            base(myTitle)
        {
            this.ImageBytes = slideImageBytes;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public byte[] ImageBytes
        {
            get
            {
                return this.slideImageBytes;
            }
            set
            {
                this.slideImageBytes = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides

        public override Image GetImage(int width, int height, Color controlColor)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(controlColor);

            Size imageSize = DrawingFunctions.GetRelativeSize(width, height, RELATION_WIDTH, RELATION_HEIGHT);

            Bitmap presentationImage;

            lock (this.ImageBytes)
            {
                presentationImage = (Bitmap)DrawingFunctions.GetImageFromBytes(this.ImageBytes);
            }

            Bitmap slideImage = (Bitmap)DrawingFunctions.CreateImageFromImage(presentationImage, imageSize.Width, imageSize.Height, imageSize.Width, imageSize.Height, this.BoardColor);

            if (presentationImage != null)
                presentationImage.Dispose();

            g.DrawImage(slideImage, 0, 0);           
            g.Dispose();

            slideImage.Dispose();
         
            return image;
        }

        #region Equals & HashCode

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            if (!base.Equals(obj)) return false;

            PresentationSlide objSlide = (PresentationSlide)obj;
          
            if (!this.ImageBytes.Equals(objSlide.ImageBytes)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            this.slideImageBytes = (byte[])parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.slideImageBytes);
        }

        #endregion

        #region ICloneable Methods

        public override object Clone()
        {
            PresentationSlide newInstance = new PresentationSlide();
            newInstance.myGuid = this.Guid;
            newInstance.Deck = this.Deck;
            newInstance.Title = this.Title;
            newInstance.Info = this.Info;
            newInstance.BoardColor = this.BoardColor;
            newInstance.ImageBytes = (byte[])this.ImageBytes.Clone();
            return newInstance;
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
