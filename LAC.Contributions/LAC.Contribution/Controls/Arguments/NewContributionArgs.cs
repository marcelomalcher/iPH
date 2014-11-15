using System;
using System.Collections.Generic;
using System.Text;
using LAC.Contribution.Objects;

namespace LAC.Contribution.Arguments
{
    public class NewContributionArgs : EventArgs
    {
        #region Members

        private ContributionBaseObject myContributionBaseObject;

        #endregion

        #region Ctors

        public NewContributionArgs(ContributionBaseObject contributionBaseObject)
        {
            this.myContributionBaseObject = contributionBaseObject;
        }

        #endregion

        #region Properties

        public ContributionBaseObject Object
        {
            get
            {
                return this.myContributionBaseObject;
            }
        }

        #endregion
    }
}
