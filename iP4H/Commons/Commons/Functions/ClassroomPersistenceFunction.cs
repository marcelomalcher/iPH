using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable]
    public class ClassroomPersistenceFunction: BaseFunction
    {
        #region Singleton
        private static ClassroomPersistenceFunction mySelf;
        public static ClassroomPersistenceFunction Intance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new ClassroomPersistenceFunction();
                return mySelf;
            }
        }
        #endregion

        #region Ctor
        public ClassroomPersistenceFunction()
            : base()
        {
        }
        #endregion

        #region Name & Description

        protected override string GetName()
        {
            return "Classroom Persistence Function";
        }

        protected override string GetDescription()
        {
            return "Functions like Open, Close and Save current classroom collaboration.";
        }

        #endregion

    }
}
