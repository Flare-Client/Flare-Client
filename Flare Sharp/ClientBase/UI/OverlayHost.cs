using Flare_Sharp.Memory;
using Overlay.NET.Common;
using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proc = System.Diagnostics.Process;

namespace Flare_Sharp.ClientBase.UI
{
    public class OverlayHost
    {
        private OverlayHostPlugin _directXoverlayPluginExample;
        private ProcessSharp _processSharp;

        public void StartDemo()
        {
            _directXoverlayPluginExample = new OverlayHostPlugin();
            Proc process = Proc.GetProcessById((int)MCM.mcWinProcId);
            _processSharp = new ProcessSharp(process, MemoryType.Remote);

            Console.WriteLine(process.ProcessName);

            var d3DOverlay = _directXoverlayPluginExample;
            d3DOverlay.Settings.Current.UpdateRate = 1000 / 60;
            _directXoverlayPluginExample.Initialize(_processSharp.WindowFactory.MainWindow, process.Id);
            _directXoverlayPluginExample.Enable();

            var info = d3DOverlay.Settings.Current;

            while (true)
            {
                _directXoverlayPluginExample.Update();
            }
        }
    }
}
