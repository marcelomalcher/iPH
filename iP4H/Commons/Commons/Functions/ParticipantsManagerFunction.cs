using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class ParticipantsManagerFunction: BaseFunction
    {
        #region Singleton
        private static ParticipantsManagerFunction mySelf;
        public static ParticipantsManagerFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new ParticipantsManagerFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public ParticipantsManagerFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Participants Manager Function";
        }

        protected override string GetDescription()
        {
            return "Management of participants";
        }

        #endregion

    }
}
