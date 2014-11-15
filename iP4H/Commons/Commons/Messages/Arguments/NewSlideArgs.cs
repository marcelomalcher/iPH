using System;
using System.Collections.Generic;
using System.Text;
using iP4H.Commons.SlideControl;

namespace iP4H.Commons.SlideControl.Arguments
{
    public class NewSlideArgs : EventArgs
    {
        private Slide newSlide;

        private int index;

        public NewSlideArgs(Slide slide, int index)
        {
            this.newSlide = slide;
            this.index = index;
        }

        public Slide Slide
        {
            get
            {
                return newSlide;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }
    }
}
