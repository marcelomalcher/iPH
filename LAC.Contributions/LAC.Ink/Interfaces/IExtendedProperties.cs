using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Ink.Interfaces
{
    public interface IExtendedProperties
    {
        IExtendedProperty this[Guid id] { get; }
        IExtendedProperty this[int index] { get; }

        IExtendedProperty Add(Guid id, object data);

        bool DoesPropertyExist(Guid id);
    }
}
