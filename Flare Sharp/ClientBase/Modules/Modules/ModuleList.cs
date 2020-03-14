using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using System.Drawing;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ModuleList : VisualModule
    {
        public static ModuleList instance;
        public ModuleList() : base("ModuleList", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
            instance = this;
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
                        graphics.FillRectangle(quinary, OverlayHost.ui.width - mwid - 5, (32 * scale) * yOff, 5, fontSize);
                        graphics.FillRectangle(OverlayHost.ui.secondary, OverlayHost.ui.width - mwid, (32 * scale) * yOff, mwid, fontSize);
                        graphics.DrawString(mod.name, textFont, primary, OverlayHost.ui.width - mwid, (32 * scale) * yOff);
                        yOff++;
                    }
                }
            }
        }
    }
}
