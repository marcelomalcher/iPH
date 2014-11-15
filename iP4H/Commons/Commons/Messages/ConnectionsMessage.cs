using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iP4H.Commons.Session;
using iP4H.Commons.User;

namespace iP4H.Commons.Messages
{
    [Serializable(Custom=true)]
    public class ConnectMessage : BaseMessage, ICSerializable
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

    [Serializable(Custom = true)]
    public class DisconnectMessage : BaseMessage, ICSerializable
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

}
