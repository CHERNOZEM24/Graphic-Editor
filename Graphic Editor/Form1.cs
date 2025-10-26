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

            SetupToolbarButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SetupToolbarButtons()
        {
            if (toolStrip1.Items.Count == 0) return;

            int buttonWidth = (toolStrip1.Width - 20) / toolStrip1.Items.Count; 

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton button)
                {
                    button.AutoSize = false;
                    button.Height = 45; 
                    button.Width = buttonWidth;
                    button.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    button.TextImageRelation = TextImageRelation.ImageAboveText;
                    button.Font = new Font("Segoe UI", 7F, FontStyle.Bold); 

                    switch (button.Name)
                    {
                        case "tsbCursor": button.Text = "Курсор"; break;
                        case "tsbBrush": button.Text = "Кисть"; break;
                        case "tsbEraser": button.Text = "Ластик"; break;
                        case "tsbRectangle": button.Text = "Прямоуг."; break;
                        case "tsbEllipse": button.Text = "Круг"; break;
                        case "tsbTriangle": button.Text = "Треуг."; break;
                        case "tsbDelete": button.Text = "Удалить"; break;
                        case "tsbColorFill": button.Text = "Цвет"; break;
                    }
                }
            }
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

        private void tsbEraser_Click(object sender, EventArgs e)
        {
            _toolPanel.SelectTool(ToolType.Eraser);
        }
    }
}