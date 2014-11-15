using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class PresentationEditionFunction: BaseFunction
    {
        #region Singleton
        private static PresentationEditionFunction mySelf;
        public static PresentationEditionFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new PresentationEditionFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public PresentationEditionFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Presentation Edition Function";
        }

        protected override string GetDescription()
        {
            return "Appending an IDD file, creating and removing slides and so on.";
        }

        #endregion

    }
}
