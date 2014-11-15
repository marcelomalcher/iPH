using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iPH.Commons.Presentation.Arguments;

namespace iPH.Commons.Presentation
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Deck : ICSerializable, ICloneable
    {
        #region Members

        #region Private

        private Guid myGuid ;

        private Slides mySlides;

        #endregion

        #endregion

        #region Constructors

        public Deck()
        {
            this.myGuid = System.Guid.NewGuid();
            this.mySlides = new Slides(this);
        }

        public Deck(Guid theGuid)
        {
            this.myGuid = theGuid;
            this.mySlides = new Slides(this);
        }

        #endregion

        #region Properties

        #region Public

        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
        }

        public Slides Slides
        {
            get
            {
                return this.mySlides;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Equals & HashCode

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Deck objDeck = (Deck)obj;

            if (!this.myGuid.Equals(objDeck.Guid)) return false;

            if (!this.mySlides.Equals(objDeck.Slides)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Overrides ICSerializable Methods

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            string cGuid = (string)parent.Deserialize(stream);
            Slides cSlides = (Slides)parent.Deserialize(stream);
            this.myGuid = new Guid(cGuid);
            this.mySlides = cSlides;
            this.mySlides.Deck = this;

            foreach (Slide s in this.mySlides.List)
                s.Deck = this;
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, myGuid.ToString());
            parent.Serialize(stream, mySlides);
        }

        #endregion

        #region Overrides ICloneable Methods

        public object Clone()
        {
            Deck newInstance = new Deck();
            newInstance.myGuid = this.myGuid;
            newInstance.mySlides = (Slides)mySlides.Clone();
            return newInstance;
        }

        #endregion

        #region Static
      
        public static Deck GetDeckFromReader(BinaryReader br)
        {
            try
            {
                Deck loadedDeck = null;
                int length = br.ReadInt32();
                if (length > 0)
                {
                    byte[] data = br.ReadBytes(length);
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream memStream = new MemoryStream(data);
                    Object o = cf.Deserialize(memStream);
                    loadedDeck = (Deck)o;
                    memStream.Close();
                    System.GC.Collect();
                }                                    
                return loadedDeck;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        #endregion

        #region SaveDeckToFileStream
        public void SaveDeckToWriter(BinaryWriter bw)
        {
            try
            {
                if ((this != null) || (this.mySlides.Count > 0))
                {
                    MemoryStream memStream = new MemoryStream();
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    cf.Serialize(memStream, this);
                    byte[] data = memStream.ToArray();
                    memStream.Close();
                    bw.Write(data.Length);
                    bw.Write(data);
                }
                else
                    bw.Write(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        #endregion


        #endregion

        #endregion

    }
}
