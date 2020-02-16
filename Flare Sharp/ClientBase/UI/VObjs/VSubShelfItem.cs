using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VSubShelfItem : VShelfItem
    {
        public VShelfItem parent;
        public VSubShelfItem(int shelfHeight, bool expandable) : base(shelfHeight, expandable)
        {
            this.width -= 10;
        }

        public override void OnPaint(DrawingContext e)
        {
            e.DrawRectangle(quaternary, null, new Rect(objRect.X - 5, objRect.Y, objRect.Width + 10, objRect.Height));
            e.DrawRectangle(secondary, null, objRect);
            base.OnPaint(e);
        }
    }
}
