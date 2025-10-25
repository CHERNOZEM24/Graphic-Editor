using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class ToolPanel
    {
        public ToolType CurrentTool { get; set; } = ToolType.Rectangle;

        public void SelectTool(ToolType tool)
        {
            CurrentTool = tool;
        }
    }

    public enum ToolType
    {
        Selection,
        Rectangle,
        Ellipse,
        Line
    }
}