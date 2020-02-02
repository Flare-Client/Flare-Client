using Flare_Sharp.ClientBase.Categories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public class ClickUiHandler
    {
        public List<CUIWindow> windows = new List<CUIWindow>();
        public static ClickUiHandler instance;
        public ClickUiHandler()
        {
            instance = this;
            int z = 0;
            foreach(Category cat in CategoryHandler.registry.categories)
            {
                new KeybindWindow(cat).x += (z*500);
                z++;
            }
        }

        public void renderCUI(Graphics graphics)
        {
            foreach(CUIWindow window in windows)
            {
                window.OnPaint(graphics);
            }
        }
    }
}
