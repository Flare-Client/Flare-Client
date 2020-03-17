using Flare_Sharp.ClientBase.Categories;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class CpuLimiter : Module
    {
        public CpuLimiter() : base("Cpu Limiter", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            Program.limitCpu = true;
        }
        public override void onDisable()
        {
            base.onDisable();
            Program.limitCpu = false;
        }
    }
}
