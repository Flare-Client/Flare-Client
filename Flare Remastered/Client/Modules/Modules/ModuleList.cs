using Flare_Remastered.Client.Categories;
using System.Drawing;

namespace Flare_Remastered.Client.Modules.Modules
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
                        int ohwid = OverlayHost.width;
                        graphics.FillRectangle(quinary, ohwid - mwid - 5, (32 * scale) * yOff, 5, fontSize);
                        graphics.FillRectangle(secondary, ohwid - mwid, (32 * scale) * yOff, mwid, fontSize);
                        graphics.DrawString(mod.name, textFont, primary, ohwid - mwid, (32 * scale) * yOff);
                        yOff++;
                    }
                }
            }
        }
    }
}
