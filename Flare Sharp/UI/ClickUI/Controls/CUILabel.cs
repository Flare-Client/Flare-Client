using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI.Controls
{
    public class CUILabel : CUIControl
    {
        string text = "";
        Font font;
        Brush brush;
        int x;
        int y;
        CUIWindow parent;
        public CUILabel(string text, Font font, Color color, int x, int y, CUIWindow parent) : base()
        {
            this.text = text;
            this.font = font;
            this.brush = new SolidBrush(color);
            this.x = x;
            this.y = y;
            this.parent = parent;
        }

        public override void OnPaint(Graphics graphics)
        {
            base.OnPaint(graphics);
            graphics.DrawString(text, font, brush, x+parent.x, y+parent.y);
        }
    }
}
