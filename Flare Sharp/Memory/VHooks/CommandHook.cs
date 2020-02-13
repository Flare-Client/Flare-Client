using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.VHooks
{
    public class CommandHook
    {
        public static CommandHook instance;
        public CommandHook()
        {
            instance = this;
            //patchGame();
            //Program.mainLoop += dispatchCommands;
        }

        private void dispatchCommands(object sender, EventArgs e)
        {
            if (MCM.readBaseByte(0x1EAF128) == 2)
            {
                UInt64[] noff = { 0 };
                string input = MCM.readString(MCM.baseEvaluatePointer(0x1EAF11C, noff), 256);
                MCM.writeBaseByte(0x1EAF128, 1);
            }
        }

        public void patchGame()
        {
            MCM.unprotectMemory(MCM.mcBaseAddress + 0x1EAF0B4, 2048);
            byte[] chatHookPatch = MCM.ceByte2Bytes("57 48 83 EC 70 80 BB 00 07 00 00 21 0F 85 AF BE 3B FE C7 05 58 00 00 00 02 00 00 00 90 48 81 C3 00 07 00 00 48 89 1D 3D 00 00 00 48 81 EB 00 07 00 00 83 3D 3B 00 00 00 01 75 E1 C7 83 00 07 00 00 00 00 00 00 C7 83 04 07 00 00 00 00 00 00 C6 05 1E 00 00 00 00 E9 66 BE 3B FE 90 00 00 00 00 00 00 00");
            byte[] entryHook = MCM.ceByte2Bytes("E9 3F 41 C4 01 90");

            MCM.writeBaseBytes(0x1EAF0B4, chatHookPatch);
            MCM.writeBaseBytes(0x26AF70, entryHook);
        }


    }
}
