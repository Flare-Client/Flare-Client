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
        public string name;
        public bool enabled;
        public bool selected;
        public char keybind;

        private bool wasEnabled = false;

        public Module(string name, Category category, char keybind, bool enabled)
        {
            this.name = name;
            this.keybind = keybind;
            this.enabled = enabled;
            category.modules.Add(this);
        }

        public virtual void onEnable()
        {
            this.enabled = true;
        }
        public virtual void onDisable()
        {
            this.enabled = false;
        }
        //Called like a loop when enabled
        public virtual void onTick()
        {
            
        }
        //Called no matter what
        public virtual void onLoop()
        {
            if (wasEnabled != enabled)
            {
                if (enabled == false)
                {
                    onDisable();
                }
                else
                {
                    onEnable();
                }
                wasEnabled = enabled;
            }
            if (enabled)
            {
                onTick();
            }
        }
    }
}
