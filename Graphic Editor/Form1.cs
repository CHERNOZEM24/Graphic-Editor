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
    }
}