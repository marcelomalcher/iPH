using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using LAC.Contribution;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace LAC.Contribution.Objects
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Stroke : ContributionBaseObject, ICSerializable, ICloneable
    {
        #region Members

        //Array of points
        private Point[] myPoints;
        private Point[] myOriginalPoints;
        //Color
        private Color myColor;
        //Width
        private int myWidth;
       
        #endregion

        #region Constructors

        //No-args constructor
        public Stroke()
            : base()
        {
        }

        public Stroke(int baseWidth, int baseHeight, Point[] points, Color color, int width)
            : base(baseWidth, baseHeight)
        {
            this.myPoints = points;
            this.myOriginalPoints = (Point[])this.myPoints.Clone();
            this.myColor = color;            
            this.myWidth = width;
        }

        #endregion

        #region Properties

        //Points
        public Point[] Points
        {
            get
            {
                return this.myPoints;
            }
            set
            {
                this.myPoints = value;
            }
        }

        //Color
        public Color Color
        {
            get
            {
                return this.myColor;
            }
            set
            {
                this.myColor = value;
            }
        }
        
        //Width
        public int Width
        {
            get
            {
                return this.myWidth;
            }
            set
            {
                this.myWidth = value;
            }
        }

        #endregion               

        #region Draw

        public override void Draw(Graphics graphicControl)
        {
            if (this.myPoints.Length <= 1)
                return;
            Pen drawPen = new Pen(this.Color, this.Width);
            for (int i = 1; i < this.myPoints.Length; i++)
                graphicControl.DrawLine(drawPen, this.myPoints[i - 1].X, this.myPoints[i - 1].Y, this.myPoints[i].X, this.myPoints[i].Y);
            drawPen.Dispose();
        }

        #endregion

        #region Intersect

        public override bool IntersectObject(Point point, double radius)
        {
            for (int i = 1; i < this.myPoints.Length; i++)
            {
                if (this.StrokeIntersect(this.myPoints[i - 1], this.myPoints[i], point, radius))
                    return true;
            }
            return false ;
        }

        private bool StrokeIntersect(Point point1, Point point2, Point sourcePoint, double radius)
        {
            double a, b, c;
            double result;

            int deltaX, deltaY;

            deltaX = Math.Abs(point2.X - point1.X);
            deltaY = Math.Abs(point2.Y - point1.Y);

            a = deltaX * deltaX + deltaY * deltaY;

            b = 2 * (deltaX * (point1.X - sourcePoint.X) + deltaY * (point1.Y - sourcePoint.Y));

            c = sourcePoint.X * sourcePoint.X + sourcePoint.Y * sourcePoint.Y;
            c += point1.X * point1.X + point1.Y * point1.Y;
            c -= 2 * (sourcePoint.X * point1.X + sourcePoint.Y * point1.Y);
            c -= radius * radius;

            result = (b * b) - (4 * a * c);

            if ((result <= 0) || (a == 0))
                return false;
            else
                return true;
        }


        #endregion

        #region Scale

        public override void ScaleObject(int newWidth, int newHeight)        
        {
            //Copying original points...
            this.myPoints = (Point[])this.myOriginalPoints.Clone();

            double relWidth = (double)newWidth / (double)this.BaseWidth;
            double relHeight = (double)newHeight / (double)this.BaseHeight;

            for (int i = 0; i < this.myPoints.Length; i++)
            {
                this.myPoints[i].X = (int)Math.Round(relWidth * (double)this.myPoints[i].X, 0);
                this.myPoints[i].Y = (int)Math.Round(relHeight * (double)this.myPoints[i].Y, 0);
            }

        }

        #endregion

        #region ICSerializable Members

        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            //color
            int cColorR = (byte)parent.Deserialize(stream);
            int cColorG = (byte)parent.Deserialize(stream);
            int cColorB = (byte)parent.Deserialize(stream);
            //width
            int cWidth = (int)parent.Deserialize(stream);
            //points
            int cPointsCount = (int)parent.Deserialize(stream);
            Point[] cPoints = new Point[cPointsCount];
            for (int i = 0; i < cPointsCount; i++)
            {
                //X
                int X = (int)parent.Deserialize(stream);
                //Y
                int Y = (int)parent.Deserialize(stream);
                //new point
                cPoints[i] = new Point(X, Y);
            }

            this.myColor = Color.FromArgb(cColorR, cColorG, cColorB);
            this.myWidth = cWidth;
            this.myPoints = cPoints;
            this.myOriginalPoints = (Point[])this.myPoints.Clone();
        }

        public override void SendObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            base.SendObjectData(parent, stream);
            //Color
            parent.Serialize(stream, this.myColor.R);
            parent.Serialize(stream, this.myColor.G);
            parent.Serialize(stream, this.myColor.B);
            //Width
            parent.Serialize(stream, this.myWidth);
            //Quantity of Points
            parent.Serialize(stream, this.myPoints.Length);
            //Points
            foreach (Point p in this.myOriginalPoints)
            {
                //X
                parent.Serialize(stream, p.X);
                //Y
                parent.Serialize(stream, p.Y);
            }
        }

        #endregion

        #region ICloneable Members

        public override object Clone()
        {
            Stroke newInstance = new Stroke();
            //Base
            newInstance.Guid = this.Guid;
            newInstance.BaseWidth = this.BaseWidth;
            newInstance.BaseHeight = this.BaseHeight;
            newInstance.Timestamp = this.Timestamp;
            //Stroke
            newInstance.myColor = Color.FromArgb(this.myColor.R, this.myColor.G, this.myColor.B) ;
            newInstance.myWidth = this.myWidth;
            newInstance.myPoints = (Point[])this.myPoints.Clone();
            newInstance.myOriginalPoints = (Point[])this.myOriginalPoints.Clone();
            return newInstance;   
        }

        #endregion

    }
}
