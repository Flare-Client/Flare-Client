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
        public string text = "";
        public Font font;
        public CUILabel(string text, string fontFamily, float fontSize, FontStyle fontStyle, Color color, int x, int y, CUIWindow parent) : base(color, x, y, parent)
        {
            this.text = text;
            this.font = new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Pixel);
        }

        public override void OnPaint(Graphics graphics)
        {
            base.OnPaint(graphics);
            graphics.DrawString(text, font, brush, x+parent.x, y+parent.y+2);
        }
    }
}
