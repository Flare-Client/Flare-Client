using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIControl
    {
        public CUIControl()
        {
        }

        public virtual void OnPaint(Graphics graphics)
        {

        }
    }
}
