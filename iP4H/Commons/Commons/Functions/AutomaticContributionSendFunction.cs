using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iP4H.Commons.Functions
{
    [Serializable]
    public class AutomaticContributionSendFunction: BaseFunction
    {
        #region Singleton
        private static AutomaticContributionSendFunction mySelf;
        public static AutomaticContributionSendFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new AutomaticContributionSendFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public AutomaticContributionSendFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Automatic Contribution Send Function";
        }

        protected override string GetDescription()
        {
            return "The ability to send each contribution when its finished.";
        }

        #endregion

    }
}
