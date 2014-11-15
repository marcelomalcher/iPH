using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Ink.Interfaces
{
    public interface IExtendedProperty
    {
        object Data { get; set; }
        Guid Id { get; }
    }
}
