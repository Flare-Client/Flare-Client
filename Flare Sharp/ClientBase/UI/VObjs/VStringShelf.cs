
using Flare_Sharp.ClientBase.Keybinds;
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
                    Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
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
                else if (a.key >= 0x30 && a.key <= 0x5A)
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

        public override void OnPaint(PaintEventArgs e)
        {
            if (!deleted)
            {
                e.Graphics.FillRectangle(secondary, objRect);
                base.OnPaint(e);
            }
        }
    }
}
