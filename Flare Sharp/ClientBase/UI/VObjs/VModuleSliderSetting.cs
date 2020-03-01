using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VModuleSliderSetting : VSliderItem
    {
        SliderSetting setting;
        public override int value { 
            get
            {
                return setting.value;
            }
            set
            {
                if(setting!=null)
                    setting.value = value;
            }
        }
        public VModuleSliderSetting(SliderSetting setting, VShelfItem parent) : base(setting.text, setting.min, setting.value, setting.max, parent)
        {
            this.setting = setting;
        }
    }
}
