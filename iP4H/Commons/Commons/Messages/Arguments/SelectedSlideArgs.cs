using System;
using System.Collections.Generic;
using System.Text;
using iP4H.Commons.SlideControl;

namespace iP4H.Commons.SlideControl.Arguments
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