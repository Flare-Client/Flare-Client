using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Categories
{
    public class Category
    {
        public string name;
        public bool active;
        public bool selected;
        public List<Module> modules = new List<Module>();
        public Category(string name, bool active, bool selected)
        {
            this.name = name;
            this.active = active;
            this.selected = selected;
            KeybindHandler.clientKeyDownEvent += OnKey;
        }

        private void OnKey(object sender, clientKeyEvent e)
        {
            if (active)
            {
                if (e.key == 0x28)
                {
                    selectNextModule();
                }
                if (e.key == 0x26)
                {
                    selectPrevModule();
                }
                if (e.key == 0x27)
                {
                    toggleSelectedModule();
                }
            }
        }

        private void selectNextModule()
        {
            int selected = 0;
            foreach (Module module in modules)
            {
                if (module.selected)
                {
                    break;
                }
                selected++;
            }
            modules[selected].selected = false;
            if (selected + 1 >= modules.Count)
            {
                modules[0].selected = true;
            }
            else
            {
                modules[selected + 1].selected = true;
            }
        }
        private void selectPrevModule()
        {
            int selected = 0;
            foreach (Module module in modules)
            {
                if (module.selected)
                {
                    break;
                }
                selected++;
            }
            modules[selected].selected = false;
            if (selected - 1 < 0)
            {
                modules[modules.Count-1].selected = true;
            }
            else
            {
                modules[selected - 1].selected = true;
            }
        }
        private void toggleSelectedModule()
        {
            foreach (Module module in modules)
            {
                if (module.selected)
                {
                    module.enabled = !module.enabled;
                }
            }
        }
    }
}
