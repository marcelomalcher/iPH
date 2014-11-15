using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class SubmitModificationsFunction: BaseFunction
    {
        #region Singleton
        private static SubmitModificationsFunction mySelf;
        public static SubmitModificationsFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new SubmitModificationsFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public SubmitModificationsFunction()
            : base()
        {
        }
        #endregion

        #region Methods

        public override bool IsEnabled()
        {
            return true;
        }

        protected override string GetName()
        {
            return "Submit Modifications Function";
        }

        protected override string GetDescription()
        {
            return "Ability to send modifications.";
        }

        #endregion

    }
}
