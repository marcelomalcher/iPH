using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class ContributionFunction: BaseFunction
    {
        #region Singleton
        private static ContributionFunction mySelf;
        public static ContributionFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new ContributionFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public ContributionFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Contribution Function";
        }

        protected override string GetDescription()
        {
            return "Ability to make contributions.";
        }

        #endregion

    }
}
