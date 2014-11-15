using System;
using System.Collections.Generic;
using System.Text;
using LAC.Contribution.Objects;

namespace LAC.Contribution.Arguments
{
    public class ContributionRemovedArgs: EventArgs
    {
        #region Members

        private ContributionBaseObject[] myContributionBaseObjects;

        #endregion

        #region Ctors

        public ContributionRemovedArgs(ContributionBaseObject contributionBaseObject)
        {
            this.myContributionBaseObjects = new ContributionBaseObject[1];
            this.myContributionBaseObjects[0] = contributionBaseObject;
        }

        public ContributionRemovedArgs(ContributionBaseObject[] contributionBaseObjects)
        {
            this.myContributionBaseObjects = contributionBaseObjects;
        }

        #endregion

        #region Properties

        public ContributionBaseObject[] Objects
        {
            get
            {
                return this.myContributionBaseObjects;
            }
        }

        public int Count
        {
            get
            {
                return this.myContributionBaseObjects.Length;
            }
        }

        #endregion
    }
}
