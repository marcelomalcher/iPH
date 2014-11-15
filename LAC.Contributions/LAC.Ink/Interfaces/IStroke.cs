using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAC.Ink.Interfaces
{
    public interface IStroke
    {
        Guid Id { get; }
        IInk Ink { get; }
        IExtendedProperties ExtendedProperties { get; }
        bool IntersectPoint(Point point, double radius);
        void ScaleStroke(int originalWidth, int originalHeight, int newWidth, int newHeight); 
    }
}
