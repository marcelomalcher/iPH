using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;

namespace iPH.Commons.User.Role
{
    [CompactFormatter.Attributes.Serializable]
    public class Master : BaseRole
    {
        #region Singleton
        private static Master mySelf;
        public static Master Instance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new Master();
                return mySelf;
            }
        }
        #endregion

        #region Visualizers

        #endregion

        #region Messages

        #region Send

        public override bool SendConnectMessage()
        {
            return false;
        }

        public override bool SendDisconnectMessage()
        {
            return false;
        }

        public override bool SendSlideSubmissionMessage()
        {
            return false;
        }

        #endregion

        #region Receive

        public override bool ReceivePingMessage()
        {
            return false;
        }

        public override bool ReceiveDeckMessage()
        {
            return false;
        }

        public override bool ReceiveSlideMessage()
        {
            return false;
        }

        public override bool ReceiveSlideRemoveMessage()
        {
            return false;
        }

        public override bool ReceiveSlideSelectedMessage()
        {
            return false;
        }

        public override bool ReceiveSlideSelectedAttentionMessage()
        {
            return false;
        }

        public override bool ReceiveSlideSelectedContributionMessage()
        {
            return false;
        }

        public override bool ReceiveSlideSubmissionMasterMessage()
        {
            return false;
        }

        public override bool ReceiveContributionMessage()
        {
            return false;
        }

        public override bool ReceiveContributionRemoveMessage()
        {
            return false;
        }

        public override bool ReceiveContextInformationRulesMessage()
        {
            return false;
        }

        #endregion

        #endregion

        #region Collaboration Functions
        public override bool SynchronizeMaster()
        {
            return false;
        }

        public override bool ViewerSelection()
        {
            return false;
        }
        #endregion
    }
}
