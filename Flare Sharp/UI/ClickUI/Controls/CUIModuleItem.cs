using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI.Controls
{
    public class CUIModuleItem : CUIControl
    {
        Module mod;
        CUIModuleToggle modToggle;
        public CUIModuleItem(Module mod, Color color, int x, int y, CUIWindow parent) : base(color, x, y, parent)
        {
            this.mod = mod;
            CUILabel modNameLbl = new CUILabel(mod.name, "Arial", 16, FontStyle.Regular, Color.White, 15, y, parent);
            parent.controls.Add(modNameLbl);
            KeybindButton modKeyB = new KeybindButton(mod, mod.keybind.ToString(), "Arial", 16, FontStyle.Regular, Color.White, Color.FromArgb(50, 50, 50), Color.FromArgb(80, 80, 80), parent.width - 32, y, parent);
            parent.controls.Add(modKeyB);
            modToggle = new CUIModuleToggle(mod, 16, Color.FromArgb(255, 0, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 0, 0), parent.width - 32 - 18, y, parent);
            modToggle.onClick += toggleModule;
            modToggle.toggle = mod.enabled;
            parent.controls.Add(modToggle);
            byte[] str = { 0xE2, 0x9A, 0x99 };
            CUIButton modSettingButton = new CUIButton(Encoding.UTF8.GetString(str), "Arial", 16, FontStyle.Regular, Color.White, Color.FromArgb(50, 50, 50), Color.FromArgb(80, 80, 80), parent.width - 32 - 18 -20, y, parent);
            parent.controls.Add(modSettingButton);
        }

        private void toggleModule(object sender, EventArgs e)
        {
            mod.enabled = !mod.enabled;
            mod.enabled = modToggle.toggle;
            OverlayHost.ui.Invalidate();
        }



        public override void OnPaint(Graphics graphics)
        {
            base.OnPaint(graphics);
        }
    }
}
