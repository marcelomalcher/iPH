using System;
using System.Collections.Generic;
using System.Text;
using LAC.Ink.Enums;

namespace LAC.Ink.Interfaces
{
    public interface IInk
    {
        IStrokes Strokes { get; }

        void Load(byte[] inkData);

        byte[] Save();

        IStrokes CreateStrokes(Guid[] ids);

        IInk ExtractStrokes(IStrokes strokes, ExtractFlags extractionFlags);
    }
}
