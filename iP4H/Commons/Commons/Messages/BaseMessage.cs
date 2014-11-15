using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iPH.Commons.Session;
using iPH.Commons.User;

namespace iPH.Commons.Messages
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class BaseMessage: ICSerializable
    {
        #region Members

        private static int MessageCont = 0;

        #region Private

        private int messageId;

        private long timeStamp;

        private SessionKey key;

        private Participant sender;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public BaseMessage()
        {
            this.messageId = MessageCont++;
            this.timeStamp = DateTime.Now.Ticks;
        }

        public BaseMessage(SessionKey key, Participant sender) : 
            this()
        {
            this.key = key;
            this.sender = sender;
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public int MessageId
        {
            get
            {
                return messageId;
            }
        }
        
        public long TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }

        public SessionKey Key
        {
            get
            {
                return this.key;
            }
        }

        public Participant Sender
        {
            get
            {
                return this.sender;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ICSerializable Methods

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            messageId = (int)parent.Deserialize(stream);
            timeStamp = (long)parent.Deserialize(stream);
            key = (SessionKey)parent.Deserialize(stream);
            sender = (Participant)parent.Deserialize(stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, messageId);
            parent.Serialize(stream, timeStamp);
            parent.Serialize(stream, key);
            parent.Serialize(stream, sender);
        }

        #endregion

        #endregion

        #endregion
    }
}
