using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ClickUI : Module
    {
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], (char)0xA1, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Graphics graphics = TabUI.ui.graphics;
            graphics.FillRectangle(TabUI.ui.primary, 0, 0, 100, 100);
        }
    }
}
