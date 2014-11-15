using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iP4H.Commons.Functions
{
    [Serializable]
    public class SyncPresentationFunction: BaseFunction
    {
        #region Singleton
        private static SyncPresentationFunction mySelf;
        public static SyncPresentationFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new SyncPresentationFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public SyncPresentationFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Sync Presentation Function";
        }

        protected override string GetDescription()
        {
            return "Decides if remains synchronized with the current presentation";
        }

        #endregion

    }
}
