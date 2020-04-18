using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class FastLadder : Module
    {
        public FastLadder() : base("FastLadder", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] Up = { 0xC7, 0x81, 0x98, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3E };
            byte[] Down = { 0x41, 0xC7, 0x86, 0x98, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0xBE };
            MCM.writeBaseBytes(Statics.ladderUp, Up);
            MCM.writeBaseBytes(Statics.ladderDown, Down);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] Up = { 0xC7, 0x81, 0x98, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0x4C, 0x3E };
            byte[] Down = { 0x41, 0xC7, 0x86, 0x98, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0x4C, 0xBE };
            MCM.writeBaseBytes(Statics.ladderUp, Up);
            MCM.writeBaseBytes(Statics.ladderDown, Down);
        }
    }
}
