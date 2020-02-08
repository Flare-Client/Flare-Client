using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Settings
{
    public class SliderSetting : Setting
    {
        public int min = 0;
        public int value = 0;
        public int max = 0;
        public SliderSetting(string text, int min, int value, int max) : base(text)
        {
            this.min = min;
            this.value = value;
            this.max = max;
        }
    }
}
