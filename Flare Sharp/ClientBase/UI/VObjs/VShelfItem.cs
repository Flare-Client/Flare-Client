using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VShelfItem : VObject
    {
        public List<VSubShelfItem> children = new List<VSubShelfItem>();
        public bool expandable = true;
        public bool expanded = false;

        public VShelfItem(int shelfHeight, bool expandable)
        {
            this.expandable = expandable;
            this.height = shelfHeight;
            this.width = 200;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(text, font, primary, x, y);
            if (expandable)
            {
                if (expanded)
                {
                    e.Graphics.DrawString("-", font, primary, x + width - font.Size, y);
                    int paintOffset = 0;
                    foreach (VSubShelfItem subShelf in children)
                    {
                        paintOffset += subShelf.height;
                        subShelf.x = x + 5;
                        subShelf.y = y + paintOffset;
                        subShelf.OnPaint(e);
                    }
                }
                else
                {
                    e.Graphics.DrawString("+", font, primary, x + width - font.Size, y);
                }
            }
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (a.key == 0x2)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (objRect.Contains(p))
                {
                    expanded = !expanded;
                    if (expanded)
                    {
                        height += children.Count * 24;
                    }
                    else
                    {
                        height -= children.Count * 24;
                    }
                    OverlayHost.ui.Invalidate();
                }
            }
        }
    }
}
