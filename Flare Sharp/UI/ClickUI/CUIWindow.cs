using Flare_Sharp.ClientBase.Keybinds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIWindow
    {
        [DllImport("user32")]
        static extern bool GetCursorPos(out Point point);

        public List<CUIControl> controls = new List<CUIControl>();
        public int x;
        public int y;
        public int width = 400;
        public int height = 300;
        int dx;
        int dy;
        public bool visible;

        public CUIWindow()
        {
            KeybindHandler.clientKeyDownEvent += startDrag;
            KeybindHandler.clientKeyHeldEvent += doDrag;
            KeybindHandler.clientKeyUpEvent += stopDrag;
            ClickUiHandler.instance.windows.Add(this);
        }

        private void startDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (e.key == 0x1)
                {
                    Point p;
                    GetCursorPos(out p);
                    if (p.X > x && p.Y > y && p.X < width + x && p.Y < height + y)
                    {
                        dx = p.X - x;
                        dy = p.Y - y;
                    }
                }
            }
        }
        private void doDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (e.key == 0x1)
                {
                    Point p;
                    GetCursorPos(out p);
                    x = p.X - dx;
                    y = p.Y - dy;
                }
            }
        }
        private void stopDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (e.key == 0x1)
                {
                    TabUI.ui.Invalidate();
                }
            }
        }

        public virtual void OnPaint(Graphics graphics)
        {
            if (visible)
            {
                graphics.FillRectangle(TabUI.ui.tertiary, x, y, width, height);
                foreach (CUIControl control in controls)
                {
                    control.OnPaint(graphics);
                }
            }
        }
    }
}
