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
            KeybindHandler.clientKeyDownEvent += processKey;
        }

        private void processKey(object sender, clientKeyEvent e)
        {
            throw new NotImplementedException();
        }

        public override void onEnable()
        {
            base.onEnable();
        }

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
            context.DrawRectangle(primary, null, new Rect(0, 0, 200, 82 + (CategoryHandler.registry.categories.Count * 40)));
            context.DrawRectangle(new ImageBrush(bitmapSource), null, new Rect(-10, 3, 90, 90));
            FormattedText title = DrawUtils.stringToFormatted("Flare", "Arial", 48, secondary);
            context.DrawText(title, new Point(70, 30));
            int c = 82;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                if (cat.selected)
                    context.DrawRectangle(tertiary, null, new Rect(0, c, 200, 40));
                FormattedText catText = DrawUtils.stringToFormatted(cat.name, "Arial", 32, secondary);
                context.DrawText(catText, new Point(5, c+2));
                c += 40;
            }
        }
    }
}
