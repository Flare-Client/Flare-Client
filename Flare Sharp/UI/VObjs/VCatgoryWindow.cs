using Flare_Sharp.ClientBase.Categories;
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
    public class VCatgoryWindow : VWindowBase
    {
        List<VModuleItem> moduleObjects = new List<VModuleItem>();
        public Category category;
        public VCatgoryWindow(Category category, int x) : base(x)
        {
            this.category = category;
            this.text = category.name;

            foreach(Module module in category.modules)
            {
                moduleObjects.Add(new VModuleItem(module, this));
            }

            //We have to register this manually
            OverlayHost.ui.Paint += (object sender, PaintEventArgs e) =>
            {
                if (visible)
                {
                    OnPaint(e);
                }
            };
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int paintOffset = 0;
            foreach (VObject vObject in moduleObjects)
            {
                vObject.visible = visible;
                vObject.x = x;
                vObject.y = y + height + paintOffset;
                vObject.OnPaint(e);
                paintOffset += vObject.height;
            }
        }
    }
}
