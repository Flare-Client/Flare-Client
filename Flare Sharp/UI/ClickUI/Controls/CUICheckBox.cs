using Flare_Sharp.ClientBase.Keybinds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI.Controls
{
    public class CUICheckBox : CUIControl
    {
        [DllImport("user32")]
        static extern bool GetCursorPos(out Point point);

        public EventHandler<EventArgs> onClick;
        bool toggle = false;
        public Brush currentBrush;
        public Brush uncheckedBrush;
        public Brush checkedBrush;
        Size size;
        int off = 3;

        public CUICheckBox(int size, Color uncheckedColor, Color checkedColor, Color color, int x, int y, CUIWindow parent) : base(color, x, y, parent)
        {
            KeybindHandler.clientKeyDownEvent += onKeyDown;
            KeybindHandler.clientKeyUpEvent += onKeyUp;
            this.uncheckedBrush = new SolidBrush(uncheckedColor);
            this.checkedBrush = new SolidBrush(checkedColor);
            this.currentBrush = uncheckedBrush;
            this.size = new Size(size, size);
        }

        public override void OnPaint(Graphics graphics)
        {
            base.OnPaint(graphics);
            graphics.FillRectangle(brush, x + parent.x, y + parent.y, size.Width, size.Height);
            graphics.FillRectangle(currentBrush, x + parent.x + 3, y + parent.y + 3, size.Width - 5, size.Height - 5);
        }

        public void onKeyDown(object sender, clientKeyEvent e)
        {
            if (e.key == 0x1)
            {
                Point p;
                GetCursorPos(out p);
                if (p.X > x + parent.r2dX && p.Y > y + parent.r2dY && p.X < size.Width + x + parent.r2dX && p.Y < size.Height + y + parent.r2dY)
                {
                    if (onClick != null)
                    {
                        TabUI.ui.Invalidate();
                        try
                        {
                            onClick.Invoke(this, new EventArgs());
                        }
                        catch (Exception) { }
                    }
                }
            }
        }
        private void onKeyUp(object sender, clientKeyEvent e)
        {
            toggle = !toggle;
            TabUI.ui.Invalidate();
        }
    }
}
