using System;
using CF.MSR.LST.ConferenceXP;

namespace CCXP.Capabilities.CP.Ink
{
    [Capability.Name("Chat")]
    [Capability.PayloadType(PayloadType.Chat)]
    [Capability.FormType(typeof(InkFMain))]
    [Capability.Channel(true)]
    [Capability.BackgroundSender(true)]
    [Capability.Fec(true)]
    [Capability.FecRatio(0, 50)]
    public class InkCapability : CapabilityWithWindow, ICapabilitySender, ICapabilityViewer
    {
        // Required ctor for ICapabilitySender
        public InkCapability()
            : base()
        {
            // Instance name
            name = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a topic for the collaboration.",
                "Topic",
                "Ink",
                0, 0);

            // Do something minimal for the case in which cancel is pressed
            if (name == "")
            {
                name = "Ink";
            }
        }

        // Required ctor for ICapabilityViewer
        public InkCapability(DynamicProperties dynaProps) : base(dynaProps) { }

        /// <summary>
        /// Chat is a 2 way capability (it is always a sender and receiver)
        /// So when we are initialized to Play, make sure we Send also
        /// </summary>
        public override void Play()
        {
            base.Play();

            Send();
        }

        /// <summary>
        /// Chat is a 2 way capability (it is always a sender and receiver)
        /// So when we StopPlaying, make sure we StopSending also
        /// </summary>
        public override void StopPlaying()
        {
            base.StopPlaying();

            StopSending();
        }
    }
}