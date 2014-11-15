using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Messages;

namespace iPH.Commons.Tests
{
    public class MessageData
    {
        #region Members

        private BaseMessage message;

        private long timestamp;

        public List<MessageData> messageData;

        private string observations;

        #endregion

        #region Constructors

        public MessageData(BaseMessage theMessage, string observations)
        {
            this.message = theMessage;
            this.timestamp = DateTime.Now.Ticks;
            this.messageData = new List<MessageData>();
            this.observations = observations;
        }

        #endregion

        #region Props

        public BaseMessage Message
        {
            get
            {
                return this.message;
            }
        }

        public long Timestamp
        {
            get
            {
                return this.timestamp;
            }
        }

        public string Observations
        {
            get
            {
                return this.observations;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string ret = " Sender: " + this.Message.Sender.NickName;
            ret += " ; Type: " + this.Message.GetType().ToString();
            ret += " ; Timestamp: " + this.Timestamp.ToString();
            DateTime dt = new DateTime(this.Timestamp);
            ret += " ; Time: " + dt.ToLongTimeString();
            if (this.observations.Length > 0)
                ret += " ; Observations: " + this.Observations;
            return ret;
        }

        public void AddResponseMessageData(MessageData theMessageData)
        {
            this.messageData.Add(theMessageData);
        }

        #endregion
    }
}
