using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.UI.ClickUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public class CombatKeybindsWindow : CUIWindow
    {
        public CombatKeybindsWindow() : base()
        {
            controls.Add(new CUILabel("Combat Keybinds", "Arial", 32, FontStyle.Underline, Color.FromArgb(255, 255, 255), 10, 10, this));
            byte Z = 0;
            foreach(Module mod in CategoryHandler.registry.categories[0].modules)
            {
                controls.Add(new CUILabel(mod.name, "Arial", 16, FontStyle.Regular, Color.White, 15, (Z * 20) + 50, this));
                controls.Add(new KeybindButton(mod, mod.keybind.ToString(), "Arial", 16, FontStyle.Regular, Color.White, Color.FromArgb(50, 50, 50), Color.FromArgb(80, 80, 80), this.width - 32, (Z * 20) + 50, this));
                Z++;
            }
            visible = true;
            this.height = 64 + (Z * 20);
        }
    }
}
