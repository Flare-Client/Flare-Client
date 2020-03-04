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
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawLine(new Pen(brush, thickness), new Point(x, y), new Point(x2, y2));
            drawingContext.Close();
            OverlayHost.ui.addChildObj(drawingVisual);
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
