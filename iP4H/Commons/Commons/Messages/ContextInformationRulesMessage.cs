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
    public class ContextInformationRuleMessage: BaseMessage, ICSerializable
    {
        #region Ctors

        public ContextInformationRuleMessage()
            : base()
        {        
        }

        public ContextInformationRuleMessage(SessionKey key, Participant sender)
            : base(key, sender)
        {
        }

        #endregion

        #region ICSerializable Members

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion
    }

    [Serializable(Custom = true)]
    public class ContextInformationRuleRemoveMessage : BaseMessage, ICSerializable
    {
        #region Ctors

        public ContextInformationRuleRemoveMessage()
            : base()
        {
        }

        public ContextInformationRuleRemoveMessage(SessionKey key, Participant sender)
            : base(key, sender)
        {
        }

        #endregion

        #region ICSerializable Members

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
        }

        #endregion
    }
}
