using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VWindowBase : VObject
    {
        public bool dragging = false;
        double dx = 0;
        double dy = 0;

        public VWindowBase(double x) : base()
        {
            this.x = x;
            this.width = 200;
            this.height = 25;
        }

        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            e.DrawRectangle(primary, null, objRect);
            FormattedText ftext = DrawUtils.stringToFormatted(text, "Roboto", 16, primary);
            e.DrawText(ftext, new Point(objRect.X, objRect.Y));
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (e.key == 0x1)
            {
                Point p = new Point(GetMousePosition().X - OverlayHost.ui.Left, GetMousePosition().Y - OverlayHost.ui.Top);
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
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.Left, GetMousePosition().Y - OverlayHost.ui.Top);
                    x = p.X - dx;
                    y = p.Y - dy;
                    OverlayHost.ui.repaint();
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent e)
        {
            base.OnInteractUp(e);
            if (e.key == 0x1)
            {
                this.dragging = false;
                OverlayHost.ui.repaint();
            }
        }
    }
}
