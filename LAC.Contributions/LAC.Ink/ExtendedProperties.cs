using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using LAC.Ink.Interfaces;

namespace LAC.Ink
{
    public class ExtendedProperties : IExtendedProperties
    {
        #region Attributes
        ArrayList extendedProperties;
        #endregion

        #region Constructor
        public ExtendedProperties()
        {
            extendedProperties = new ArrayList();
        }
        #endregion

        #region IExtendedProperties Members

        public IExtendedProperty this[Guid id]
        {
            get 
            {
                foreach (ExtendedProperty ep in extendedProperties)
                {
                    if (ep.Id.Equals(id))
                        return ep;
                }
                return null;
            }
        }

        public IExtendedProperty this[int index]
        {
            get 
            {
                if (index >= extendedProperties.Count)
                    return null;
                return (IExtendedProperty)extendedProperties[index];
            }
        }

        public IExtendedProperty Add(Guid id, object data)
        {
            IExtendedProperty extendedProperty = new ExtendedProperty(id, data);
            extendedProperties.Add(extendedProperty);
            return extendedProperty;
        }

        public bool DoesPropertyExist(Guid id)
        {
            foreach (ExtendedProperty ep in extendedProperties)
            {
                if (ep.Id.Equals(id))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
