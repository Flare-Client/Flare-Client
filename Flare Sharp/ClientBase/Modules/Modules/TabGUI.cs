using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.UI;
using Flare_Sharp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TabGUI : VisualModule
    {
        public double catWidth = 0;
        public double modWidth = 0;

        public TabGUI() : base("TabGUI", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        bool initializing = true;
        BitmapSource bitmapSource;

        int i = 0;
        public override void onRender()
        {
            base.onRender();
            DrawUtils.fillRect(0, 0, 100, 100, primary);
        }
        /*
        public override void onDraw()
        {
            base.onDraw();
            
            if (initializing)
            {
                bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(Resources.FlareLogo.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                initializing = false;
            }
            context.DrawRectangle(primary, null, new Rect(0, 0, catWidth, 50 + (CategoryHandler.registry.categories.Count * 40)));
            context.DrawRectangle(new ImageBrush(bitmapSource), null, new Rect(0, 3, 50, 50));
            int c = 50;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                if(cat.active)
                    context.DrawRectangle(quaternary, null, new Rect(0, c, catWidth, 40));
                else if (cat.selected)
                    context.DrawRectangle(tertiary, null, new Rect(0, c, catWidth, 40));
                FormattedText catText = DrawUtils.stringToFormatted(cat.name, "Roboto", 32, secondary);
                if(catText.Width > catWidth)
                {
                    catWidth = catText.Width+7;
                }
                context.DrawText(catText, new Point(5, c+2));
                c += 40;
                if (cat.active)
                {
                    double modWidth = 0;
                    //Draw modules
                    foreach (Module module in cat.modules)
                    {
                        FormattedText modText = DrawUtils.stringToFormatted(module.name, "Roboto", 32, secondary);
                        if (modText.Width > modWidth)
                        {
                            modWidth = modText.Width;
                        }
                    }
                    context.DrawRectangle(primary, null, new Rect(catWidth, 32, modWidth, 32 * cat.modules.Count));
                    //context.DrawRectangle(primary, null, new Rect(0, 32 + 32 * c, catWidth, 32));
                    uint m = 0;
                    foreach (Module mod in cat.modules)
                    {
                        //graphics.DrawRectangle(new Pen(OverlayHost.ui.rainbow), catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        FormattedText modText = DrawUtils.stringToFormatted(mod.name, "Roboto", 32, secondary);
                        FormattedText modBind = DrawUtils.stringToFormatted(mod.keybind.ToString(), "Roboto", 32, secondary);
                        if (mod.enabled)
                        {
                            context.DrawRectangle(quaternary, null, new Rect(catWidth, 32 + 32 * m, modWidth, 32));
                        }
                        if (mod.selected)
                        {
                            context.DrawRectangle(tertiary, null, new Rect(catWidth, 32 + 32 * m, modWidth, 32));
                        }
                        context.DrawText(modText, new Point(catWidth, 32 + 32 * m));
                        double kwid = modBind.Width;
                        //context.DrawRectangle(primary, null, new Rect(catWidth + modWidth, 32 + 32 * m, kwid, 32));
                        context.DrawText(modBind, new Point(catWidth + modWidth, 32 + 32 * m));
                        m++;
                    }
                    //context.DrawRectangle(primary, null, new Rect(catWidth, 32, modWidth, 32 * cat.modules.Count));
                }
            }
            //graphics.DrawRectangle(new Pen(quinary, 1), 0, 0, catWidth * scale, ((32 * scale) * CategoryHandler.registry.categories.Count) + tFontSize);
        }
        */
    }
}
