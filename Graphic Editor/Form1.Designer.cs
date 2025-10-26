namespace Graphic_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            tsbCursor = new ToolStripButton();
            tsbBrush = new ToolStripButton();
            tsbEraser = new ToolStripButton();
            tsbRectangle = new ToolStripButton();
            tsbEllipse = new ToolStripButton();
            tsbTriangle = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            tsbColorFill = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Height = 50;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbCursor, tsbBrush, tsbEraser, tsbRectangle, tsbEllipse, tsbTriangle, tsbDelete, tsbColorFill });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(922, 27);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbCursor
            // 
            tsbCursor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbCursor.Image = (Image)resources.GetObject("tsbCursor.Image");
            tsbCursor.ImageTransparentColor = Color.Magenta;
            tsbCursor.Name = "tsbCursor";
            tsbCursor.Size = new Size(29, 24);
            tsbCursor.Text = "Cursor";
            tsbCursor.Click += tsbCursor_Click;
            // 
            // tsbBrush
            // 
            tsbBrush.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBrush.Image = (Image)resources.GetObject("tsbBrush.Image");
            tsbBrush.ImageTransparentColor = Color.Magenta;
            tsbBrush.Name = "tsbBrush";
            tsbBrush.Size = new Size(29, 24);
            tsbBrush.Text = "Brush";
            tsbBrush.Click += tsbBrush_Click;
            // 
            // tsbEraser
            // 
            tsbEraser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEraser.Image = (Image)resources.GetObject("tsbEraser.Image");
            tsbEraser.ImageTransparentColor = Color.Magenta;
            tsbEraser.Name = "tsbEraser";
            tsbEraser.Size = new Size(29, 24);
            tsbEraser.Text = "Eraser";
            tsbEraser.Click += tsbEraser_Click;
            // 
            // tsbRectangle
            // 
            tsbRectangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRectangle.Image = (Image)resources.GetObject("tsbRectangle.Image");
            tsbRectangle.ImageTransparentColor = Color.Magenta;
            tsbRectangle.Name = "tsbRectangle";
            tsbRectangle.Size = new Size(29, 24);
            tsbRectangle.Text = "Rectangle";
            tsbRectangle.Click += tsbRectangle_Click;
            // 
            // tsbEllipse
            // 
            tsbEllipse.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEllipse.Image = (Image)resources.GetObject("tsbEllipse.Image");
            tsbEllipse.ImageTransparentColor = Color.Magenta;
            tsbEllipse.Name = "tsbEllipse";
            tsbEllipse.Size = new Size(29, 24);
            tsbEllipse.Text = "Ellipse";
            tsbEllipse.Click += tsbEllipse_Click;
            // 
            // tsbTriangle
            // 
            tsbTriangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbTriangle.Image = (Image)resources.GetObject("tsbTriangle.Image");
            tsbTriangle.ImageTransparentColor = Color.Magenta;
            tsbTriangle.Name = "tsbTriangle";
            tsbTriangle.Size = new Size(29, 24);
            tsbTriangle.Text = "Triangle";
            tsbTriangle.Click += tsbTriangle_Click;
            // 
            // tsbDelete
            // 
            tsbDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDelete.Image = (Image)resources.GetObject("tsbDelete.Image");
            tsbDelete.ImageTransparentColor = Color.Magenta;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(29, 24);
            tsbDelete.Text = "Delete";
            tsbDelete.Click += tsbDelete_Click;
            // 
            // tsbColorFill
            // 
            tsbColorFill.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbColorFill.Image = (Image)resources.GetObject("tsbColorFill.Image");
            tsbColorFill.ImageTransparentColor = Color.Magenta;
            tsbColorFill.Name = "tsbColorFill";
            tsbColorFill.Size = new Size(29, 24);
            tsbColorFill.Text = "toolStripButton1";
            tsbColorFill.Click += tsbColorFill_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 450);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Graphic Editor";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbCursor;
        private ToolStripButton tsbBrush;
        private ToolStripButton tsbEraser;
        private ToolStripButton tsbRectangle;
        private ToolStripButton tsbEllipse;
        private ToolStripButton tsbTriangle;
        private ToolStripButton tsbDelete;
        private ToolStripButton tsbColorFill;
    }
}
