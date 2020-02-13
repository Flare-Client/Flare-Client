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
    public class VAddButton : VObject
    {
        public event EventHandler clicked;
        public VAddButton() : base()
        {
            this.text = "+";

            //We have to register this manually
            OverlayHost.ui.Paint += (object sender, PaintEventArgs e) =>
            {
                if (visible)
                {
                    OnPaint(e);
                }
            };
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(secondary, objRect);
            e.Graphics.DrawString(text, font, primary, x + width / 2 - font.Size / 2, y);
        }

        public override void OnInteractUp(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (a.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (objRect.Contains(p))
                {
                    if (clicked != null)
                    {
                        clicked.Invoke(this, new EventArgs());
                    }
                }
            }
        }
    }
}
