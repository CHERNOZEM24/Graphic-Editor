using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class RectangleShape : Shape
    {
        public Rectangle Bounds { get; set; }

        public override void Draw(Graphics graphics)
        {
            using (var fillBrush = new SolidBrush(FillColor))
            using (var strokePen = new Pen(StrokeColor, StrokeWidth))
            {
                graphics.FillRectangle(fillBrush, Bounds);
                graphics.DrawRectangle(strokePen, Bounds);
            }
        }

        public override bool Contains(Point point)
        {
            return Bounds.Contains(point);
        }
    }
}