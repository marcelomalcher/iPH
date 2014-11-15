using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAC.Ink.Functions
{
    public static class StrokePoints
    {
        public static bool Intersection(Point point1, Point point2, Point sourcePoint, double radius)
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
    }
}
