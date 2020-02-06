using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using Flare_Sharp.UI.ClickUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ClickUI : Module
    {
        List<VObject> vObjs = new List<VObject>();
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], (char)0xA1, false)
        {
            OverlayHost.postOverlayLoad += (object sen, EventArgs ea)=>{
                VCategoryWindow window = new VCategoryWindow();
                window.addModule(CategoryHandler.registry.categories[0].modules[0]);
                window.addModule(CategoryHandler.registry.categories[0].modules[1]);
                vObjs.Add(window);
            };
        }
        public override void onEnable()
        {
            base.onEnable();
            foreach(VObject vObj in vObjs)
            {
                vObj.visible = true;
            }
        }
        public override void onDisable()
        {
            base.onDisable();
            foreach (VObject vObj in vObjs)
            {
                vObj.visible = false;
            }
        }
    }
}
