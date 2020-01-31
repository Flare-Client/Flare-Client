using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using Flare_Sharp.UI.ClickUI;
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
        delegate void DrawDel(Graphics graphics);
        DrawDel drawDel;
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], (char)0xA1, false)
        {
            drawDel = new DrawDel(drawUI);
        }

        public override void onTick()
        {
            base.onTick();
            Graphics graphics = TabUI.ui.CreateGraphics();
            //Make sure its rendering on the same thread!
            TabUI.ui.Invoke(drawDel, graphics);
        }

        public void drawUI(Graphics graphics)
        {
            ClickUiHandler.instance.renderCUI(graphics);
        }
    }
}
