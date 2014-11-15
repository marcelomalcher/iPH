using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iP4H.Commons.Session;
using iP4H.Commons.Participant;

namespace iP4H.Commons.Messages
{
    [Serializable(Custom=true)]
    public abstract class Message: ICSerializable
    {
        #region Members
        
        private long timeStamp;

        private SessionKey key;

        private ParticipantInfo participantSender;

        #endregion

        #region Constructor

        public Message()
        {
            this.timeStamp = DateTime.Now.Ticks;
        }

        public Message(SessionKey key, ParticipantInfo sender) : 
            this()
        {
            this.key = key;
            this.participantSender = sender;
        }        


        #endregion

        #region Properties

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

        public ParticipantInfo Sender
        {
            get
            {
                return this.participantSender;
            }
        }

        #endregion

        #region ICSerializable Members

        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            timeStamp = (long)parent.Deserialize(stream);
            key = (SessionKey)parent.Deserialize(stream);
            participantSender = (ParticipantInfo)parent.Deserialize(stream);
        }

        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, timeStamp);
            parent.Serialize(stream, key);
            parent.Serialize(stream, participantSender);
        }

        #endregion
    }
}
