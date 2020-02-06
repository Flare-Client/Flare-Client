using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using Flare_Sharp.UI.VObjs;
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
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], (char)0xA1, false)
        {
        }
        public override void onEnable()
        {
            base.onEnable();
            new VCatgoryWindow(CategoryHandler.registry.categories[0]).visible=true;
        }
        public override void onDisable()
        {
            base.onDisable();
        }
    }
}
