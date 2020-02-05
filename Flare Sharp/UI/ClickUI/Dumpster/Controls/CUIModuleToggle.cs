using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI.Controls
{
    public class CUIModuleToggle : CUICheckBox
    {
        Module mod;
        public CUIModuleToggle(Module mod, int size, Color uncheckedColor, Color checkedColor, Color color, int x, int y, CUIWindow parent) : base(size,uncheckedColor,checkedColor,color,x,y,parent)
        {
            this.mod = mod;
        }

        public override void OnPaint(Graphics graphics)
        {
            toggle = mod.enabled;
            if (toggle)
            {
                currentBrush = checkedBrush;
            }
            else
            {
                currentBrush = uncheckedBrush;
            }
            base.OnPaint(graphics);
        }
    }
}
