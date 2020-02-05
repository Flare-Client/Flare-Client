using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.UI.ClickUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIWindow : IDisposable
    {
        [DllImport("user32")]
        static extern bool GetCursorPos(out Point point);

        public List<CUIControl> controls = new List<CUIControl>();
        public int x;
        public int y;
        public int r2dX
        {
            get
            {
                MCM.RECT mcr = MCM.getMinecraftRect();
                return x + mcr.Left + 16;
            }
        }
        public int r2dY
        {
            get
            {
                MCM.RECT mcr = MCM.getMinecraftRect();
                return y + mcr.Top + 34;
            }
        }
        public int width = 400;
        public int height = 300;
        int dx;
        int dy;
        public bool visible;
        bool dragging;

        public CUIWindow()
        {
            KeybindHandler.clientKeyDownEvent += startDrag;
            KeybindHandler.clientKeyHeldEvent += doDrag;
            KeybindHandler.clientKeyUpEvent += stopDrag;
            ClickUiHandler.instance.windows.Add(this);
        }

        private void startDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (e.key == 0x1)
                {
                    Point p;
                    GetCursorPos(out p);
                    if (p.X > r2dX && p.Y > r2dY && p.X < width + r2dX && p.Y < height + r2dY)
                    {
                        dx = p.X - x;
                        dy = p.Y - y;
                        dragging = true;
                    }
                }
            }
        }
        private void doDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (dragging)
                {
                    if (e.key == 0x1)
                    {
                        Point p;
                        GetCursorPos(out p);
                        x = p.X - dx;
                        y = p.Y - dy;
                        OverlayHost.ui.Invalidate();
                    }
                }
            }
        }
        private void stopDrag(object sender, clientKeyEvent e)
        {
            if (visible)
            {
                if (e.key == 0x1)
                {
                    dragging = false;
                    OverlayHost.ui.Invalidate();
                }
            }
        }

        public virtual void OnPaint(Graphics graphics)
        {
            if (visible)
            {
                graphics.FillRectangle(OverlayHost.ui.secondary, x, y, width, height);
                graphics.DrawRectangle(new Pen(OverlayHost.ui.primary), x, y, width, height);
                foreach (CUIControl control in controls)
                {
                    control.OnPaint(graphics);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CUIWindow()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
