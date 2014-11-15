using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Context;
using iPH.Commons.Forms;
using iPH.Commons.Messages;
using iPH.Commons.Presentation;
using iPH.Commons.User.Role;


//Testes
using iPH.Commons.Tests;

using LAC.Contribution;
using LAC.Contribution.Objects;

namespace iPH.Commons.Manager
{
    public class MessageManager
    {
        #region Members
        private InteractivePresentationForm myForm;
        #endregion

        #region Ctor

        public MessageManager(InteractivePresentationForm interactiveForm)
        {
            this.myForm = interactiveForm;
        }

        #endregion

        #region Methods

        #region Send

        #region Connection

        /// <summary>
        /// Send Roles: Contribuitor and Viewer
        /// Objective: 
        /// </summary>
        public void SendConnectMessage()
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendConnectMessage())
                return;

            //creating message
            ConnectMessage message = new ConnectMessage(this.myForm.Session.Key, this.myForm.Participant);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Roles: Contribuitor and Viewer
        /// Objective:
        /// </summary>
        public void SendDisconnectMessage()
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendDisconnectMessage())
                return;

            //creating message
            DisconnectMessage message = new DisconnectMessage(this.myForm.Session.Key, this.myForm.Participant);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }


        /// <summary>
        /// Send Role: Master
        /// Objective: 
        /// </summary>
        public void SendPingMessage()
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendPingMessage())
                return;

            //creating message
            PingMessage message = new PingMessage(this.myForm.Session.Key, this.myForm.Participant);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        #endregion

        #region Presentation

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="slideContributions"></param>
        public void SendDeckMessage(Deck deck, SlideContribution[] slideContributions)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendDeckMessage())
                return;
                      
            //sending message
            //Instead of sending the whole deck in one message, now we send one message for each slide of the deck
            //RTP is a protocol for transmission of small messages in a continuously way
            Guid previousGuid = Guid.Empty;
            int i = 0;
            foreach (Slide s in deck.Slides.List)
            {
                this.SendSlideMessage(s, previousGuid, slideContributions[i].ContributionComponent.Contributions, i, false);
                previousGuid = s.Guid;
                i++;
            }
        }

        /// <summary>
        /// Send Role: Master
        /// Objective: 
        /// </summary>
        /// <param name="slide"></param>
        /// <param name="previousSlideGuid"></param>
        /// <param name="contributions"></param>
        public void SendSlideMessage(Slide slide, Guid previousSlideGuid, Contributions contributions, int slideNo, bool updateSlide)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideMessage())
                return;
            //creating message
            SlideAddMessage message = new SlideAddMessage(this.myForm.Session.Key, this.myForm.Participant, slide, previousSlideGuid, contributions, slideNo, updateSlide);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message, "SlidesNo = " + slideNo.ToString());
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="slideGuid"></param>
        /// <param name="viewerSelect"></param>
        public void SendSlideSelectedMessage(Guid slideGuid, bool viewerSelect)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideSelectedMessage())
                return;
            //creating message
            SlideSelectedMessage message = new SlideSelectedMessage(this.myForm.Session.Key, this.myForm.Participant, slideGuid, viewerSelect);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="slideGuid"></param>
        public void SendSlideSelectedAttentionMessage(Guid slideGuid)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideSelectedAttentionMessage())
                return;
            //creating message
            SlideSelectedAttentionMessage message = new SlideSelectedAttentionMessage(this.myForm.Session.Key, this.myForm.Participant, slideGuid);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Master
        /// Objective: 
        /// </summary>
        /// <param name="slideGuid"></param>
        /// <param name="viewerSelect"></param>
        public void SendSlideSelectedContributionMessage(Guid slideGuid, bool viewerSelect)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideSelectedContributionMessage())
                return;
            //creating message
            SlideSelectedContributionMessage message = new SlideSelectedContributionMessage(this.myForm.Session.Key, this.myForm.Participant, slideGuid, viewerSelect);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Contribuitor
        /// Objective:
        /// </summary>
        /// <param name="slide"></param>
        /// <param name="contributions"></param>
        public void SendSlideSubmissionMessage(Slide slide, Contributions contributions)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideSubmissionMessage())
                return;
            //creating message
            SlideSubmissionMessage message = new SlideSubmissionMessage(this.myForm.Session.Key, this.myForm.Participant, slide, contributions);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="slide"></param>
        /// <param name="contributions"></param>
        public void SendSlideSubmissionMasterMessage(Slide slide, Contributions contributions)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendSlideSubmissionMasterMessage())
                return;
            //creating message
            SlideSubmissionMasterMessage message = new SlideSubmissionMasterMessage(this.myForm.Session.Key, this.myForm.Participant, slide, contributions);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        #endregion

        #region Contributions

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="slideGuid"></param>
        /// <param name="contribution"></param>
        public void SendContributionMessage(Guid slideGuid, ContributionBaseObject contribution)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendContributionMessage())
                return;
            //creating message
            ContributionAddMessage message = new ContributionAddMessage(this.myForm.Session.Key, this.myForm.Participant, slideGuid, contribution.Guid, contribution);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        /// <summary>
        /// Send Role: Master
        /// Objective:
        /// </summary>
        /// <param name="slideGuid"></param>
        /// <param name="contributionGuid"></param>
        public void SendContributionRemoveMessage(Guid slideGuid, Guid contributionGuid)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendContributionRemoveMessage())
                return;
            //creating message
            ContributionRemoveMessage message = new ContributionRemoveMessage(this.myForm.Session.Key, this.myForm.Participant, slideGuid, contributionGuid);

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        #endregion

        #region ContextInformation

        /// <summary>
        /// Send Role: Master
        /// Objective
        /// </summary>
        public void SendContextInformationRulesMessage(ContextInformationRule[] rules)
        {
            //Checking if participant is allowed to send messages
            if (!this.myForm.Participant.Role.SendContextInformationRulesMessage())
                return;

            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertNewMessageData(message);
#endif
            #endregion

            //creating message
            ContextInformationRulesMessage message = new ContextInformationRulesMessage(this.myForm.Session.Key, this.myForm.Participant, rules);
            //sending message
            this.myForm.CommunicationControl.messageSender.SendObject(message);
        }

        #endregion

        #region Ack

        public void SendAckMessage(int messageId, int type, string observations)
        {            
            #region Test
            #if Test
            AckMessageType ackType = AckMessageType.MESSAGE_RECEIVED;
            if (type == 1)
                ackType = AckMessageType.MESSAGE_PROCESSED;
            AckMessage message = new AckMessage(this.myForm.Session.Key, this.myForm.Participant, messageId, ackType, observations);
            this.myForm.CommunicationControl.messageSender.SendObject(message);
            #endif
            #endregion
        }

        #endregion

        #endregion

        #region Receive

        public void ReceiveMessage(Object obj)
        {
            //Casting to base message
            BaseMessage message = (BaseMessage)obj;

            this.myForm.InsertMessage("Received message: " + message.ToString());

            //checking if is still connected
            if (!this.myForm.Session.Connected)
                return;

            //checking key
            if (!message.Key.Equals(this.myForm.Session.Key))
                return;
            
            //Passing message to respect method...
            if (message is ConnectMessage)
            {
                this.ReceiveConnectMessage((ConnectMessage)message);
            }
            else if (message is DisconnectMessage)
            {
                this.ReceiveDisconnectMessage((DisconnectMessage)message);
            }
            else if (message is PingMessage)
            {
                this.ReceivePingMessage((PingMessage)message);
            }
            else if (message is DeckMessage)
            {
                // not used anymore!
                this.ReceiveDeckMessage((DeckMessage)message); 
            }
            else if (message is SlideSelectedContributionMessage)
            {
                this.ReceiveSlideSelectedContributionMessage((SlideSelectedContributionMessage)message);
            }
            else if (message is SlideSelectedMessage)
            {
                this.ReceiveSlideSelectedMessage((SlideSelectedMessage)message);
            }
            else if (message is SlideSelectedAttentionMessage)
            {
                this.ReceiveSlideSelectedAttentionMessage((SlideSelectedAttentionMessage)message);
            }
            else if (message is SlideSubmissionMasterMessage)
            {
                this.ReceiveSlideSubmissionMasterMessage((SlideSubmissionMasterMessage)message);
            }
            else if (message is SlideSubmissionMessage)
            {
                this.ReceiveSlideSubmissionMessage((SlideSubmissionMessage)message);
            }
            else if (message is SlideAddMessage)
            {
                this.ReceiveSlideAddMessage((SlideAddMessage)message);
            }
            else if (message is ContributionAddMessage)
            {
                this.ReceiveContributionMessage((ContributionAddMessage)message);
            }
            else if (message is ContributionRemoveMessage)
            {
                this.ReceiveContributionRemoveMessage((ContributionRemoveMessage)message);
            }
            else if (message is ContextInformationRulesMessage)
            {
                this.ReceiveContextInformationRulesMessage((ContextInformationRulesMessage)message);
            }
            else if (message is AckMessage)
            {
                this.ReceiveAckMessage((AckMessage)message);
            }
        }

        #region Connection

        /// <summary>
        /// Receive Role: Master
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveConnectMessage(ConnectMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveConnectMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //Adding participant...
            this.myForm.ParticipantsManager.Add(message.Sender);

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 1, "No: " + message.SlideNo);
#endif
            #endregion

        }

        /// <summary>
        /// Receive Role: Master
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveDisconnectMessage(DisconnectMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveDisconnectMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //Removing participant...
            this.myForm.ParticipantsManager.Remove(message.Sender);
        }

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceivePingMessage(PingMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceivePingMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            this.myForm.SendParticipant();
        }

        #endregion

        #region Presentation

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveDeckMessage(DeckMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveDeckMessage())
                return;
            
            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //Appending deck at main deck with contributions
            this.myForm.AppendDeckAtMainDeck(message.Deck, (this.myForm.Parameters.SyncMaster || this.myForm.MainDeck.Slides.Count == 0));
            foreach (SlideContribution slideContribution in message.SlideContributions)
            {
                this.myForm.AddContributions(slideContribution.SlideGuid, slideContribution.ContributionComponent.Contributions);
            }
        }

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideAddMessage(SlideAddMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "No: " + message.SlideNo);
#endif
            #endregion

            //adding slide and contributions
            bool update;
            if (!message.DeckSlide)
                update = (message.SlideNo == 0);
            else
                update = (this.myForm.Parameters.SyncMaster || this.myForm.MainDeck.Slides.Count == 0);
            this.myForm.InsertSlideAtMainDeck(message.Slide, message.PreviousSlideGuid, message.SlideNo, true, update);
            this.myForm.AddContributions(message.Slide.Guid, message.Contributions);
        }

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideSelectedMessage(SlideSelectedMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideSelectedMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //selectig slide at main deck            
            if (this.myForm.Participant.Role.ViewerSelection() && message.ViewerSelect)
            {
                this.myForm.SelectSlideAtMainDeck(message.SlideGuid, false);
            }
            else if (this.myForm.Participant.Role.SynchronizeMaster())
            {
                if (this.myForm.Parameters.SyncMaster)
                    this.myForm.SelectSlideAtMainDeck(message.SlideGuid, false);
                else
                    this.myForm.SetSyncSlideToView(message.SlideGuid);
            }
        }
        
        /// <summary>
        /// Receive Roles: Contribuitor
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideSelectedAttentionMessage(SlideSelectedAttentionMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideSelectedAttentionMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //selectig slide at main deck            
            if (this.myForm.Participant.Role.SynchronizeMaster())
            {
                if (this.myForm.Parameters.SyncMaster)
                    this.myForm.SelectSlideAtMainDeck(message.SlideGuid, false);
                else
                {
                    this.myForm.SetSyncSlideToView(message.SlideGuid);
                    this.myForm.SetSyncMasterAttention();
                }
            }
        }

        /// <summary>
        /// Receive Roles: Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideSelectedContributionMessage(SlideSelectedContributionMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideSelectedContributionMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //selectig slide at contribution deck            
            if (this.myForm.Participant.Role.ViewerSelection() && message.ViewerSelect)
            {
                this.myForm.SelectSlideAtContributionDeck(message.SlideGuid, false);
            }
        }

        /// <summary>
        /// Receiver Role: Master
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideSubmissionMessage(SlideSubmissionMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideSubmissionMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //adding slide submission
            if (this.myForm.Parameters.AllowSubmissions)
            {
                //Change values of slide
                this.myForm.InsertSlideAtContributionDeck(message.Slide, false);
                this.myForm.AddContributions(message.Slide.Guid, message.Contributions);
                //sending to viewer
                this.myForm.SendSubmissionToViewer(message.Slide.Guid);
            }
        }

        /// <summary>
        /// Receive Role: Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveSlideSubmissionMasterMessage(SlideSubmissionMasterMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveSlideSubmissionMasterMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //adding slide submission
            this.myForm.InsertSlideAtContributionDeck(message.Slide, false);
            this.myForm.AddContributions(message.Slide.Guid, message.Contributions);
        }

        #endregion

        #region Contributions

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveContributionMessage(ContributionAddMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveContributionMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //adding contributions
            Contributions contributions = new Contributions();
            contributions.InsertContribution(message.Contribution, false);
            this.myForm.AddContributions(message.SlideGuid, contributions);
        }

        /// <summary>
        /// Receive Role: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveContributionRemoveMessage(ContributionRemoveMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveContributionRemoveMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            //removing contribution
            this.myForm.RemoveContributionObject(message.SlideGuid, message.ContributionGuid);
        }

        #endregion

        #region ContextInformation

        /// <summary>
        /// Receive Roles: Contribuitor and Viewer
        /// Action:
        /// </summary>
        /// <param name="message"></param>
        private void ReceiveContextInformationRulesMessage(ContextInformationRulesMessage message)
        {
            //Checking if participant is allowed to Receive messages
            if (!this.myForm.Participant.Role.ReceiveContextInformationRulesMessage())
                return;

            #region Test
#if Test
            this.myForm.SendAckMessage(message.MessageId, 0, "");
#endif
            #endregion

            this.myForm.AppendContextInformationRules(message.Rules);
        }

        #endregion

        #region Ack

        private void ReceiveAckMessage(AckMessage message)
        {
            #region Test
#if Test
            TestManager manager = TestManager.getInstance();
            manager.InsertResponseMessageData(message, message.Observations);
#endif
            #endregion
        }

        #endregion

        #endregion

        #endregion
    }
}
