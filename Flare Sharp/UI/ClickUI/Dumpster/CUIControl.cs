using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIControl : IDisposable
    {
        public int x;
        public int y;
        public Brush brush;
        public Pen pen;
        public CUIWindow parent;
        public CUIControl(Color color, int x, int y, CUIWindow parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;
            this.brush = new SolidBrush(color);
            this.pen = new Pen(color);
        }

        public virtual void OnPaint(Graphics graphics)
        {

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
        // ~CUIControl()
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
