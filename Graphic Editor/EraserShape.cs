using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class EraserShape : Shape
    {
        public List<Point> Points { get; set; } = new List<Point>();
        public float EraserSize { get; set; } = 10f;

        public override void Draw(Graphics graphics)
        {
            if (Points.Count < 2) return;

            using (var pen = new Pen(Color.White, EraserSize))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                graphics.DrawLines(pen, Points.ToArray());
            }
        }

        public override bool Contains(Point point)
        {
            return false;
        }

        public override void Move(int offsetX, int offsetY)
        {
        }
    }
}
