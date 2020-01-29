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
        public static EventHandler<clientKeyEvent> clientKeyDownEvent;
        public static EventHandler<clientKeyEvent> clientKeyHeldEvent;

        Dictionary<char, uint> keyBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> noKey = new Dictionary<char, bool>();

        public KeybindHandler()
        {
            handler = this;
            Console.WriteLine("Starting key thread");
            for (char c = (char)0; c < 0xFF; c++)
            {
                keyBuffs.Add(c, 0);
                noKey.Add(c, true);
            }
            Program.mainLoop += (object sen, EventArgs e)=>
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
                            try
                            {
                                clientKeyDownEvent.Invoke(this, new clientKeyEvent(c));
                            }
                            catch (Exception) { }
                        }
                        if (noKey[c])
                        {
                            keyBuffs[c] = 0;
                        }
                    }
                }
            };
            Program.mainLoop += (object sen, EventArgs e) =>
            {
                if (MCM.isMinecraftFocused())
                {
                    for (char c = (char)0; c < 0xFF; c++)
                    {
                        if (GetAsyncKeyState(c))
                        {
                            try
                            {
                                if(clientKeyHeldEvent != null)
                                {
                                    clientKeyHeldEvent.Invoke(this, new clientKeyEvent(c));
                                }
                            } catch (Exception) { }
                        }
                    }
                }
            };

            clientKeyDownEvent += dispatchKeybinds;
            Console.WriteLine("key shit started");
        }

        public void dispatchKeybinds(object sender, clientKeyEvent e)
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
    public class clientKeyEvent : EventArgs
    {
        public char key;
        public clientKeyEvent(char key)
        {
            this.key = key;
        }
    }
}
