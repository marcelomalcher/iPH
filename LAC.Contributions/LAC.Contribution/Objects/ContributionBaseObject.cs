using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace LAC.Contribution.Objects
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class ContributionBaseObject : ICSerializable, IComparable, ICloneable
    {
        #region Members

        private Guid myGuid;

        private long myTimestamp;

        private int myBaseWidth;

        private int myBaseHeight;
       
        #endregion

        #region Ctors

        public ContributionBaseObject()
        {
        }

        public ContributionBaseObject(int baseWidth, int baseHeight)
        {
            this.myGuid = Guid.NewGuid();
            this.myTimestamp = DateTime.Now.Ticks;
            this.myBaseWidth = baseWidth;
            this.myBaseHeight = baseHeight;
        }

        #endregion

        #region Properties

        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
            set
            {
                this.myGuid = value;
            }
        }

        public long Timestamp
        {
            get
            {
                return this.myTimestamp;
            }
            set
            {
                this.myTimestamp = value;
            }
        }

        public int BaseWidth
        {
            get
            {
                return this.myBaseWidth;
            }
            set
            {
                this.myBaseWidth = value;
            }
        }

        public int BaseHeight
        {
            get
            {
                return this.myBaseHeight;
            }
            set
            {
                this.myBaseHeight = value;
            }
        }
        #endregion

        #region NewGuid
        public void NewGuid()
        {
            this.myGuid = Guid.NewGuid();
        }
        #endregion

        #region Draw

        public abstract void Draw(Graphics graphicControl);

        #endregion

        #region Intersect

        public abstract bool IntersectObject(Point point, double radius);

        #endregion

        #region Scale

        public abstract void ScaleObject(int newWidth, int newHeight);

        #endregion

        #region ICSerializable Members

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            //Guid
            string cGuid = (string)parent.Deserialize(stream);
            //Timestamp
            long cTimestamp = (long)parent.Deserialize(stream);
            //Base Size
            int cBaseWidth = (int)parent.Deserialize(stream);
            int cBaseHeight = (int)parent.Deserialize(stream);

            this.myGuid = new Guid(cGuid);
            this.myTimestamp = cTimestamp;
            this.myBaseWidth = cBaseWidth;
            this.myBaseHeight = cBaseHeight;
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            //Guid
            parent.Serialize(stream, this.myGuid.ToString());
            //Timestamp
            parent.Serialize(stream, this.myTimestamp);
            //Base Size
            parent.Serialize(stream, this.myBaseWidth);
            parent.Serialize(stream, this.myBaseHeight);
        }

        #endregion

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            if (obj is ContributionBaseObject)
            {
                ContributionBaseObject cbObj = (ContributionBaseObject)obj;
                return this.Timestamp.CompareTo(cbObj.Timestamp);
            }
            else
                throw new ArgumentException("Object is not a ContributionBaseObject.");
        }

        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
