using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VStringShelf : VShelfItem
    {
        public bool deleted = false;
        bool editing = false;
        public VStringShelf() : base(24, false)
        {
            text = "player";
        }

        public override void OnInteractUp(clientKeyEvent a)
        {
            if (!deleted)
            {
                base.OnInteractUp(a);
                if (a.key == 0x1)
                {
                    if (text[text.Length - 1] == '|')
                    {
                        text = text.Remove(text.Length - 1);
                        if (text.Length == 0)
                        {
                            deleted = true;
                        }
                        editing = false;
                    }
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
                    if (objRect.Contains(p))
                    {
                        editing = true;
                        text += "|";
                    }
                }
                if (a.key == 0x8)
                {
                    if (editing)
                    {
                        text = text.Remove(text.Length - 2) + "|";
                    }
                }
                else if (a.key > 0x30 && a.key < 0x5A)
                {
                    if (editing)
                    {
                        char typed = a.key;
                        if (!KeybindHandler.isKeyDown((char)0x10))
                        {
                            typed += (char)0x20;
                        }
                        text = text.Remove(text.Length - 1) + typed + "|";
                    }
                }
            }
        }

        public override void OnPaint(DrawingContext e)
        {
            if (!deleted)
            {
                e.DrawRectangle(primary, null, objRect);
                base.OnPaint(e);
            }
        }
    }
}
