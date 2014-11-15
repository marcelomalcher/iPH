using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using LAC.Ink.Interfaces;
using LAC.Ink.Functions;

namespace LAC.Ink
{
    public class Stroke : IStroke
    {
        #region Attributes

        //ID
        private Guid id;
        //Ink owner
        private Ink ink;
        //Array of points
        private Point[] points;
        //Color
        private Color color;
        //Transparency - 0 to 255
        private int transparency;
        //Dash Style
        private DashStyle dashStyle;
        //Width
        private int width;
        //
        private ExtendedProperties extendedProperties;

        #endregion

        #region Constructors

        //No-args constructor
        public Stroke()
        {
            id = System.Guid.NewGuid();
        }

        public Stroke(Ink ink, Point[] points, Color color, int transparency, DashStyle dashStyle, int width)
            : this()
        {
            this.ink = ink;
            this.color = color;
            this.transparency = transparency;
            this.points = points;
            this.dashStyle = dashStyle;
            this.width = width;
            this.extendedProperties = new ExtendedProperties();
        }

        public Stroke(Ink ink, Point[] points, Color color, int transparency, DashStyle dashStyle, int width, Guid id)
        {
            this.id = id;
            this.ink = ink;
            this.color = color;
            this.transparency = transparency;
            this.points = points;
            this.dashStyle = dashStyle;
            this.width = width;
            this.extendedProperties = new ExtendedProperties();
        }

        #endregion

        #region Properties

        //Points
        public Point[] Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        //Color
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        
        //Transparency
        public int Transparency
        {
            get
            {
                return transparency;
            }
            set
            {
                if (value < 0)
                    transparency = 0;
                else if (value > 255)
                    transparency = 255;
                else
                    transparency = value;
            }
        }

        //DashStyle
        public DashStyle DashStyle
        {
            get
            {
                return dashStyle;
            }
            set
            {
                dashStyle = value;
            }
        }

        //Width
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        #endregion

        #region IStroke Members

        public Guid Id
        {
            get 
            {
                return id;
            }
        }

        public IInk Ink
        {
            get 
            {
                return ink;
            }
        }

        public IExtendedProperties ExtendedProperties
        {
            get 
            {
                return extendedProperties;
            }
        }

        #endregion

        #region Events

        public bool IntersectPoint(Point point, double radius)
        {
            for (int i = 1; i < points.Length; i++)
            {
                if (StrokePoints.Intersection(points[i-1], points[i], point, radius))
                {
                    return true;
                }
            }
            return false ;
        }

        public void ScaleStroke(int originalWidth, int originalHeight, int newWidth, int newHeight)        
        {
            double rWidth = (double)newWidth / (double)originalWidth;
            double rHeight = (double)newHeight / (double)originalHeight;
            double rSize = (double)(newWidth + newHeight) / (double)(originalWidth + originalHeight);

            this.width = (int)Math.Round(this.width * rSize);
            for (int i = 0; i < this.Points.Length; i++)
            {
                this.Points[i].X = (int)Math.Round(this.Points[i].X * rWidth);
                this.Points[i].Y = (int)Math.Round(this.Points[i].Y * rHeight);
            }
        }

        #endregion
    }
}
