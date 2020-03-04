using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flare_Sharp.ClientBase.UI
{
    public class DrawUtils
    {
        public static void drawLine(int x, int y, int x2, int y2, Color color, WriteableBitmap map)
        {
            map.DrawLine(x, y, x2, y2, color);
        }
        public static void drawRect(int x, int y, int x2, int y2, Color color, WriteableBitmap map)
        {
            map.DrawRectangle(x, y, x2, y2, color);
        }
        public static void fillRect(int x, int y, int x2, int y2, Color color, WriteableBitmap map)
        {
            map.FillRectangle(x, y, x2, y2, color);
        }
        public static void drawText(string text, double x, double y, double size, Color color)
        {
            Label label = new Label();
            label.Content = text;
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
            label.Foreground = new SolidColorBrush(color);
            label.Background = new SolidColorBrush(Colors.Transparent);
            label.FontSize = size;
            OverlayHost.ui.textHolder.Children.Add(label);
        }
    }
}
