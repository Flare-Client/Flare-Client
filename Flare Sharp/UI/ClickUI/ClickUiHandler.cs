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
            for(int z = 0; z < CategoryHandler.registry.categories.Count; z++)
            {
                if (z-1 >= 0)
                {
                    new KeybindWindow(CategoryHandler.registry.categories[z]).x += windows[z-1].x+ windows[z - 1].width;
                }
                else
                {
                    new KeybindWindow(CategoryHandler.registry.categories[z]);
                }
                
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
