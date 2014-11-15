using System;
using System.Collections.Generic;
using System.Text;
using LAC.Ink.Interfaces;

namespace LAC.Ink
{
    class ExtendedProperty : IExtendedProperty
    {
        #region Attributes
        private Guid id;
        private Object data;
        #endregion

        #region Constructor
        public ExtendedProperty(Object data)
        {
            this.id = Guid.NewGuid();
            this.data = data;
        }

        public ExtendedProperty(Guid id, Object data)
        {
            this.id = id;
            this.data = data; 
        }
        #endregion

        #region IExtendedProperty Members

        public object Data
        {
            get
            {
                return data; 
            }
            set
            {
                data = value;
            }
        }

        public Guid Id
        {
            get 
            {
                return id;
            }
        }

        #endregion
    }
}
