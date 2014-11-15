using System;
using System.Collections.Generic;
using System.Text;
using iP4H.Commons.SlideControl;

namespace iP4H.Commons.SlideControl.Arguments
{
    public class SlidesRemovedArgs: EventArgs
    {
        private Slide[] slidesRemoved;

        public SlidesRemovedArgs(Slide slide)
        {
            slidesRemoved = new Slide[1];
            this.slidesRemoved[0] = slide;
        }

        public SlidesRemovedArgs(Slide[] slides)
        {
            this.slidesRemoved = slides;
        }

        public Slide[] Slides
        {
            get
            {
                return slidesRemoved;
            }
        }

        public int Count
        {
            get
            {
                return slidesRemoved.Length;
            }
        }
    }
}
