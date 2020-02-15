using Overlay.NET.Common;
using Overlay.NET.Directx;
using Process.NET.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.UI
{
    public class OverlayHostPlugin : DirectXOverlayPlugin
    {
        private readonly TickEngine _tickEngine = new TickEngine();
        public readonly ISettings<OverlaySettings> Settings = new SerializableSettings<OverlaySettings>();
        private int _displayFps;
        private int Font;
        private int titleFont;
        private int _i;
        private Stopwatch _watch;

        public int primary;
        public int secondary;

        int x
        {
            get
            {
                return 8;
            }
        }

        public override void Initialize(IWindow targetWindow, int processID)
        {
            // Set target window by calling the base method
            base.Initialize(targetWindow, processID);

            // For demo, show how to use settings
            var current = Settings.Current;
            var type = GetType();

            if (current.UpdateRate == 0)
                current.UpdateRate = 1000 / 60;

            current.Author = GetAuthor(type);
            current.Description = GetDescription(type);
            current.Identifier = GetIdentifier(type);
            current.Name = GetName(type);
            current.Version = GetVersion(type);

            // File is made from above info
            Settings.Save();
            Settings.Load();
            Console.Title = @"OverlayExample";

            OverlayWindow = new DirectXOverlayWindow(targetWindow.Handle, processID, false);
            _watch = Stopwatch.StartNew();

            primary = OverlayWindow.Graphics.CreateBrush(0x7FFFFFFF);
            secondary = OverlayWindow.Graphics.CreateBrush(0x01161616);

            Font = OverlayWindow.Graphics.CreateFont("Arial", 20);
            titleFont = OverlayWindow.Graphics.CreateFont("Arial", 50, true);

            _displayFps = 0;
            _i = 0;
            // Set up update interval and register events for the tick engine.

            _tickEngine.PreTick += OnPreTick;
            _tickEngine.Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (!OverlayWindow.IsVisible)
            {
                return;
            }

            OverlayWindow.Update();
            InternalRender();
        }

        private void OnPreTick(object sender, EventArgs e)
        {
            var targetWindowIsActivated = TargetWindow.IsActivated;
            if (!targetWindowIsActivated && OverlayWindow.IsVisible)
            {
                _watch.Stop();
                ClearScreen();
                OverlayWindow.Hide();
            }
            else if (targetWindowIsActivated && !OverlayWindow.IsVisible)
            {
                OverlayWindow.Show();
            }
        }

        // ReSharper disable once RedundantOverriddenMember
        public override void Enable()
        {
            _tickEngine.Interval = Settings.Current.UpdateRate.Milliseconds();
            _tickEngine.IsTicking = true;
            base.Enable();
        }

        // ReSharper disable once RedundantOverriddenMember
        public override void Disable()
        {
            _tickEngine.IsTicking = false;
            base.Disable();
        }

        public override void Update() => _tickEngine.Pulse();

        protected void InternalRender()
        {
            if (!_watch.IsRunning)
            {
                _watch.Start();
            }

            OverlayWindow.Graphics.BeginScene();
            OverlayWindow.Graphics.ClearScene();

            OverlayWindow.Graphics.FillRectangle(8, 33, 208, 333, 1);
            OverlayWindow.Graphics.DrawText("Flare", titleFont, 0, 8, 33);

            if (_watch.ElapsedMilliseconds > 1000)
            {
                _i = _displayFps;
                _displayFps = 0;
                _watch.Restart();
            }

            else
            {
                _displayFps++;
            }

            OverlayWindow.Graphics.DrawText("FPS: " + _i, Font, primary, 400, 600, false);

            OverlayWindow.Graphics.EndScene();
        }

        public override void Dispose()
        {
            OverlayWindow.Dispose();
            base.Dispose();
        }

        private void ClearScreen()
        {
            OverlayWindow.Graphics.BeginScene();
            OverlayWindow.Graphics.ClearScene();
            OverlayWindow.Graphics.EndScene();
        }
    }
}
