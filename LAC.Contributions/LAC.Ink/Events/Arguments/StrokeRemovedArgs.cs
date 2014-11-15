using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Ink.Events.Arguments
{
    public class StrokeRemovedArgs: EventArgs
    {
        private Stroke[] strokesRemoved;

        public StrokeRemovedArgs(Stroke stroke)
        {
            strokesRemoved = new Stroke[1];
            this.strokesRemoved[0] = stroke;
        }

        public StrokeRemovedArgs(Stroke[] strokes)
        {
            this.strokesRemoved = strokes;
        }

        public Stroke[] Strokes
        {
            get
            {
                return strokesRemoved;
            }
        }

        public int Count
        {
            get
            {
                return strokesRemoved.Length;
            }
        }
    }
}
