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
            byte[] ladderUp = { 0xC7, 0x81, 0x70, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0xCE, 0x3E };
            byte[] ladderDown = { 0x41, 0xC7, 0x86, 0x70, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0xBE };
            MCM.writeBaseBytes(Statics.ladderUp, ladderUp);
            MCM.writeBaseBytes(Statics.ladderDown, ladderDown);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] ladderUp = { 0xC7, 0x81, 0x70, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0x4C, 0x3E };
            byte[] ladderDown = { 0x41, 0xC7, 0x86, 0x70, 0x04, 0x00, 0x00, 0xCD, 0xCC, 0x4C, 0xBE };
            MCM.writeBaseBytes(Statics.ladderUp, ladderUp);
            MCM.writeBaseBytes(Statics.ladderDown, ladderDown);
        }
    }
}
