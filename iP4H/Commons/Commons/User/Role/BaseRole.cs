using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;

namespace iPH.Commons.User.Role
{
    [CompactFormatter.Attributes.Serializable]
    public abstract class BaseRole
    {
        #region Visualizers

        public virtual bool VisualizeMainFunctionsPanel()
        {
            return true;
        }

        public virtual bool VisualizeCoFunctionsPanel()
        {
            return true;
        }

        public virtual bool VisualizeMainDeckPanel()
        {
            return true;
        }

        public virtual bool VisualizeContributionsDeckPanel()
        {
            return true;
        }

        public virtual bool VisualizeSlidePanel()
        {
            return true;
        }

        #endregion

        #region Messages

        #region Send

        #region Connection
        public virtual bool SendConnectMessage()
        {
            return true;
        }

        public virtual bool SendDisconnectMessage()
        {
            return true;
        }

        public virtual bool SendPingMessage()
        {
            return true;
        }
        #endregion

        #region Presentation
        public virtual bool SendDeckMessage()
        {
            return true;
        }

        public virtual bool SendSlideMessage()
        {
            return true;
        }

        public virtual bool SendSlideRemoveMessage()
        {
            return true;
        }

        public virtual bool SendSlideSelectedMessage()
        {
            return true;
        }

        public virtual bool SendSlideSelectedAttentionMessage()
        {
            return true;
        }

        public virtual bool SendSlideSelectedContributionMessage()
        {
            return true;
        }
        
        public virtual bool SendSlideSubmissionMessage()
        {
            return true;
        }

        public virtual bool SendSlideSubmissionMasterMessage()
        {
            return true;
        }
        #endregion

        #region Contribution
        public virtual bool SendContributionMessage()
        {
            return true;
        }

        public virtual bool SendContributionRemoveMessage()
        {
            return true;
        }
        #endregion

        #region ContextInformation
        public virtual bool SendContextInformationRulesMessage()
        {
            return true;
        }
        #endregion

        #endregion

        #region Receive

        #region Connection
        public virtual bool ReceiveConnectMessage()
        {
            return true;
        }

        public virtual bool ReceiveDisconnectMessage()
        {
            return true;
        }

        public virtual bool ReceivePingMessage()
        {
            return true;
        }
        #endregion

        #region Presentation
        public virtual bool ReceiveDeckMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideRemoveMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideSelectedMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideSelectedAttentionMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideSelectedContributionMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideSubmissionMessage()
        {
            return true;
        }

        public virtual bool ReceiveSlideSubmissionMasterMessage()
        {
            return true;
        }
        #endregion

        #region Contribution
        public virtual bool ReceiveContributionMessage()
        {
            return true;
        }

        public virtual bool ReceiveContributionRemoveMessage()
        {
            return true;
        }
        #endregion

        #region Context Information
        public virtual bool ReceiveContextInformationRulesMessage()
        {
            return true;
        }

        #endregion

        #endregion

        #endregion

        #region Collaboration Functions

        public virtual bool SynchronizeMaster()
        {
            return true;
        }

        public virtual bool ViewerSelection()
        {
            return true;
        }

        #endregion
    }
}
