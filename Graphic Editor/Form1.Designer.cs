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
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            tsbRectangle = new ToolStripButton();
            tsbEllipse = new ToolStripButton();
            tsbTriangle = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbCursor, toolStripButton2, toolStripButton3, tsbRectangle, tsbEllipse, tsbTriangle, tsbDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(922, 27);
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
            tsbCursor.Text = "toolStripButton1";
            tsbCursor.Click += tsbCursor_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // tsbRectangle
            // 
            tsbRectangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRectangle.Image = (Image)resources.GetObject("tsbRectangle.Image");
            tsbRectangle.ImageTransparentColor = Color.Magenta;
            tsbRectangle.Name = "tsbRectangle";
            tsbRectangle.Size = new Size(29, 24);
            tsbRectangle.Text = "toolStripButton4";
            tsbRectangle.Click += tsbRectangle_Click;
            // 
            // tsbEllipse
            // 
            tsbEllipse.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEllipse.Image = (Image)resources.GetObject("tsbEllipse.Image");
            tsbEllipse.ImageTransparentColor = Color.Magenta;
            tsbEllipse.Name = "tsbEllipse";
            tsbEllipse.Size = new Size(29, 24);
            tsbEllipse.Text = "toolStripButton5";
            tsbEllipse.Click += tsbEllipse_Click;
            // 
            // tsbTriangle
            // 
            tsbTriangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbTriangle.Image = (Image)resources.GetObject("tsbTriangle.Image");
            tsbTriangle.ImageTransparentColor = Color.Magenta;
            tsbTriangle.Name = "tsbTriangle";
            tsbTriangle.Size = new Size(29, 24);
            tsbTriangle.Text = "toolStripButton6";
            tsbTriangle.Click += tsbTriangle_Click;
            // 
            // tsbDelete
            // 
            tsbDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDelete.Image = (Image)resources.GetObject("tsbDelete.Image");
            tsbDelete.ImageTransparentColor = Color.Magenta;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(29, 24);
            tsbDelete.Text = "toolStripButton1";
            tsbDelete.Click += tsbDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 450);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbCursor;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton tsbRectangle;
        private ToolStripButton tsbEllipse;
        private ToolStripButton tsbTriangle;
        private ToolStripButton tsbDelete;
    }
}
