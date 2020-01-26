using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Keybinds
{
    public class KeybindHandler
    {
        [DllImport("user32", SetLastError = true)]
        public static extern bool GetAsyncKeyState(char vKey);

        public static KeybindHandler handler;
        public static EventHandler<clientKeyDownEvent> clientKeyDownEvent;
        public static EventHandler<clientKeyDownEvent> clientKeyHeldEvent;

        Dictionary<char, uint> keyBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> noKey = new Dictionary<char, bool>();

        public KeybindHandler()
        {
            handler = this;
            Console.WriteLine("Starting key thread");
            Thread keyDownThread = new Thread(()=>
            {
                for(char c = (char)0; c < 0xFF; c++)
                {
                    keyBuffs.Add(c, 0);
                    noKey.Add(c, true);
                }
                while (true)
                {
                    if (MCM.isMinecraftFocused())
                    {
                        for (char c = (char)0; c < 0xFF; c++)
                        {
                            noKey[c] = true;
                            if (GetAsyncKeyState(c))
                            {
                                noKey[c] = false;
                                if (keyBuffs[c] > 0)
                                {
                                    continue;
                                }
                                keyBuffs[c]++;
                                TabUI.ui.Invalidate();
                                clientKeyDownEvent.Invoke(this, new clientKeyDownEvent(c));
                            }
                            if (noKey[c])
                            {
                                keyBuffs[c] = 0;
                            }
                        }
                    }
                    Thread.Sleep(Program.threadSleep / 10);
                }
            });
            keyDownThread.Start();
            Thread keyHeldThread = new Thread(() =>
            {
                while (true)
                {
                    if (MCM.isMinecraftFocused())
                    {
                        for (char c = (char)0; c < 0xFF; c++)
                        {
                            if (GetAsyncKeyState(c))
                            {
                                clientKeyHeldEvent.Invoke(this, new clientKeyDownEvent(c));
                            }
                        }
                    }
                    Thread.Sleep(Program.threadSleep / 10);
                }
            });
            keyHeldThread.Start();

            clientKeyDownEvent += dispatchKeybinds;
            Console.WriteLine("key thread started");
        }

        public void dispatchKeybinds(object sender, clientKeyDownEvent e)
        {
            foreach(Category cat in CategoryHandler.registry.categories)
            {
                foreach(Module mod in cat.modules)
                {
                    if(mod.keybind == e.key)
                    {
                        mod.enabled = !mod.enabled;
                    }
                }
            }
        }
    }
    public class clientKeyDownEvent : EventArgs
    {
        public char key;
        public clientKeyDownEvent(char key)
        {
            this.key = key;
        }
    }
}
