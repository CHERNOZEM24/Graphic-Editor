using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class EllipseShape : Shape
    {
        public Rectangle Bounds { get; set; }

        public override void Draw(Graphics graphics)
        {
            using (var fillBrush = new SolidBrush(FillColor))
            using (var strokePen = new Pen(StrokeColor, StrokeWidth))
            {
                graphics.FillEllipse(fillBrush, Bounds);
                graphics.DrawEllipse(strokePen, Bounds);
            }
        }

        public override bool Contains(Point point)
        {
            var center = new PointF(Bounds.X + Bounds.Width / 2f, Bounds.Y + Bounds.Height / 2f);
            var dx = point.X - center.X;
            var dy = point.Y - center.Y;
            return (dx * dx) / (Bounds.Width * Bounds.Width / 4f) +
                   (dy * dy) / (Bounds.Height * Bounds.Height / 4f) <= 1;
        }

        public override void Move(int offsetX, int offsetY)
        {
            Bounds = new Rectangle(
                Bounds.X + offsetX,
                Bounds.Y + offsetY,
                Bounds.Width,
                Bounds.Height
            );
        }
    }
}
