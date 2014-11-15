using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class PresentationSendFunction: BaseFunction
    {
        #region Singleton
        private static PresentationSendFunction mySelf;
        public static PresentationSendFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new PresentationSendFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public PresentationSendFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Presentation Send Function";
        }

        protected override string GetDescription()
        {
            return "Ability to send presentation itens.";
        }

        #endregion

    }
}
