using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class VWindowBase : VObject
    {
        int x = 0;
        int y = 0;
        int width = 200;
        public abstract int height { get; }

        public Rectangle titleBox
        {
            get
            {
                return new Rectangle(x, y, width, 25);
            }
        }
        public Rectangle frame
        {
            get
            {
                return new Rectangle(x, y+25, width, height);
            }
        }

        public bool dragging = false;
        int dx = 0;
        int dy = 0;

        public VWindowBase() : base()
        {
        }
        public VWindowBase(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public VWindowBase(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y; 
            this.width = width;
        }


        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(primary, titleBox);
            e.Graphics.FillRectangle(secondary, frame);
            e.Graphics.DrawString(text, font, secondary, titleBox.X, titleBox.Y);
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (e.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (titleBox.Contains(p))
                {
                    dx = p.X - titleBox.X;
                    dy = p.Y - titleBox.Y;
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
