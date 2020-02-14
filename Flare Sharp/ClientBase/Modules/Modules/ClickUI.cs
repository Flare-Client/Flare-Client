using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.UI;
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
        List<VWindowBase> windows = new List<VWindowBase>();
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], 0x2D, false)
        {
            OverlayHost.postOverlayLoad += (object sender, EventArgs args) =>
              {
                  int x = 0;
                  foreach (Category category in CategoryHandler.registry.categories)
                  {
                      VCatgoryWindow categoryWindow = new VCatgoryWindow(category, x);
                      x += categoryWindow.width;
                      windows.Add(categoryWindow);
                  }
                  VTargetsWindow targets = new VTargetsWindow(x);
                  x += targets.width;
                  windows.Add(targets);
              };
        }
        public override void onEnable()
        {
            base.onEnable();
            foreach(VWindowBase window in windows)
            {
                window.visible = true;
            }
        }
        public override void onDisable()
        {
            base.onDisable();
            foreach (VWindowBase window in windows)
            {
                window.visible = false;
            }
        }
    }
}
