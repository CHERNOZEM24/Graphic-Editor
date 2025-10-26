using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public class DrawingArea : Panel
    {
        private List<Shape> _shapes = new List<Shape>();
        private Point _startPoint;
        private Point _previousMousePosition;
        private bool _isDrawing = false;
        private bool _isMoving = false;
        private bool _isBrushDrawing = false;
        private bool _isErasing = false;
        private ToolType _currentTool = ToolType.Selection;
        private Shape _selectedShape;
        private FreehandShape _currentFreehand;
        private EraserShape _currentEraser;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CurrentFillColor { get; set; } = Color.White;

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

        public void SetFillColor(Color color)
        {
            CurrentFillColor = color;
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
            else if (_currentTool == ToolType.Delete)
            {
                for (int i = _shapes.Count - 1; i >= 0; i--)
                {
                    if (_shapes[i].Contains(e.Location))
                    {
                        _shapes.RemoveAt(i);
                        Invalidate();
                        break;
                    }
                }
            }
            else if (_currentTool == ToolType.Brush)
            {
                _isBrushDrawing = true;
                _currentFreehand = new FreehandShape
                {
                    StrokeColor = Color.Black,
                    StrokeWidth = 3
                };
                _currentFreehand.Points.Add(e.Location);
                _shapes.Add(_currentFreehand);
            }
            else if (_currentTool == ToolType.Eraser)
            {
                _isErasing = true;
                _currentEraser = new EraserShape
                {
                    EraserSize = 10f
                };
                _currentEraser.Points.Add(e.Location);
                _shapes.Add(_currentEraser);
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
            else if (_currentTool == ToolType.Brush && _isBrushDrawing && _currentFreehand != null)
            {
                _currentFreehand.Points.Add(e.Location);
                Invalidate();
            }
            else if (_currentTool == ToolType.Eraser && _isErasing && _currentEraser != null)
            {
                _currentEraser.Points.Add(e.Location);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isDrawing)
            {
                if (_currentTool == ToolType.Brush)
                {
                    _isBrushDrawing = false;
                    _currentFreehand = null;
                }
                else if (_currentTool == ToolType.Eraser)
                {
                    _isErasing = false;
                    _currentEraser = null;
                }
                else
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
                                FillColor = CurrentFillColor,
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
                                FillColor = CurrentFillColor,
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
                                FillColor = CurrentFillColor,
                                StrokeColor = Color.Black,
                                StrokeWidth = 2
                            };
                            _shapes.Add(triangle);
                        }
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
                    else if (_selectedShape is FreehandShape freehand)
                    {
                        var bounds = GetFreehandBounds(freehand);
                        e.Graphics.DrawRectangle(selectionPen, bounds);
                    }
                }
            }
        }

        private Rectangle GetFreehandBounds(FreehandShape freehand)
        {
            if (freehand.Points.Count == 0) return Rectangle.Empty;

            int minX = freehand.Points[0].X;
            int minY = freehand.Points[0].Y;
            int maxX = freehand.Points[0].X;
            int maxY = freehand.Points[0].Y;

            foreach (var point in freehand.Points)
            {
                if (point.X < minX) minX = point.X;
                if (point.Y < minY) minY = point.Y;
                if (point.X > maxX) maxX = point.X;
                if (point.Y > maxY) maxY = point.Y;
            }

            int padding = (int)freehand.StrokeWidth + 2;
            return new Rectangle(minX - padding, minY - padding,
                               maxX - minX + padding * 2, maxY - minY + padding * 2);
        }
    }
}