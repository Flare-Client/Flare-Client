using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.VObjs;
using System;
using System.Collections.Generic;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class ClickUI : Module
    {
        List<VWindowBase> windows = new List<VWindowBase>();
        public ClickUI() : base("ClickGUI", CategoryHandler.registry.categories[3], 0x2D, false)
        {
            int x = 0;
            foreach (Category category in CategoryHandler.registry.categories)
            {
                VCatgoryWindow categoryWindow = new VCatgoryWindow(category, x);
                x += categoryWindow.width;
                windows.Add(categoryWindow);
            }
            /*VTargetsWindow targets = new VTargetsWindow(x);
            x += targets.width;
            windows.Add(targets);*/

            VTeleportWindow teleport = new VTeleportWindow(x);
            x += teleport.width;
            windows.Add(teleport);
        }
        public override void onEnable()
        {
            base.onEnable();
        }
        public override void onDisable()
        {
            base.onDisable();
        }
    }
}
