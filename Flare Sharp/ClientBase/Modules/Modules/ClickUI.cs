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
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], (char)0xA1, false)
        {
        }
        public override void onEnable()
        {
            base.onEnable();
            TabUI.ui.Paint += drawUI;
        }
        public void drawUI(object sender, PaintEventArgs args)
        {
            if (enabled)
            {
                ClickUiHandler.instance.renderCUI(args.Graphics);
            }
        }
    }
}
