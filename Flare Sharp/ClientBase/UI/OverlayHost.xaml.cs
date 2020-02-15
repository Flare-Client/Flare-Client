using Flare_Sharp.Memory;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Flare_Sharp.ClientBase.UI
{
    /// <summary>
    /// Interaction logic for OverlayHost.xaml
    /// </summary>
    public partial class OverlayHost : Window
    {
        Win32.WinEventDelegate overDel;
        int x
        {
            get
            {
                return MCM.getMinecraftRect().Left+8;
            }
        }
        int y
        {
            get
            {
                Win32.WINDOWPLACEMENT place = new Win32.WINDOWPLACEMENT();
                Win32.GetWindowPlacement(MCM.mcWinHandle, ref place);
                return MCM.getMinecraftRect().Top + 33 + (Convert.ToInt32(place.showCmd == Win32.SW_SHOWMAXIMIZED) * 7);
            }
        }
        int width
        {
            get
            {
                return MCM.getMinecraftRect().Right-x-8;
            }
        }
        int height
        {
            get
            {
                return MCM.getMinecraftRect().Bottom-y - 8;
            }
        }

        SolidColorBrush primary = new SolidColorBrush(Colors.Black) { Opacity = 0.5 };
        SolidColorBrush secondary = new SolidColorBrush(Colors.White);

        public OverlayHost()
        {
            InitializeComponent();
            RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.Default;
            Loaded += windowLoaded;
            //CompositionTarget.Rendering += CompositionTarget_Rendering;
            overDel = new Win32.WinEventDelegate(LocationChangeCallback);
            Win32.SetWinEventHook((uint)Win32.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)Win32.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, MCM.mcWinProcId, Win32.GetWindowThreadProcessId(MCM.mcWinHandle, IntPtr.Zero), (uint)Win32.SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)Win32.SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)Win32.SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
        }

        public void LocationChangeCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {

            Left = x;
            Top = y;
            Width = width;
            Height = height;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(primary, new Pen(primary, 1), new Rect(0, 0, 200, 82));
            FormattedText title = new FormattedText("Flare", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 72, secondary);
            drawingContext.DrawText(title, new Point(5,0));
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
