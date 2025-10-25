using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public abstract class Shape
    {
        private Color _fillColor = Color.White;
        private Color _strokeColor = Color.Black;
        private float _strokeWidth = 2f;

        public Color FillColor
        {
            get => _fillColor;
            set => _fillColor = value;
        }

        public Color StrokeColor
        {
            get => _strokeColor;
            set => _strokeColor = value;
        }

        public float StrokeWidth
        {
            get => _strokeWidth;
            set => _strokeWidth = value >= 0 ? value : 0;
        }

        public abstract void Draw(Graphics graphics);
        public abstract bool Contains(Point point);

        public abstract void Move(int offsetX, int offsetY);
    }
}