using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI.VObjs
{
    public class VModuleItem : VShelfItem
    {
        public Module module;
        public VModuleItem(Module module):base(24)
        {
            this.module = module;
            this.text = module.name;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(secondary, objRect);
            if (module.enabled)
            {
                e.Graphics.FillRectangle(tertiary, objRect);
            }
            base.OnPaint(e);
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if(a.key==0x1)
                module.enabled = !module.enabled;
        }
    }
}
