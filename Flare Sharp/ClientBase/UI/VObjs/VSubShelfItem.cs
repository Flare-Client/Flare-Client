using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VSubShelfItem : VShelfItem
    {
        public VShelfItem parent;
        public bool opened
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
        }

        public override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(quaternary, objRect.X - 5, objRect.Y, objRect.Width + 10, objRect.Height);
            e.Graphics.FillRectangle(secondary, objRect);
            base.OnPaint(e);
        }
    }
}
