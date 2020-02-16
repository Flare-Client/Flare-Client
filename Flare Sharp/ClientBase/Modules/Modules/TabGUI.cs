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
        public TabGUI() : base("TabGUI", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        double tuiWidth = 0;
        bool initializing = true;
        BitmapSource bitmapSource;
        /*onRender is Deprecated, use onDraw*/
        public override void onRender()
        {
            base.onRender();
        }
        public override void onDraw(DrawingContext context)
        {
            base.onDraw(context);
            if (initializing)
            {
                bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(Resources.FlareLogo.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                initializing = false;
            }
            context.DrawRectangle(primary, null, new Rect(0, 0, tuiWidth, 50 + (CategoryHandler.registry.categories.Count * 40)));
            context.DrawRectangle(new ImageBrush(bitmapSource), null, new Rect(0, 3, 50, 50));
            int c = 50;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                if(cat.active)
                    context.DrawRectangle(quaternary, null, new Rect(0, c, tuiWidth, 40));
                else if (cat.selected)
                    context.DrawRectangle(tertiary, null, new Rect(0, c, tuiWidth, 40));
                FormattedText catText = DrawUtils.stringToFormatted(cat.name, "Roboto", 32, secondary);
                if(catText.Width > tuiWidth)
                {
                    tuiWidth = catText.Width+7;
                }
                context.DrawText(catText, new Point(5, c+2));
                c += 40;
            }
        }
    }
}
