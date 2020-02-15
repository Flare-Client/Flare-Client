using Flare_Sharp.ClientBase.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class CpuLimiter : Module
    {
        public CpuLimiter() : base("CPU Limiter", CategoryHandler.registry.categories[3], 0x07, true)
        {
            RegisterSliderSetting("Max CPU %", 20, 70, 100);
        }

        public override void onTick()
        {
            base.onTick();
            Program.cpuLimit = sliderSettings[0].value;
        }

        public override void onDisable()
        {
            base.onDisable();
            Program.cpuLimit = 100f;
        }
    }
}
