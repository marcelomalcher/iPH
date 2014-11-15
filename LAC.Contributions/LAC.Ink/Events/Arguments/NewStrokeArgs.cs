using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Ink.Events.Arguments
{
    public class NewStrokeArgs : EventArgs
    {
        private Stroke newStroke;

        public NewStrokeArgs(Stroke stroke)
        {
            this.newStroke = stroke;
        }

        public Stroke Stroke
        {
            get
            {
                return newStroke;
            }
        }
    }
}
