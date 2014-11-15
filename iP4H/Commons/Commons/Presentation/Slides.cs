using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iPH.Commons.Presentation.Arguments;

namespace iPH.Commons.Presentation
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Slides : ICSerializable, ICloneable
    {
        #region Members
        private Deck myDeck;
        private List<Slide> mySlides;
        private Dictionary<Guid, Slide> myIdentifiers;
        #endregion 

        #region Ctors

        public Slides()
        {
            this.mySlides = new List<Slide>();
            this.myIdentifiers = new Dictionary<Guid, Slide>();
        }

        public Slides(Deck deck)
            : this()
        {
            this.myDeck = deck;
        }

        #endregion

        #region Props

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

        public int Count
        {
            get
            {
                return this.mySlides.Count;
            }
        }

        public List<Slide> List
        {
            get
            {
                return this.mySlides;
            }
        }

        public Slide this[int index]
        {
            get
            {
                if (index < 0 || index >= this.mySlides.Count)
                    return null;
                return this.mySlides[index];
            }
        }
        
        #endregion

        #region Methods

        #region Persistence
        
        public bool InsertSlide(int index, Slide slideAdd)
        {           
            if (this.GetSlide(slideAdd) != null)
            {
                return false;
            }
            slideAdd.Deck = this.Deck;
            if (index > this.mySlides.Count)
                index = this.mySlides.Count;
            this.mySlides.Insert(index, slideAdd);
            this.myIdentifiers.Add(slideAdd.Guid, slideAdd);

            NewSlideArgs e = new NewSlideArgs(slideAdd, index);
            OnNewSlideEvent(e);

            return true;
        }

        public Slide RemoveSlide(Guid slideGuid)
        {
            Slide s = this.GetSlide(slideGuid);
            if (s != null)
            {
                this.mySlides.Remove(s);
                this.myIdentifiers.Remove(slideGuid);
                SlidesRemovedArgs e = new SlidesRemovedArgs(s);
                OnSlidesRemovedEvent(e);
                return s;
            }
            return null;
        }

        public Slide RemoveSlide(Slide slideRemove)
        {
            return this.RemoveSlide(slideRemove.Guid);
        }

        public void Clear()
        {
            Slide[] allSlides = (Slide[])this.mySlides.ToArray();

            this.mySlides.Clear();
            this.myIdentifiers.Clear();
            SlidesRemovedArgs e = new SlidesRemovedArgs(allSlides);
            OnSlidesRemovedEvent(e);
        }
       
        #endregion

        #region Navigation

        public Slide GetSlide(Slide slideFind)
        {
            return GetSlide(slideFind.Guid);
        }

        public Slide GetSlide(Guid slideGuid)
        {
            if (this.myIdentifiers.ContainsKey(slideGuid))
            {
                return this.myIdentifiers[slideGuid];
            }
            return null;
        }

        public Slide NextSlide(Slide currentSlide)
        {
            if (this.GetSlide(currentSlide) == null)
                return null;
            int currentIndex = this.mySlides.IndexOf(currentSlide);
            if (currentIndex == (this.mySlides.Count - 1))
                return currentSlide;
            return (Slide)this[currentIndex + 1];
        }

        public Slide PreviousSlide(Slide currentSlide)
        {
            if (this.GetSlide(currentSlide) == null)
                return null;
            int currentIndex = this.mySlides.IndexOf(currentSlide);
            if (currentIndex == 0)
                return currentSlide;
            return (Slide)this[currentIndex - 1];
        }

        public Slide FirstSlide()
        {
            if (this.mySlides.Count <= 0)
                return null;
            return (Slide)this[0];
        }

        public Slide LastSlide()
        {
            if (this.mySlides.Count <= 0)
                return null;
            return (Slide)this[this.mySlides.Count - 1];
        }

        public int IndexOf(Slide currentSlide)
        {
            return this.mySlides.IndexOf(currentSlide);
        }
        
        #endregion

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            int slideCount = (int)parent.Deserialize(stream);
            for (int i = 0; i < slideCount; i++)
            {
                Slide s = (Slide)parent.Deserialize(stream);
                this.InsertSlide(i, s);
            }
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.Count);
            foreach (Slide s in this.mySlides)
            {
                parent.Serialize(stream, s);
            }
        }

        #endregion

        #region Equals & GetHashCode

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Slides objSlides = (Slides)obj;

            if (!this.myDeck.Guid.Equals(objSlides.myDeck.Guid)) return false;

            if (!this.mySlides.Count.Equals(objSlides.mySlides.Count)) return false;

            for (int i = 0; i < this.mySlides.Count; i++)
            {
                if (!((Slide)this.mySlides[i]).Equals((Slide)objSlides.mySlides[i])) return false;
            }          

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            Slides newInstance = new Slides();
            newInstance.myDeck = this.myDeck;
            int index = 0;
            foreach (Slide s in this.mySlides)
            {
                newInstance.InsertSlide(index, ((Slide)s.Clone()));
                index = index + 1;
            }
            return newInstance;
        }

        #endregion

        #region Delegate Events

        public delegate void NewSlideEventHandler(object sender, NewSlideArgs e);
        public event NewSlideEventHandler NewSlideEvent;
        protected virtual void OnNewSlideEvent(NewSlideArgs e)
        {
            if (NewSlideEvent != null)
            {
                NewSlideEvent(this, e);
            }
        }

        public delegate void SlidesRemovedEventHandler(object sender, SlidesRemovedArgs e);
        public event SlidesRemovedEventHandler SlidesRemovedEvent;
        protected virtual void OnSlidesRemovedEvent(SlidesRemovedArgs e)
        {
            if (SlidesRemovedEvent != null)
            {
                SlidesRemovedEvent(this, e);
            }
        }
        #endregion
    }
}
