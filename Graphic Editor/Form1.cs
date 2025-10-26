using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class Form1 : Form
    {
        private ToolPanel _toolPanel;
        private DrawingArea _drawingArea;

        public Form1()
        {
            InitializeComponent();

            _toolPanel = new ToolPanel();
            _drawingArea = new DrawingArea();

            _drawingArea.Dock = DockStyle.Fill;
            Controls.Add(_drawingArea);

            _toolPanel.ToolChanged += (tool) => _drawingArea.SetTool(tool);
            _toolPanel.FillColorChanged += (color) => _drawingArea.SetFillColor(color);

            UpdateColorButton(_toolPanel.CurrentFillColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tsbCursor_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Selection);
        }

        private void tsbRectangle_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Rectangle);
        }

        private void tsbEllipse_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Ellipse);
        }

        private void tsbTriangle_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Triangle);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Delete);
        }

        private void tsbColorFill_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = _toolPanel.CurrentFillColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _toolPanel.SetFillColor(colorDialog.Color);
                UpdateColorButton(colorDialog.Color);
            }
        }

        private void UpdateColorButton(Color color)
        {
            Bitmap colorImage = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(colorImage))
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, 0, 0, 16, 16);
                    g.DrawRectangle(Pens.Black, 0, 0, 15, 15);
                }
            }

            tsbColorFill.Image = colorImage;
            tsbColorFill.ToolTipText = $"Цвет заливки: {color.Name}";
        }

        private void tsbBrush_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Brush);
        }
    }
}