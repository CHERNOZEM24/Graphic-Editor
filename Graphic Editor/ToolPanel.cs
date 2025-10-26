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
        private Color _currentFillColor = Color.White; 

        public ToolType CurrentTool
        {
            get => _currentTool;
            private set
            {
                _currentTool = value;
                ToolChanged?.Invoke(value);
            }
        }

        public Color CurrentFillColor
        {
            get => _currentFillColor;
            set
            {
                _currentFillColor = value;
                FillColorChanged?.Invoke(value);
            }
        }

        public void SelectTool(ToolType tool)
        {
            CurrentTool = tool;
        }

        public void SetFillColor(Color color)
        {
            CurrentFillColor = color;
        }

        public event Action<ToolType> ToolChanged;
        public event Action<Color> FillColorChanged; 
    }

    public enum ToolType
    {
        Selection,
        Rectangle,
        Ellipse,
        Triangle,
        Line,
        Delete
    }
}