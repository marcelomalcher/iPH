using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;

namespace iPH.Commons.User.Role
{
    [CompactFormatter.Attributes.Serializable]
    public class Offline : BaseRole
    {
        #region Singleton
        private static Offline mySelf;
        public static Offline Instance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new Offline();
                return mySelf;
            }
        }
        #endregion
        
        #region Visualizers

        public override bool VisualizeContributionsDeckPanel()
        {
            return false;
        }

        #endregion

        #region Messages

        #region Send

        public override bool  SendConnectMessage()
        {
            return false;
        }

        public override bool SendDisconnectMessage()
        {
            return false;
        }

        public override bool SendPingMessage()
        {
            return false;
        }

        public override bool SendDeckMessage()
        {
            return false;
        }

        public override bool SendSlideMessage()
        {
            return false;
        }

        public override bool SendSlideRemoveMessage()
        {
            return false;
        }

        public override bool SendSlideSelectedMessage()
        {
            return false;
        }

        public override bool SendSlideSelectedAttentionMessage()
        {
            return false;
        }

        public override bool SendSlideSelectedContributionMessage()
        {
            return false;
        }

        public override bool SendSlideSubmissionMessage()
        {
            return false;
        }

        public override bool SendSlideSubmissionMasterMessage()
        {
            return false;
        }

        public override bool SendContributionMessage()
        {
            return false;
        }

        public override bool SendContributionRemoveMessage()
        {
            return false;
        }

        public override bool SendContextInformationRulesMessage()
        {
            return false;
        }
        #endregion

        #region Receive

        public override bool ReceiveConnectMessage()
        {
            return false;
        }

        public override bool ReceiveDisconnectMessage()
        {
            return false;
        }

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

        public override bool ReceiveSlideSubmissionMessage()
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
