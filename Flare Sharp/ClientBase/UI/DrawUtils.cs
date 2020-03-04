using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flare_Sharp.ClientBase.UI
{
    public class DrawUtils
    {
        public static void drawLine(int x, int y, int x2, int y2, Color color)
        {
            OverlayHost.writeableBitmap.GetBitmapContext();
            OverlayHost.writeableBitmap.DrawLine(x, y, x2, y2, color);
        }
    }
}
