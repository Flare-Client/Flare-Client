using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIControl
    {
        public int x;
        public int y;
        public Brush brush;
        public Pen pen;
        public CUIWindow parent;
        public CUIControl(Color color, int x, int y, CUIWindow parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;
            this.brush = new SolidBrush(color);
            this.pen = new Pen(color);
        }

        public virtual void OnPaint(Graphics graphics)
        {

        }
    }
}
