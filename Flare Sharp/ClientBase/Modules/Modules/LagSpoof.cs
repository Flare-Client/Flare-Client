using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class LagSpoof : Module
    {
        int togglePacketState;
        public LagSpoof() : base("Lag Spoof", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            RegisterSliderSetting("Delay (MS)", 0, 300, 2000);
        }

        public override void onEnable()
        {
            base.onEnable();
            packetDelay();
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.noPacket, 116);
        }

        public async Task packetDelay()
        {
            if (enabled)
            {
                await Task.Delay(sliderSettings[0].value);

                if(Minecraft.clientInstance.localPlayer.username.Length > 0)
                {
                    switch (togglePacketState)
                    {
                        case 0:
                            MCM.writeBaseByte(Statics.noPacket, 117);
                            Console.WriteLine("On");
                            togglePacketState = 1;
                            break;

                        case 1:
                            MCM.writeBaseByte(Statics.noPacket, 116);
                            Console.WriteLine("Off");
                            togglePacketState = 0;
                            break;
                    }
                } else
                {
                    MCM.writeBaseByte(Statics.noPacket, 116);
                }

                await packetDelay();
            }
        }
    }
}
