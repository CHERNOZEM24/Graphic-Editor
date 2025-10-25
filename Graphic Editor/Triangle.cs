using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class TriangleShape : Shape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public override void Draw(Graphics graphics)
        {
            Point[] points = { Point1, Point2, Point3 };

            using (var fillBrush = new SolidBrush(FillColor))
            using (var strokePen = new Pen(StrokeColor, StrokeWidth))
            {
                graphics.FillPolygon(fillBrush, points);
                graphics.DrawPolygon(strokePen, points);
            }
        }

        public override bool Contains(Point point)
        {
            var bounds = GetBounds();
            return bounds.Contains(point);
        }

        public override void Move(int offsetX, int offsetY)
        {
            Point1 = new Point(Point1.X + offsetX, Point1.Y + offsetY);
            Point2 = new Point(Point2.X + offsetX, Point2.Y + offsetY);
            Point3 = new Point(Point3.X + offsetX, Point3.Y + offsetY);
        }

        private Rectangle GetBounds()
        {
            int minX = Math.Min(Point1.X, Math.Min(Point2.X, Point3.X));
            int minY = Math.Min(Point1.Y, Math.Min(Point2.Y, Point3.Y));
            int maxX = Math.Max(Point1.X, Math.Max(Point2.X, Point3.X));
            int maxY = Math.Max(Point1.Y, Math.Max(Point2.Y, Point3.Y));

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
