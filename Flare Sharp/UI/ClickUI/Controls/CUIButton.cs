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
    public class CUIButton : CUILabel
    {
        [DllImport("user32")]
        static extern bool GetCursorPos(out Point point);

        public EventHandler<EventArgs> onClick;
        public Brush currentBrushBG;
        public Brush bgBrush;
        public Brush bgClickedBrush;
        Size size;
        public CUIButton(string text, string fontFamily, float fontSize, FontStyle fontStyle, Color foreground, Color background, Color backgroundClicked, int x, int y, CUIWindow parent) : base(text, fontFamily, fontSize, fontStyle, foreground, x, y, parent)
        {
            KeybindHandler.clientKeyDownEvent += onKeyDown;
            KeybindHandler.clientKeyUpEvent += onKeyUp;
            this.bgBrush = new SolidBrush(background);
            this.bgClickedBrush = new SolidBrush(backgroundClicked);
        }

        private void onKeyUp(object sender, clientKeyEvent e)
        {
            currentBrushBG = bgBrush;
            TabUI.ui.Invalidate();
        }

        public void onKeyDown(object sender, clientKeyEvent e)
        {
            if (e.key == 0x1)
            {
                Point p;
                GetCursorPos(out p);
                if (p.X > x + parent.r2dX && p.Y > y + parent.r2dY && p.X < size.Width + x + parent.r2dX && p.Y < size.Height + y + parent.r2dY)
                {
                    currentBrushBG = bgClickedBrush;
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

        public override void OnPaint(Graphics graphics)
        {
            size = graphics.MeasureString(text, font, 8000).ToSize();
            graphics.FillRectangle(currentBrushBG, x + parent.x, y + parent.y, size.Width, size.Height);
            base.OnPaint(graphics);
        }
    }
}
