using Flare_Sharp.UI.ClickUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public class CUIClosableWindow : CUIWindow
    {
        bool open = false;
        public CUIClosableWindow(bool open) : base()
        {
            this.visible = open;
            this.width = 300;
            this.height = 200;
            this.open = open;
            CUIButton closeButton = new CUIButton("X", "Arial", 16, FontStyle.Regular, Color.White, Color.FromArgb(50, 50, 50), Color.FromArgb(80, 80, 80), x + width - 16, y+1, this);
            closeButton.onClick += (object sen, EventArgs args) =>
            {
                open = false;
                this.visible = false;
                Console.WriteLine("Closed");
                this.Dispose();
            };
            controls.Add(closeButton);
        }

        public override void OnPaint(Graphics graphics)
        {
            if (open)
            {
                base.OnPaint(graphics);
            }
        }
    }
}
