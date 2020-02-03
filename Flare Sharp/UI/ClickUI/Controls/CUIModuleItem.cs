using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI.Controls
{
    public class CUIModuleItem : CUIControl
    {
        Module mod;
        public CUIModuleItem(Module mod, Color color, int x, int y, CUIWindow parent) : base(color, x, y, parent)
        {
            this.mod = mod;
        }

        public override void OnPaint(Graphics graphics)
        {
            base.OnPaint(graphics);

        }
    }
}
