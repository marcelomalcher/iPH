using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Ink.Interfaces
{
    public interface IStrokes
    {
        int Count { get; }

        IStroke this[int index] { get; }

        IStroke GetStroke(Guid guid); 

        void ScaleStrokes(int originalWidth, int originalHeight, int newWidth, int newHeight);
    }
}
