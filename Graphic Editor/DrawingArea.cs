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
        private Point _previousMousePosition;
        private bool _isDrawing = false;
        private bool _isMoving = false;
        private ToolType _currentTool = ToolType.Selection;
        private Shape _selectedShape;

        public DrawingArea()
        {
            BackColor = Color.White;
            DoubleBuffered = true;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetTool(ToolType tool)
        {
            _currentTool = tool;
            _selectedShape = null;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _startPoint = e.Location;
            _previousMousePosition = e.Location;
            _isDrawing = true;

            if (_currentTool == ToolType.Selection)
            {
                _selectedShape = null;
                foreach (var shape in _shapes)
                {
                    if (shape.Contains(e.Location))
                    {
                        _selectedShape = shape;
                        _isMoving = true;
                        break;
                    }
                }
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_currentTool == ToolType.Selection && _isMoving && _selectedShape != null)
            {
                int offsetX = e.Location.X - _previousMousePosition.X;
                int offsetY = e.Location.Y - _previousMousePosition.Y;

                _selectedShape.Move(offsetX, offsetY);

                _previousMousePosition = e.Location;

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isDrawing)
            {
                int width = Math.Abs(e.X - _startPoint.X);
                int height = Math.Abs(e.Y - _startPoint.Y);

                if (width > 5 && height > 5)
                {
                    if (_currentTool == ToolType.Rectangle)
                    {
                        var rect = new RectangleShape
                        {
                            Bounds = new Rectangle(
                                Math.Min(_startPoint.X, e.X),
                                Math.Min(_startPoint.Y, e.Y),
                                width,
                                height),
                            FillColor = Color.White,
                            StrokeColor = Color.Black,
                            StrokeWidth = 2
                        };
                        _shapes.Add(rect);
                    }
                    else if (_currentTool == ToolType.Ellipse)
                    {
                        var ellipse = new EllipseShape
                        {
                            Bounds = new Rectangle(
                                Math.Min(_startPoint.X, e.X),
                                Math.Min(_startPoint.Y, e.Y),
                                width,
                                height),
                            FillColor = Color.White,
                            StrokeColor = Color.Black,
                            StrokeWidth = 2
                        };
                        _shapes.Add(ellipse);
                    }
                    else if (_currentTool == ToolType.Triangle)
                    {
                        var triangle = new TriangleShape
                        {
                            Point1 = new Point(_startPoint.X + width / 2, _startPoint.Y),
                            Point2 = new Point(_startPoint.X, _startPoint.Y + height),
                            Point3 = new Point(_startPoint.X + width, _startPoint.Y + height),
                            FillColor = Color.White,
                            StrokeColor = Color.Black,
                            StrokeWidth = 2
                        };
                        _shapes.Add(triangle);
                    }
                }
            }

            _isDrawing = false;
            _isMoving = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in _shapes)
            {
                shape.Draw(e.Graphics);
            }

            if (_selectedShape != null)
            {
                using (var selectionPen = new Pen(Color.Red, 2)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                })
                {
                    if (_selectedShape is RectangleShape rect)
                    {
                        e.Graphics.DrawRectangle(selectionPen, rect.Bounds);
                    }
                    else if (_selectedShape is EllipseShape ellipse)
                    {
                        e.Graphics.DrawEllipse(selectionPen, ellipse.Bounds);
                    }
                    else if (_selectedShape is TriangleShape triangle)
                    {
                        Point[] points = { triangle.Point1, triangle.Point2, triangle.Point3 };
                        e.Graphics.DrawPolygon(selectionPen, points);
                    }
                }
            }
        }
    }
}