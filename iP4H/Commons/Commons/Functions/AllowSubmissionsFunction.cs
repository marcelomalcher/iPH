using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iP4H.Commons.Functions
{
    [Serializable]
    public class AllowSubmissionsFunctions: BaseFunction
    {
        #region Singleton
        private static AllowSubmissionsFunctions mySelf;
        public static AllowSubmissionsFunctions Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new AllowSubmissionsFunctions();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public AllowSubmissionsFunctions()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Allow Submissions Function";
        }

        protected override string GetDescription()
        {
            return "Decides if allow submissions of other participants";
        }

        #endregion

    }
}
