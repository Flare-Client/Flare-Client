using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flare_Sharp.ClientBase.UI
{
    public class DrawUtils
    {
        public static FormattedText stringToFormatted(string text, string font, double fontSize, Brush brush)
        {
            return new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(font), fontSize, brush);
        }
        public static void drawLine(int x, int y, int x2, int y2, double thickness, Brush brush)
        {
            Line line = new Line();
            line.Stroke = brush;
            line.StrokeThickness = thickness;
            line.X1 = x;
            line.X2 = x2;
            line.Y1 = y;
            line.Y2 = y2;
            OverlayHost.ui.addChildObj(line);
        }
        public static void drawRectangle(int x, int y, int width, int height, double thickness, Brush brush)
        {
            drawLine(x, y, x + width, y, thickness, brush);
            drawLine(x + width, y, x + width, y + height, thickness, brush);
            drawLine(x + width, y + height, x, y + height, thickness, brush);
            drawLine(x, y + height, x, y, thickness, brush);
        }
    }
}
