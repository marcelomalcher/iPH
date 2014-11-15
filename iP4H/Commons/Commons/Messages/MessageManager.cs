using System;
using System.Collections.Generic;
using System.Text;
using iP4H.Commons.Intefaces;
using iP4H.Commons.Participant;
using iP4H.Commons.Participant.Role;
using iP4H.Commons.Session;
using iP4H.Commons.SlideControl;
using LAC.Contribution.Objects;

namespace iP4H.Commons.Messages
{
    public class MessageManager
    {
        #region Members

        private IForm myOwner;

        #endregion

        #region Ctor

        public MessageManager(IForm owner)
        {
            this.myOwner = owner;
        }

        #endregion

        #region Receive

        public void ReceiveObject(Object obj)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }             

            //if object is not a iP4H Message throw exception
            if (!(obj is Message))
            {
                throw new Exception("Object is not a iP4H Message ");
            }

            //Casting object receive to message for validation
            Message message = (Message)obj;

            //If participant is the sender discard message
            if (message.Sender.Equals(ParticipantInfo.Instance))
            {
                return;
            }

            //Checking if session key is the same
            if (!message.Key.Equals(SessionInfo.Instance.Key))
            {
                return;
            }

            //Start checking object
            if (obj is DeckMessage)
            {
                this.ReceiveDeckMessage((DeckMessage)obj);
            }
            else if (obj is SlideMessage)
            {
                if (obj is SlideAddMessage)
                {
                    this.ReceiveSlideAddMessage((SlideAddMessage)obj);
                }
                else if (obj is SlideRemoveMessage)
                {
                    this.ReceiveSlideRemoveMessage((SlideRemoveMessage)obj);
                }
                else if (obj is SlideSelectedMessage)
                {
                    this.ReceiveSlideSelectedMessage((SlideSelectedMessage)obj);
                }
            }
            else if (obj is ConnectMessage)
            {
                this.ReceiveConnectMessage((ConnectMessage)obj);
            }
            else if (obj is DisconnectMessage)
            {
                this.ReceiveDisconnectMessage((DisconnectMessage)obj);
            }
            else if (obj is ContributionMessage)
            {
                if (obj is ContributionAddMessage)
                {
                    this.ReceiveContributionAddMessage((ContributionAddMessage)obj);
                }
                else if (obj is ContributionRemoveMessage)
                {
                    this.ReceiveContributionRemoveMessage((ContributionRemoveMessage)obj);
                }                    
            }
            else
            {
                throw new Exception("Impossible to process message");
            }
        }


        private void ReceiveDeckMessage(DeckMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveDeckMessage())
            {
                this.myOwner.AppendDeck(this.myOwner.MainDeck, message.Deck);
            }
        }

        private void ReceiveSlideAddMessage(SlideAddMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveSlideAddMessage())
            {
                if (message.Sender.Role is Contribuitor)
                {
                    if (!(ParticipantInfo.Instance.Role is Contribuitor))
                    {
                        this.myOwner.InsertSlide(this.myOwner.ContributionDeck, message.Slide, message.PreviousSlideGuid);
                        if (message.Contributions != null)
                        {
                            this.myOwner.AddContributions(this.myOwner.ContributionDeck, message.Slide, message.Contributions);
                        }
                    }
                }
                else
                {
                    this.myOwner.InsertSlide(this.myOwner.MainDeck, message.Slide, message.PreviousSlideGuid);
                    if (message.Contributions != null)
                    {
                        this.myOwner.AddContributions(this.myOwner.MainDeck, message.Slide, message.Contributions);
                    }
                }
            }
        }

        private void ReceiveSlideRemoveMessage(SlideRemoveMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveSlideRemoveMessage())
            {
                this.myOwner.RemoveSlide(this.myOwner.MainDeck, message.Slide);
            }
        }

        private void ReceiveSlideSelectedMessage(SlideSelectedMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveSelectedSlideMessage())
            {
                Deck slideDeck = this.myOwner.GetSlideDeck(message.Slide);
                if (slideDeck != null)
                    this.myOwner.UpdateDeckSlide(slideDeck, message.Slide);
            }
        }

        private void ReceiveConnectMessage(ConnectMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveConnectMessage())
            {
                this.myOwner.AddParticipant(message.Sender);
            }
        }

        private void ReceiveDisconnectMessage(DisconnectMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveDisconnectMessage())
            {
                this.myOwner.RemoveParticipant(message.Sender);
            }
        }

        private void ReceiveContributionAddMessage(ContributionAddMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveContributionAddMessage())
            {
                Deck slideDeck = this.myOwner.GetSlideDeck(message.Slide);
                if (slideDeck != null)
                    this.myOwner.AddContribution(slideDeck, message.Slide, message.Contribution);
            }
        }

        private void ReceiveContributionRemoveMessage(ContributionRemoveMessage message)
        {
            if (ParticipantInfo.Instance.Role.ReceiveContributionRemoveMessage())
            {
                Deck slideDeck = this.myOwner.GetSlideDeck(message.Slide);
                if (slideDeck != null)
                    this.myOwner.RemoveContribution(slideDeck, message.Slide, message.Contribution);
            }
        }

        #endregion

        #region Send

        public void SendDeckMessage(Deck deck)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            DeckMessage message = new DeckMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, deck);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendSlideAddMessage(Slide slide, Guid previousSlideGuid, LAC.Contribution.Contributions contributions)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            SlideAddMessage message = new SlideAddMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, slide, previousSlideGuid, contributions);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendSlideRemoveMessage(Slide slide)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            SlideRemoveMessage message = new SlideRemoveMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, slide);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendSlideSelectedMessage(Slide slide, bool syncWithViewer)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            SlideSelectedMessage message = new SlideSelectedMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, slide, syncWithViewer);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendConnectMessage()
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            ConnectMessage message = new ConnectMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendDisconnectMessage()
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            DisconnectMessage message = new DisconnectMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendContributionAddMessage(Slide slide, ContributionBaseObject contribution)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            ContributionAddMessage message = new ContributionAddMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, slide, contribution);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        public void SendContributionRemoveMessage(Slide slide, ContributionBaseObject contribution)
        {
            //Checking if it is connected
            if (!SessionInfo.Instance.Connected)
            {
                return;
            }
            ContributionRemoveMessage message = new ContributionRemoveMessage(SessionInfo.Instance.Key, ParticipantInfo.Instance, slide, contribution);
            this.myOwner.MainControl.messageSender.SendObject(message);
        }

        #endregion
    }
}
