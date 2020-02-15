using Flare_Sharp.Memory;
using Overlay.NET.Common;
using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proc = System.Diagnostics.Process;

namespace Flare_Sharp.ClientBase.UI
{
    public class OverlayHost : Form
    {
        private OverlayHostPlugin _directXoverlayPluginExample;
        private ProcessSharp _processSharp;

        Win32.WinEventDelegate overDel;

        public OverlayHost()
        {
            StartDemo();
            overDel = new Win32.WinEventDelegate(invokeUpdate);
            IntPtr hook = Win32.SetWinEventHook((uint)Win32.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)Win32.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, (uint)MCM.mcWinProcId, Win32.GetWindowThreadProcessId(MCM.mcWinHandle, IntPtr.Zero), (uint)Win32.SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)Win32.SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)Win32.SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);

            while (true)
            {
                _directXoverlayPluginExample.Update();
                Thread.Sleep(1);
            }
        }

        public void StartDemo()
        {
            Console.WriteLine("Starting ui...");
            _directXoverlayPluginExample = new OverlayHostPlugin();
            Proc process = Proc.GetProcessById((int)MCM.mcWinProcId);
            _processSharp = new ProcessSharp(process, MemoryType.Remote);

            Console.WriteLine(process.ProcessName);

            var d3DOverlay = _directXoverlayPluginExample;
            d3DOverlay.Settings.Current.UpdateRate = 1000 / 60;
            _directXoverlayPluginExample.Initialize(_processSharp.WindowFactory.MainWindow, process.Id);
            _directXoverlayPluginExample.Enable();

            var info = d3DOverlay.Settings.Current;

            Console.WriteLine("Ui is ready to rock!");
        }

        public void invokeUpdate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            _directXoverlayPluginExample.Update();
        }
    }
}
