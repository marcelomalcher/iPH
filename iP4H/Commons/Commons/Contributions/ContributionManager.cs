using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using iP4H.Commons.SlideControl;
using LAC.Contribution;
using LAC.Contribution.Enums;


namespace iP4H.Commons.Contributions
{
    public class ContributionManager
    {
        #region Members

        private static ContributionManager mySelf;

        private ArrayList myList;

        //Enabled
        private bool isEnabled = false;        
        //Action Type
        private ActionType myAction = ActionType.InkWriteType;
        //Ink
        //Color
        private Color myInkColor = Color.Black;
        //Width
        private int myInkWidth = 1;
        //Text
        //Font
        private Font myTextFont = new Font("Arial", 10, FontStyle.Regular);
        //Color
        private Color myTextColor = Color.Black;

        #endregion

        #region Instance

        public static ContributionManager Instance
        {
            get
            {
                if (mySelf == null)
                {
                    mySelf = new ContributionManager();
                }
                return mySelf;
            }
        }

        #endregion

        #region Ctor

        private ContributionManager()
        {
            this.myList = new ArrayList();
        }

        #endregion

        #region Properties

        public bool Enabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
                this.SetEnabled(this.isEnabled);
            }
        }

        public ActionType Action
        {
            get
            {
                return this.myAction;
            }
            set
            {
                this.myAction = value;
                this.SetAction(this.myAction);
            }
        }

        public int InkWidth
        {
            get
            {
                return this.myInkWidth;
            }
            set
            {
                this.myInkWidth = value;
                this.SetInkWidth(this.myInkWidth);
            }
        }

        public Color InkColor
        {
            get
            {
                return this.myInkColor;
            }
            set
            {
                this.myInkColor = value;
                this.SetInkColor(this.myInkColor);
            }
        }

        public Font TextFont
        {
            get
            {
                return this.myTextFont;
            }
            set
            {
                this.myTextFont = value;
                this.SetTextFont(this.myTextFont);
            }
        }

        public Color TextColor
        {
            get
            {
                return this.myTextColor;
            }
            set
            {
                this.myTextColor = value;
                this.SetTextColor(this.myTextColor);
            }
        }

        #endregion

        #region Methods

        public void Clear()
        {
            this.myList.Clear();
        }

        public void AddSlideContribution(Slide slide, ContributionComponent contributionComponent)
        {
            if (this.GetSlideContribution(slide) == null)
            {
                contributionComponent.Enabled = false;
                contributionComponent.InkColor = this.InkColor;
                contributionComponent.InkWidth = this.InkWidth;
                contributionComponent.TextFont = this.TextFont;
                contributionComponent.TextColor = this.TextColor;
                this.myList.Add(new SlideContribution(slide, contributionComponent));
            }
        }

        public void RemoveSlideContribution(Slide slide)
        {
            SlideContribution slideContribution = this.GetSlideContribution(slide);
            if (slideContribution != null)
            {
                this.myList.Remove(slideContribution);
            }
        }

        public ContributionComponent GetContributionComponent(Slide slide)
        {
            if (slide != null)
            {
                SlideContribution slideContribution = this.GetSlideContribution(slide);
                if (slideContribution != null)
                {
                    return slideContribution.ContributionComponent;
                }
            }
            return null;
        }

        public Slide GetSlide(ContributionComponent contributionComponent)
        {
            if (contributionComponent != null)
            {
                SlideContribution slideContribution = this.GetSlideContribution(contributionComponent);
                if (slideContribution != null)
                {
                    return slideContribution.Slide;
                }
            }
            return null;
        }

        private SlideContribution GetSlideContribution(Slide slide)
        {
            if (slide != null)
            {
                return this.GetSlideContributionFromSlide(slide.Guid);
            }
            return null;
        }

        private SlideContribution GetSlideContributionFromSlide(Guid guid)
        {
            if (guid != null)
            {
                foreach (SlideContribution slideContribution in this.myList)
                {
                    if (slideContribution.Slide.Guid.Equals(guid))
                    {
                        return slideContribution;
                    }
                }
            }
            return null;
        }

        private SlideContribution GetSlideContribution(ContributionComponent contributionComponent)
        {
            if (contributionComponent != null)
            {
                return this.GetSlideContributionFromContributionComponent(contributionComponent.Guid);
            }
            return null;
        }

        private SlideContribution GetSlideContributionFromContributionComponent(Guid guid)
        {
            if (guid != null)
            {
                foreach (SlideContribution slideContribution in this.myList)
                {
                    if (slideContribution.ContributionComponent.Guid.Equals(guid))
                    {
                        return slideContribution;
                    }
                }
            }
            return null;
        }

        #endregion

        #region ContributionComponent methods

        private void SetEnabled(bool enabled)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.Enabled = enabled;
            }
        }

        private void SetAction(ActionType action)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.Action = action;
            }
        }

        private void SetInkWidth(int width)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.InkWidth = width;
            }
        }

        private void SetInkColor(Color color)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.InkColor = color;
            }
        }

        private void SetTextFont(Font font)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.TextFont = font;
            }
        }

        private void SetTextColor(Color color)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.TextColor = color;
            }
        }

        #endregion
    }
}
