using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using iP4H.Commons.Session;
using iP4H.Commons.Participant;
using iP4H.Commons.SlideControl;

namespace iP4H.Commons.Messages
{
    [Serializable(Custom=true)]
    public class DeckMessage: Message, ICSerializable
    {
        #region Members

        private Deck deck; 

        #endregion

        #region Ctors
        public DeckMessage()
            : base()
        {
        }

        public DeckMessage(SessionKey key, ParticipantInfo sender, Deck deck)
            : base(key, sender)
        {
            this.deck = deck;
        }
        #endregion

        #region Props
        
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            deck = (Deck)parent.Deserialize(stream);
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, deck);
        }

        #endregion
    }
}
