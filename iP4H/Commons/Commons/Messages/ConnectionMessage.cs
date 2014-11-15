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
    public class ConnectMessage : BaseMessage
    {
        #region Ctors

        public ConnectMessage()
            : base()
        {
        }

        public ConnectMessage(SessionKey key, Participant sender)
            : base(key, sender)
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

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class DisconnectMessage : BaseMessage
    {
        #region Ctors

        public DisconnectMessage()
            : base()
        {
        }


        public DisconnectMessage(SessionKey key, Participant sender)
            : base(key, sender)
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

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class PingMessage : BaseMessage
    {
        #region Ctors

        public PingMessage()
            : base()
        {
        }


        public PingMessage(SessionKey key, Participant sender)
            : base(key, sender)
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
}
