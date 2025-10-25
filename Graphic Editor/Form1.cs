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
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }
    }
}