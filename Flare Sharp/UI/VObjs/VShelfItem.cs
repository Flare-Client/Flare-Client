using Flare_Sharp.ClientBase.Keybinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI.VObjs
{
    public class VShelfItem : VObject
    {
        public bool expanded = false;
        int expandedAmt = 100;
        public VShelfItem(int shelfHeight)
        {
            this.height = shelfHeight;
            this.width = 200;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(text, font, primary, x, y);
            if (expanded)
            {
                e.Graphics.DrawString("-", font, primary, x+width-font.Size, y);
            }
            else
            {
                e.Graphics.DrawString("+", font, primary, x + width - font.Size, y);
            }
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (a.key == 0x2)
            {
                expanded = !expanded;
                if (expanded)
                    height += expandedAmt;
                else
                    height -= expandedAmt;
                OverlayHost.ui.Invalidate();
            }
        }
    }
}
