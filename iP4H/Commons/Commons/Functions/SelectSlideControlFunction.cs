using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iP4H.Commons.Functions
{
    [Serializable]
    public class SelectSlideControlFunction: BaseFunction
    {
        #region Singleton
        private static SelectSlideControlFunction mySelf;
        public static SelectSlideControlFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new SelectSlideControlFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public SelectSlideControlFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Select Slide Control Function";
        }

        protected override string GetDescription()
        {
            return "Controls wich slide will be visualized by other participants";
        }

        #endregion

    }
}
