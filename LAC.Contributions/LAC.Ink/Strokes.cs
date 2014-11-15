using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LAC.Ink.Interfaces;

namespace LAC.Ink
{
    public class Strokes : IStrokes
    {
        #region Attributes
        //Array of strokes
        private ArrayList strokes;
        #endregion

        #region Constructor
        public Strokes()
        {
            this.strokes = new ArrayList();
        }

        #endregion

        #region Events
        public void Add(IStroke stroke)
        {
            this.strokes.Add(stroke);
        }

        public void Remove(IStroke stroke)
        {
            this.strokes.Remove(stroke);
        }

        public void Clear()
        {
            this.strokes.Clear();
        }

        public ArrayList StrokeLines
        {
            get
            {
                return strokes;
            }
        }

        public IStroke GetStroke(Guid guid)
        {
            foreach (IStroke stroke in strokes)
            {
                if (stroke.Id.Equals(guid))
                {
                    return stroke;
                }
            }
            return null;
        }

        public void ScaleStrokes(int originalWidth, int originalHeight, int newWidth, int newHeight)
        {
            foreach (IStroke stroke in strokes)
            {
                stroke.ScaleStroke(originalWidth, originalHeight, newWidth, newHeight);
            }
        }

        #endregion

        #region IStrokes Members

        public int Count
        {
            get
            {
                return this.strokes.Count; 
            }
        }

        public IStroke this[int index]
        {
            get 
            {
                if (index >= this.strokes.Count)
                    return null;
                return (IStroke)this.strokes[index];
            }
        }

        #endregion


    }
}
