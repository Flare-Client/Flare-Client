using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ModuleList : VisualModule
    {
        public ModuleList() : base("ModuleList", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
        }
        public override void onEnable()
        {
            base.onEnable();
        }
        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            //Draw enabled modules
            uint yOff = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        float mwid = graphics.MeasureString(mod.name, textFont, 600).Width;
                        graphics.FillRectangle(OverlayHost.ui.secondary, OverlayHost.ui.width - mwid, (32 * scale) * yOff, mwid, fontSize);
                        graphics.DrawString(mod.name, textFont, primary, OverlayHost.ui.width - mwid, (32 * scale) * yOff);
                        yOff++;
                    }
                }
            }
        }
    }
}
