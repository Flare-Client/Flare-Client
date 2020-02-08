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
    public class VWindowBase : VObject
    {
        public bool dragging = false;
        int dx = 0;
        int dy = 0;

        public VWindowBase(int x) : base()
        {
            this.x = x;
            this.width = 200;
            this.height = 25;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(primary, objRect);
            e.Graphics.DrawString(text, font, secondary, objRect.X, objRect.Y);
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (e.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (objRect.Contains(p))
                {
                    dx = p.X - objRect.X;
                    dy = p.Y - objRect.Y;
                    this.dragging = true;
                }
            }
        }
        public override void OnInteractHeld(clientKeyEvent e)
        {
            base.OnInteractHeld(e);
            if (this.dragging)
            {
                if (e.key == 0x1)
                {
                    Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                    x = p.X - dx;
                    y = p.Y - dy;
                    OverlayHost.ui.Invalidate();
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent e)
        {
            base.OnInteractUp(e);
            if (e.key == 0x1)
            {
                this.dragging = false;
                OverlayHost.ui.Invalidate();
            }
        }
    }
}
