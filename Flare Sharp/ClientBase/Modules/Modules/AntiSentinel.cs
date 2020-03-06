using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AntiSentinel : Module
    {
        int updateTick = 0;
        public AntiSentinel():base("AntiSentinel", CategoryHandler.registry.categories[3], 0x07, false)
        {
            startTimer(1000);
            startTimer(1005);
        }

        public override void onTick()
        {
            base.onTick();
            /*
            if (updateTick > 100 && updateTick < 104)
            {
                MCM.writeBaseByte(0xFA21E0, 3);
                Console.WriteLine("disabled");
            }
            if(updateTick > 105)
            {
                MCM.writeBaseByte(0xFA21E0, 1);
                Console.WriteLine("enabled");
                updateTick = 0;
            }
            updateTick++;
            */
        }

        public override void onTimedTick()
        {
            base.onTimedTick();
            MCM.writeBaseByte(0xFA21E0, 3);
            Console.WriteLine("disabled");
            RunAsync(afterTimedTick());
        }
        public async Task afterTimedTick()
        {
            Thread.Sleep(5);
            MCM.writeBaseByte(0xFA21E0, 1);
            Console.WriteLine("enabled");
            return;
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(0xFA21E0, 3);
        }

        private void RunAsync(Task task)
        {
            task.ContinueWith(t =>
            {
                Console.WriteLine("Unexpected Error " + t.Exception);

            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
