using Flare_Sharp.ClientBase.Keybinds;
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
    public class KeybindButton : CUIButton
    {
        public Module module;
        bool changing = false;
        public KeybindButton(Module module, string text, string fontFamily, float fontSize, FontStyle fontStyle, Color foreground, Color background, Color backgroundClicked, int x, int y, CUIWindow parent) : base(text, fontFamily, fontSize, fontStyle, foreground, background, backgroundClicked, x, y, parent)
        {
            this.module = module;
            onClick += changeKeybind;
            KeybindHandler.clientKeyDownEvent += setNewKeybind;
        }

        private void setNewKeybind(object sender, clientKeyEvent e)
        {
            if (changing)
            {
                if (e.key != 0x1)
                {
                    if (e.key == 0x1B)
                    {
                        module.keybind = (char)0x07;
                    }
                    else
                    {
                        module.keybind = e.key;
                    }
                    this.text = e.key.ToString();
                    changing = false;
                }
            }
        }

        public void changeKeybind(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                this.text = "...";
            }
        }
    }
}
