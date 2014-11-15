using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;

namespace iPH.Commons.User.Role
{
    [CompactFormatter.Attributes.Serializable]
    public class Contribuitor : BaseRole
    {
        #region Singleton
        private static Contribuitor mySelf;
        public static Contribuitor Instance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new Contribuitor();
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

        #endregion

        #endregion

        #region Collaboration Functions
        public override bool ViewerSelection()
        {
            return false;
        }
        #endregion
    }
}
