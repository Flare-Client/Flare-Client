using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

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

        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            FormattedText ftext = DrawUtils.stringToFormatted(text, "Roboto", 16, secondary);
            e.DrawText(ftext, new Point(x, y));
            if (expandable)
            {
                if (expanded)
                {
                    FormattedText dditext = DrawUtils.stringToFormatted("-", "Roboto", 16, secondary);
                    e.DrawText(dditext, new Point(x + width - 16, y));
                    double paintOffset = 0;
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
                    FormattedText dditext = DrawUtils.stringToFormatted("+", "Roboto", 16, secondary);
                    e.DrawText(dditext, new Point(x + width - 16, y));
                }
            }
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (a.key == 0x2)
            {
                Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
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
                    OverlayHost.ui.repaint();
                }
            }
        }
    }
}
