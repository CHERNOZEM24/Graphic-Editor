using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class DrawingArea : Panel
    {
        private List<Shape> _shapes = new List<Shape>();
        private Point _startPoint;
        private bool _isDrawing = false;

        public DrawingArea()
        {
            BackColor = Color.White;
            DoubleBuffered = true; 
            BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _startPoint = e.Location;
            _isDrawing = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isDrawing)
            {
                var rect = new RectangleShape
                {
                    Bounds = new Rectangle(
                        Math.Min(_startPoint.X, e.X),
                        Math.Min(_startPoint.Y, e.Y),
                        Math.Abs(e.X - _startPoint.X),
                        Math.Abs(e.Y - _startPoint.Y)),
                    FillColor = Color.White,
                    StrokeColor = Color.Black,
                    StrokeWidth = 2
                };

                _shapes.Add(rect);
                Invalidate();
            }
            _isDrawing = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in _shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }
}
