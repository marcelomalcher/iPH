using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Messages;
using iPH.Commons.Session;
using iPH.Commons.User;

using CompactFormatter.Attributes;

namespace iPH.Commons.Messages
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class AckMessage : BaseMessage
    {
        #region Members

        private int ackMessageId;

        private AckMessageType ackType;

        private string observations;

        #endregion

        #region Ctors

        public AckMessage()
            : base()
        {
        }

        public AckMessage(SessionKey key, Participant sender, int theAckMessageId, AckMessageType theAckType, string observations)
            : base(key, sender)
        {
            this.ackMessageId = theAckMessageId;
            this.ackType = theAckType;
            this.observations = observations;
        }

        #endregion

        #region Properties

        public int AckMessageId
        {
            get
            {
                return ackMessageId;
            }
        }

        public AckMessageType AckType
        {
            get
            {
                return ackType;
            }
        }


        public string Observations
        {
            get
            {
                return observations;
            }
        }

        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            ackMessageId = (int)parent.Deserialize(stream);
            int type = (int)parent.Deserialize(stream);
            if (type == 0)
                ackType = AckMessageType.MESSAGE_RECEIVED;
            else
                ackType = AckMessageType.MESSAGE_PROCESSED;
            observations = (string)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, ackMessageId);
            int type = 0;
            if (ackType == AckMessageType.MESSAGE_PROCESSED)
                type = 1;
            parent.Serialize(stream, type);
            parent.Serialize(stream, observations);
        }

        #endregion

    }

    public enum AckMessageType
    {
        MESSAGE_RECEIVED, MESSAGE_PROCESSED
    }
}
