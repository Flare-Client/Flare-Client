using Flare_Remastered.Client;
using Flare_Remastered.Client.Keybinds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Remastered.Client.VObjs
{
    public class VAddButton : VObject
    {
        public event EventHandler clicked;
        public VAddButton() : base()
        {
            this.text = "+";

            //We have to regis.ui.Paintter this manually
            OverlayHost.onRender += (object sender, PaintEventArgs e) =>
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
                Point p = new Point(Cursor.Position.X - OverlayHost.overlayForm.Left, Cursor.Position.Y - OverlayHost.overlayForm.Top);
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
