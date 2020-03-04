using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VAddButton : VObject
    {
        public event EventHandler clicked;
        public VAddButton() : base()
        {
            this.text = "+";
        }

        public override void OnPaint(DrawingContext e)
        {
            /*
            base.OnPaint(e);
            e.DrawRectangle(primary, null, objRect);
            FormattedText texts = DrawUtils.stringToFormatted(text, "Roboto", 16, secondary);
            e.DrawText(texts, new Point(x + (width / 2) - (16 / 2), y));
            */
        }

        public override void OnInteractUp(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (a.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.x, Cursor.Position.Y - OverlayHost.ui.y);
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
