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
            OverlayHost.writeableBitmap.DrawLine(x, y, x2, y2, color);
        }
        public static void drawRect(int x, int y, int x2, int y2, Color color)
        {
            OverlayHost.writeableBitmap.DrawRectangle(x, y, x2, y2, color);
        }public static void fillRect(int x, int y, int x2, int y2, Color color)
        {
            OverlayHost.writeableBitmap.FillRectangle(x, y, x2, y2, color);
        }
    }
}
