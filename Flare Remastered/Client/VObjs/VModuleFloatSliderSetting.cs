using Flare_Remastered.Client.Modules;
using Flare_Remastered.Client.Modules.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.Client.VObjs
{
    public class VModuleFloatSliderSetting : VFloatSliderItem
    {
        SliderFloatSetting setting;
        public override float value
        {
            get
            {
                return setting.value;
            }
            set
            {
                if (setting != null)
                    setting.value = value;
            }
        }
        public VModuleFloatSliderSetting(SliderFloatSetting setting, VShelfItem parent) : base(setting.text, setting.min, setting.value, setting.max, parent)
        {
            this.setting = setting;
        }
    }
}
