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
    public class VModuleObject : VObject
    {
        public VWindowBase parent;
        public Rectangle parentRect
        {
            get
            {
                return parent.frame;
            }
        }
        public Rectangle thisRect {
            get
            {
                return new Rectangle(parentRect.X, parentRect.Y+(index*height), parentRect.Width, height);
            }
        }
        public int height=24;
        public int index;
        public bool expanded = false;
        public Module module;
        public VModuleObject(Module module, VWindowBase parent, int index) : base()
        {
            this.index = index;
            this.parent = parent;
            this.module = module;
            this.text = module.name;
        }
        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(secondary, thisRect);
            if (module.enabled)
            {
                e.Graphics.FillRectangle(tertiary, thisRect);
            }
            e.Graphics.DrawString(module.name, font, primary, thisRect);
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (e.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (thisRect.Contains(p))
                {
                    module.enabled = !module.enabled;
                }
            }
        }
    }
}
