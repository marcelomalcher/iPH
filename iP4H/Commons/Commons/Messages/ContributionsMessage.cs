using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iP4H.Commons.Session;
using iP4H.Commons.Presentation;
using iP4H.Commons.User;
using LAC.Contribution.Objects;

namespace iP4H.Commons.Messages
{
    [Serializable(Custom=true)]
    public class ContributionMessage: BaseMessage, ICSerializable
    {
        #region Members

        private Guid slideGuid;

        private ContributionBaseObject contribution;

        #endregion

        #region Ctors

        public ContributionMessage()
            : base()
        {        
        }

        public ContributionMessage(SessionKey key, Participant sender, Guid slideGuid, ContributionBaseObject contribution)
            : base(key, sender)
        {
            this.slideGuid = slideGuid;
            this.contribution = contribution;
        }

        #endregion

        #region Props

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

        #region ICSerializable Members

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            string cSlideGuid = (string)parent.Deserialize(stream);
            this.slideGuid = new Guid(cSlideGuid);
            this.contribution = (ContributionBaseObject)parent.Deserialize(stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.slideGuid.ToString());
            parent.Serialize(stream, this.contribution);
        }

        #endregion
    }

    [Serializable(Custom=true)]
    public class ContributionRemoveMessage : BaseMessage, ICSerializable
    {
        #region Members

        private Guid slideGuid;

        private Guid contributionGuid;

        #endregion

        #region Ctors

        public ContributionRemoveMessage()
            : base()
        {        
        }

        public ContributionRemoveMessage(SessionKey key, Participant sender, Guid slideGuid, Guid contributionGuid)
            : base(key, sender)
        {
            this.slideGuid = slideGuid;
            this.contributionGuid = contributionGuid;
        }

        #endregion

        #region Props

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

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            string cSlideGuid = (string)parent.Deserialize(stream);
            this.slideGuid = new Guid(cSlideGuid);
            string cContributionGuid = (string)parent.Deserialize(stream);
            this.contributionGuid = new Guid(cContributionGuid);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.slideGuid.ToString());
            parent.Serialize(stream, this.contributionGuid.ToString());
        }

        #endregion
    }
}
