using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graphic_Editor
{
    public class FreehandShape : Shape
    {
        public List<Point> Points { get; set; } = new List<Point>();

        public override void Draw(Graphics graphics)
        {
            if (Points.Count < 2) return;

            using (var pen = new Pen(StrokeColor, StrokeWidth))
            {
                graphics.DrawLines(pen, Points.ToArray());
            }
        }

        public override bool Contains(Point point)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                if (IsPointNearLine(point, Points[i], Points[i + 1]))
                    return true;
            }
            return false;
        }

        public override void Move(int offsetX, int offsetY)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X + offsetX, Points[i].Y + offsetY);
            }
        }

        private bool IsPointNearLine(Point point, Point lineStart, Point lineEnd)
        {
            double distance = DistanceToLineSegment(point, lineStart, lineEnd);
            return distance <= StrokeWidth + 3; 
        }

        private double DistanceToLineSegment(Point point, Point lineStart, Point lineEnd)
        {
            double lineLength = Distance(lineStart, lineEnd);
            if (lineLength == 0) return Distance(point, lineStart);

            double t = Math.Max(0, Math.Min(1,
                ((point.X - lineStart.X) * (lineEnd.X - lineStart.X) +
                 (point.Y - lineStart.Y) * (lineEnd.Y - lineStart.Y)) / (lineLength * lineLength)));

            double projectionX = lineStart.X + t * (lineEnd.X - lineStart.X);
            double projectionY = lineStart.Y + t * (lineEnd.Y - lineStart.Y);

            return Distance(point, new Point((int)projectionX, (int)projectionY));
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}