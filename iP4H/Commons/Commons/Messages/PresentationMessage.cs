using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Manager;
using iPH.Commons.Messages;
using iPH.Commons.Presentation;
using iPH.Commons.Session;
using iPH.Commons.User;

using CompactFormatter.Attributes;

using LAC.Contribution;

namespace iPH.Commons.Messages
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class DeckMessage: BaseMessage
    {
        #region Members

        private Deck deck;

        private SlideContribution[] slideContributions;

        #endregion

        #region Ctors
        public DeckMessage()
            : base()
        {
        }

        public DeckMessage(SessionKey key, Participant sender, Deck deck, SlideContribution[] slideContributions)
            : base(key, sender)
        {
            this.deck = deck;
            this.slideContributions = slideContributions;
        }
        #endregion

        #region Props
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }

        public SlideContribution[] SlideContributions
        {
            get
            {
                return this.slideContributions;
            }
            set
            {
                this.slideContributions = value;
            }
        }
        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            deck = (Deck)parent.Deserialize(stream);
            int cCount = (int)parent.Deserialize(stream);
            this.slideContributions = new SlideContribution[cCount];
            for (int i = 0; i < cCount; i++)
            {
                this.slideContributions[i] = (SlideContribution)parent.Deserialize(stream);
            }
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, deck);
            int contributionsLenght = this.slideContributions == null ? 0 : this.slideContributions.Length; 
            parent.Serialize(stream, contributionsLenght);
            for (int i = 0; i < contributionsLenght; i++)
            {
                parent.Serialize(stream, slideContributions[i]);
            }
        }

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class SlideMessage : BaseMessage
    {
        #region Members

        #region Private

        private Guid slideGuid;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public SlideMessage()
            : base()
        {
        }

        public SlideMessage(SessionKey key, Participant sender, Guid slideGuid)
            : base(key, sender)
        {
            this.slideGuid = slideGuid;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public Guid SlideGuid
        {
            get
            {
                return this.slideGuid;
            }
            set
            {
                this.slideGuid = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);

            string cSlideGuid = (string)parent.Deserialize(stream);
            this.slideGuid = new Guid(cSlideGuid);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.slideGuid.ToString());
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideAddMessage : SlideMessage
    {
        #region Members

        #region Private

        private Slide slide;

        private Guid previousSlideGuid;

        private Contributions contributions;

        private int slideNo;

        private bool deckSlide;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public SlideAddMessage()
            : base()
        {
        }

        public SlideAddMessage(SessionKey key, Participant sender, Slide slide, Guid previousSlideGuid, Contributions contributions, int slideNo, bool deckSlide)
            : base(key, sender, slide.Guid)
        {
            this.slide = slide;
            this.previousSlideGuid = previousSlideGuid;
            this.contributions = contributions;
            this.slideNo = slideNo;
            this.deckSlide = deckSlide;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

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

        public Contributions Contributions
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

        public int SlideNo
        {
            get
            {
                return this.slideNo;
            }
            set
            {
                this.slideNo = value;
            }
        }

        public bool DeckSlide
        {
            get
            {
                return this.deckSlide;
            }
            set
            {
                this.deckSlide = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            
            this.slide = (Slide)parent.Deserialize(stream);           
            string cPreviousSlideGuid = (string)parent.Deserialize(stream);
            this.previousSlideGuid = new Guid(cPreviousSlideGuid);
            this.contributions = (Contributions)parent.Deserialize(stream);
            this.slideNo = (int)parent.Deserialize(stream);
            this.deckSlide = (bool)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);

            parent.Serialize(stream, this.slide);
            parent.Serialize(stream, this.previousSlideGuid.ToString());
            parent.Serialize(stream, this.contributions);
            parent.Serialize(stream, this.slideNo);
            parent.Serialize(stream, this.deckSlide);
        }

        #endregion
        
        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideSelectedMessage : SlideMessage
    {
        #region Members

        #region Private

        private bool viewerSelect;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public SlideSelectedMessage()
            : base()
        {
        }

        public SlideSelectedMessage(SessionKey key, Participant sender, Guid slideGuid, bool viewerSelect)
            : base(key, sender, slideGuid)
        {
            this.viewerSelect = viewerSelect;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public bool ViewerSelect
        {
            get
            {
                return this.viewerSelect;
            }
            set
            {
                this.viewerSelect = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);

            this.viewerSelect = (bool)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);

            parent.Serialize(stream, this.viewerSelect);
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideSelectedAttentionMessage : SlideMessage
    {
        #region Constructors

        #region Public

        public SlideSelectedAttentionMessage()
            : base()
        {
        }

        public SlideSelectedAttentionMessage(SessionKey key, Participant sender, Guid slideGuid)
            : base(key, sender, slideGuid)
        {
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideSelectedContributionMessage : SlideSelectedMessage
    {
        #region Constructors

        #region Public

        public SlideSelectedContributionMessage()
            : base()
        {
        }

        public SlideSelectedContributionMessage(SessionKey key, Participant sender, Guid slideGuid, bool viewerSelect)
            : base(key, sender, slideGuid, viewerSelect)
        {
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideSubmissionMessage : SlideAddMessage
    {
        #region Constructors

        #region Public

        public SlideSubmissionMessage()
            : base()
        {
        }

        public SlideSubmissionMessage(SessionKey key, Participant sender, Slide slide, Contributions contributions)
            : base(key, sender, slide, Guid.Empty, contributions, 0, true)
        {
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideSubmissionMasterMessage : SlideSubmissionMessage
    {
        #region Constructors

        #region Public

        public SlideSubmissionMasterMessage()
            : base()
        {
        }

        public SlideSubmissionMasterMessage(SessionKey key, Participant sender, Slide slide, Contributions contributions)
            : base(key, sender, slide, contributions)
        {
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region Overrides ICSerializable Methods

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion

        #endregion

        #endregion
    }

}
