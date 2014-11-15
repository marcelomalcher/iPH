using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iPH.Commons.Messages;

namespace iPH.Commons.Tests
{
    public class TestManager
    {
        #region Members

        private static TestManager mySelf;

        private List<MessageData> data;

        #endregion

        #region Constructors>

        private TestManager()
        {
            this.data = new List<MessageData>();
        }

        #endregion

        #region Methods

        #region Singleton

        public static TestManager getInstance()
        {
            if (mySelf == null)
                mySelf = new TestManager();
            return mySelf;
        }

        #endregion

        public void InsertNewMessageData(BaseMessage message)
        {
            this.InsertNewMessageData(message, "");
        }

        public void InsertNewMessageData(BaseMessage message, string observations)
        {
            MessageData messageData = new MessageData(message, observations);
            this.data.Add(messageData);
        }

        public void InsertResponseMessageData(AckMessage ackMessage)
        {
            this.InsertResponseMessageData(ackMessage, "");
        }

        public void InsertResponseMessageData(AckMessage ackMessage, string observations)
        {
            MessageData messageData = null;
            foreach (MessageData m in data)
            {
                if (m.Message.MessageId == ackMessage.AckMessageId)
                    messageData = m;
            }
            if (messageData == null)
                return;

            messageData.AddResponseMessageData(new MessageData(ackMessage, observations));
        }

        public void CreateFile(string fileName)
        {
            TextWriter writer = new StreamWriter(fileName);            

            foreach (MessageData m in this.data)
            {               
                writer.WriteLine("id: " + m.Message.MessageId + " = " + m.ToString());
                writer.WriteLine("*** Receivers");
                writer.WriteLine("-----------------------");
                foreach (MessageData m1 in m.messageData)
                {
                    AckMessage am = (AckMessage)m1.Message;
                    string type = " - Received";
                    if (am.AckType == AckMessageType.MESSAGE_PROCESSED)
                        type = " - Processed";
                    long diff = m1.Timestamp - m.Timestamp;
                    DateTime dt = new DateTime(diff);
                    writer.WriteLine("*** " + m1.ToString() + " / Diff: " + diff.ToString() + " / Diff time: " + dt.ToLongTimeString() + type);                    
                }
                writer.WriteLine("-----------------------");
                writer.WriteLine("");
            }

            writer.Close();
        }

        #endregion
    }
}
