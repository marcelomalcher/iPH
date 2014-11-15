using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Messages;
using iPH.Commons.Session;
using iPH.Commons.Presentation;
using iPH.Commons.User;

using CompactFormatter.Attributes;

using LAC.Contribution.Objects;

namespace iPH.Commons.Messages
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class ContributionMessage : BaseMessage
    {
        #region Members

        #region Private

        private Guid slideGuid;

        private Guid contributionGuid;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public ContributionMessage()
            : base()
        {
        }

        public ContributionMessage(SessionKey key, Participant sender, Guid slideGuid, Guid contributionGuid)
            : base(key, sender)
        {
            this.slideGuid = slideGuid;
            this.contributionGuid = contributionGuid;
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

        public Guid ContributionGuid
        {
            get
            {
                return this.contributionGuid;
            }
            set
            {
                this.contributionGuid = value;
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
            string cContributionGuid = (string)parent.Deserialize(stream);

            this.slideGuid = new Guid(cSlideGuid);                        
            this.contributionGuid = new Guid(cContributionGuid);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            
            parent.Serialize(stream, this.slideGuid.ToString());
            parent.Serialize(stream, this.contributionGuid.ToString());
        }

        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContributionAddMessage: ContributionMessage
    {
        #region Members

        #region Private

        private ContributionBaseObject contribution;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public ContributionAddMessage()
            : base()
        {        
        }

        public ContributionAddMessage(SessionKey key, Participant sender, Guid slideGuid, Guid contributionGuid, ContributionBaseObject contribution)
            : base(key, sender, slideGuid, contributionGuid)
        {
            this.contribution = contribution;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public ContributionBaseObject Contribution
        {
            get
            {
                return this.contribution;
            }
            set
            {
                this.contribution = value;
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
            this.contribution = (ContributionBaseObject)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.contribution);
        }
        
        #endregion

        #endregion

        #endregion
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContributionRemoveMessage : ContributionMessage
    {
        #region Constructors

        #region Public

        public ContributionRemoveMessage()
            : base()
        {
        }

        public ContributionRemoveMessage(SessionKey key, Participant sender, Guid slideGuid, Guid contributionGuid)
            : base(key, sender, slideGuid, contributionGuid)
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
