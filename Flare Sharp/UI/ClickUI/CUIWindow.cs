using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public abstract class CUIWindow
    {
        public List<CUIControl> controls = new List<CUIControl>();
        public CUIWindow()
        {

        }

        public virtual void OnPaint()
        {

        }
    }
}
