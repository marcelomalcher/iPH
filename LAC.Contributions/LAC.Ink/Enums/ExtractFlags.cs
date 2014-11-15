using System;

namespace LAC.Ink.Enums
{
    [Flags]
    public enum ExtractFlags
    {
        CopyFromOriginal = 0,
        RemoveFromOriginal = 1,
        Default = 1,
    }
}

