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
            new TestWindow();
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
