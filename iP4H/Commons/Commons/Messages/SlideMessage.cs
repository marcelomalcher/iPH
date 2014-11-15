using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iP4H.Commons.Session;
using iP4H.Commons.Participant;
using iP4H.Commons.SlideControl;

namespace iP4H.Commons.Messages
{
    [Serializable(Custom=true)]
    public abstract class SlideMessage: Message, ICSerializable
    {
        #region Members

        private Slide slide;       

        #endregion

        #region Ctors

        public SlideMessage()
            : base()
        {
        }
        
        public SlideMessage(SessionKey key, ParticipantInfo sender, Slide slide)
            : base(key, sender)
        {
            this.slide = slide;
        }
        
        #endregion
        
        #region Props 
        
        public Slide Slide
        {
            get
            {
                return this.slide;
            }
            set
            {
                this.slide = value;
            }
        }
        
        #endregion
        
        #region ICSerializable Members
        
        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            slide = (Slide)parent.Deserialize(stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, slide);
        }
        
        #endregion
    }

    

    [Serializable(Custom=true)]
    public class SlideAddMessage: SlideMessage, ICSerializable
    {
        #region Members

        //if null, insert the slide at first
        private Guid previousSlideGuid;

        private LAC.Contribution.Contributions contributions;

        #endregion

        #region Ctors

        public SlideAddMessage()
            : base()
        {
        }

        public SlideAddMessage(SessionKey key, ParticipantInfo sender, Slide slide, Guid previousSlideGuid, LAC.Contribution.Contributions contributions)
            :base(key, sender, slide)
        {
            this.previousSlideGuid = previousSlideGuid;
            this.contributions = contributions;
        }
                
        #endregion
        
        #region Props 

        public Guid PreviousSlideGuid
        {
            get
            {
                return this.previousSlideGuid;
            }
            set
            {
                this.previousSlideGuid = value;
            }
        }

        public LAC.Contribution.Contributions Contributions
        {
            get
            {
                return this.contributions;
            }
            set
            {
                this.contributions = value;
            }
        }

        #endregion
        
        #region ICSerializable Members
        
        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            string cGuid = (string)parent.Deserialize(stream);
            previousSlideGuid = new Guid(cGuid);
            contributions = (LAC.Contribution.Contributions)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, previousSlideGuid.ToString());
            parent.Serialize(stream, contributions);
        }
        
        #endregion
    }

    [Serializable(Custom=true)]
    public class SlideRemoveMessage: SlideMessage, ICSerializable
    {
        #region Ctors

        public SlideRemoveMessage()
            : base()
        {
        }

        public SlideRemoveMessage(SessionKey key, ParticipantInfo sender, Slide slide)
            : base(key, sender, slide)
        {
        }
        
        #endregion
        
        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion
    }

    [Serializable(Custom = true)]
    public class SlideSelectedMessage : SlideMessage, ICSerializable
    {
        #region Member

        private bool syncViewer;

        #endregion

        #region Ctors

        public SlideSelectedMessage()
            : base()
        {            
        }

        public SlideSelectedMessage(SessionKey key, ParticipantInfo sender, Slide slide, bool syncViewer)
            : base(key, sender, slide)
        {
            this.syncViewer = syncViewer;
        }
        
        #endregion

        #region Properties

        public bool SyncViewer
        {
            get
            {
                return this.syncViewer;
            }
        }

        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            syncViewer = (bool)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, syncViewer);
        }

        #endregion
    }
}
