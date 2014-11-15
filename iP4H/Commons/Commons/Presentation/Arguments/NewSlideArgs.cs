using System;
using System.Collections.Generic;
using System.Text;
using iPH.Commons.Presentation;

namespace iPH.Commons.Presentation.Arguments
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
