using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI.ClickUI
{
    public class VCategoryWindow : VWindowBase
    {
        List<VModuleObject> slots = new List<VModuleObject>();
        public override int height
        {
            get
            {
                int height = 0;
                foreach (VModuleObject vsObj in slots)
                {
                    height += vsObj.height;
                }
                return height;
            }
        }

        public VCategoryWindow() : base()
        {

        }

        public void addModule(Module module)
        {
            VModuleObject vmo = new VModuleObject(module, this, slots.Count);
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (VModuleObject vObj in slots)
            {
                vObj.OnPaint(e);
            }
        }
    }
}
