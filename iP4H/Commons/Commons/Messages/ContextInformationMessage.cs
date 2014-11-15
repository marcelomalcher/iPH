using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Messages;
using iPH.Commons.Session;
using iPH.Commons.Context;
using iPH.Commons.User;

using CompactFormatter.Attributes;

namespace iPH.Commons.Messages
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContextInformationRulesMessage: BaseMessage
    {
        #region Members

        #region Private

        private ContextInformationRule[] myRules;

        #endregion

        #endregion

        #region Ctors

        public ContextInformationRulesMessage()
            : base()
        {        
        }

        public ContextInformationRulesMessage(SessionKey key, Participant sender, ContextInformationRule[] theRules)
            : base(key, sender)
        {
            this.myRules = theRules;
        }

        #endregion

        #region Properties

        #region Public

        public ContextInformationRule[] Rules
        {
            get
            {
                return this.myRules;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            int countRules = (int)parent.Deserialize(stream);
            this.myRules = new ContextInformationRule[countRules];
            for (int i = 0; i < countRules; i++)
            {
                ContextInformationRule rule = (ContextInformationRule)parent.Deserialize(stream);
                this.myRules[i] = rule;
            }
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, this.myRules.Length);
            foreach (ContextInformationRule c in this.myRules)
            {
                parent.Serialize(stream, c);
            }
        }

        #endregion

        #endregion
    }
}
