using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Settings
{
    public class SliderFloatSetting : Setting
    {
        public float min = 0;
        public float value = 0;
        public float max = 0;
        public SliderFloatSetting(string text, float min, float value, float max) : base(text)
        {
            this.min = min;
            this.value = value;
            this.max = max;
        }
    }
}
