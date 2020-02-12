using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Modules.Settings;
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
        public int keybind;

        private bool wasEnabled = false;
        public EventHandler toggleEvent;

        public Module(string name, Category category, int keybind, bool enabled)
        {
            this.name = name;
            this.keybind = keybind;
            this.enabled = enabled;
            category.modules.Add(this);
        }

        public List<SliderSetting> sliderSettings = new List<SliderSetting>();
        public void RegisterSliderSetting(string text, int min, int value, int max)
        {
            sliderSettings.Add(new SliderSetting(text, min, value, max));
        }

        public virtual void onEnable()
        {
            this.enabled = true;
            FileMan.man.saveConfig();
        }
        public virtual void onDisable()
        {
            this.enabled = false;
            FileMan.man.saveConfig();
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
                    try
                    {
                        toggleEvent.Invoke(this, new EventArgs());
                    }
                    catch (Exception) { }
                }
                else
                {
                    onEnable();
                    try
                    {
                        toggleEvent.Invoke(this, new EventArgs());
                    }
                    catch (Exception) { }
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
