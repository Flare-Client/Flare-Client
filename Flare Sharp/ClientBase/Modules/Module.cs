using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules
{
    public abstract class Module
    {
        public ICategory category;
        public string name;
        public bool enabled;
        public char keybind;
        public Module(string name, ICategory category, char keybind, bool enabled)
        {
            this.name = name;
            this.category = category;
            this.keybind = keybind;
            this.enabled = enabled;
        }

        public virtual void onEnable()
        {
            this.enabled = true;
        }
        public virtual void onDisable()
        {
            this.enabled = false;
        }
        public virtual void onTick()
        {

        }
    }
}
