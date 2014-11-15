using System;
using System.Collections.Generic;
using System.Text;
using iPH.Commons.Presentation;

namespace iPH.Commons.Presentation.Arguments
{
    public class SelectedSlideArgs: EventArgs
    {
        private Slide selectedSlide;

        public SelectedSlideArgs(Slide slide)
        {
            this.selectedSlide = slide;
        }

        public Slide Slide
        {
            get
            {
                return selectedSlide;
            }
        }
    }
}