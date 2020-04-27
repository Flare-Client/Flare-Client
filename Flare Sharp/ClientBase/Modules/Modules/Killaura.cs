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
    public class Killaura : Module
    {
        public Killaura() : base("Killaura", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterSliderSetting("Delay (MS)", 0, 50, 5000);
        }

        public override void onEnable()
        {
            base.onEnable();
            killauraThreadStart();
        }

        public void killauraThreadStart()
        {
            if (enabled)
            {
                Task.Delay(sliderSettings[0].value).ContinueWith(t =>
                {

                    while (!t.IsCompleted)
                    {
                        Mob closestEnt = Utils.getClosestEntity(Minecraft.clientInstance.localPlayer.level.getMovingEntities);

                        if (closestEnt.username != null)
                        {

                            Minecraft.clientInstance.localPlayer.level.setLookingEnt = closestEnt.addr;
                            Minecraft.clientInstance.localPlayer.level.lookingState = 1;
                            Console.WriteLine(closestEnt.username);
                        }
                    }

                    //Console.WriteLine("Thread completed, making new one!");
                    killauraThreadStart();
                });
            }
        }
        public override void onDisable()
        {
            base.onDisable();
        }
    }
}
