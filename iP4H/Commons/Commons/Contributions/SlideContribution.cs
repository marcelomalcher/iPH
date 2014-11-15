using System;
using System.Collections.Generic;
using System.Text;
using iP4H.Commons.SlideControl;
using LAC.Contribution;

namespace iP4H.Commons.Contributions
{
    public class SlideContribution
    {
        #region Members

        private Slide mySlide;
        
        private ContributionComponent myContribution;

        #endregion

        #region Ctor

        public SlideContribution(Slide slide, ContributionComponent contributionComponent)
        {
            this.mySlide = slide;
            this.myContribution = contributionComponent;
        }

        #endregion

        #region Properties

        public Slide Slide
        {
            get
            {
                return this.mySlide;
            }
            set
            {
                this.mySlide = value;
            }
        }

        public ContributionComponent ContributionComponent
        {
            get
            {
                return this.myContribution;
            }
            set
            {
                this.myContribution = value;
            }
        }

        #endregion

    }
}
