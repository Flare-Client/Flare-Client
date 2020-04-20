using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.UI.VObjs
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
