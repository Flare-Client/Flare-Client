using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI;
using System.Windows;
using System.Windows.Media;

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
        public override void onDraw(DrawingContext context)
        {
            uint yOff = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        FormattedText modText = DrawUtils.stringToFormatted(mod.name, "Roboto", 32, secondary);
                        double mwid = modText.Width;
                        context.DrawRectangle(primary, null, new Rect(OverlayHost.ui.width - mwid, 32 * yOff, mwid, 32));
                        context.DrawText(modText, new Point(OverlayHost.ui.width - mwid, 32 * yOff));
                        yOff++;
                    }
                }
            }
        }
    }
}
