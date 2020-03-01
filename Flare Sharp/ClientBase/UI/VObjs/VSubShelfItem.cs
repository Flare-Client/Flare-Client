using Flare_Sharp.ClientBase.Keybinds;
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
        public VSubShelfItem(int shelfHeight, bool expandable, VShelfItem parent) : base(shelfHeight, expandable)
        {
            get
            {
                return parent.expanded;
            }
        }
        public VSubShelfItem(int shelfHeight, bool expandable, VShelfItem parent) : base(shelfHeight, expandable)
        {
            this.parent = parent;
            this.width -= 10;
            this.parent = parent;
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (!parent.expanded)
            {
                return;
            }
        }public override void OnInteractHeld(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (!parent.expanded)
            {
                return;
            }
        }public override void OnInteractUp(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (!parent.expanded)
            {
                return;
            }
        }

        public override void OnPaint(DrawingContext e)
        {
            e.DrawRectangle(quaternary, null, new Rect(objRect.X - 5, objRect.Y, objRect.Width + 10, objRect.Height));
            e.DrawRectangle(primary, null, objRect);
            base.OnPaint(e);
        }
    }
}
