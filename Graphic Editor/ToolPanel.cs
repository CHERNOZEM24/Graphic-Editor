using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Editor
{
    public class ToolPanel
    {
        private ToolType _currentTool = ToolType.Selection;

        public ToolType CurrentTool
        {
            get => _currentTool;
            private set
            {
                _currentTool = value;
                ToolChanged?.Invoke(value);
            }
        }

        public void SelectTool(ToolType tool)
        {
            CurrentTool = tool;
        }

        public event Action<ToolType> ToolChanged;
    }

    public enum ToolType
    {
        Selection,
        Rectangle,
        Ellipse, 
        Triangle,
        Line,
        Delete,
    }
}