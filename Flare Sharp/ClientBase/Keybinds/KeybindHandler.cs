using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
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
        public static bool isKeyDown(char key) { return MCM.GetAsyncKeyState(key); }

        public static KeybindHandler handler;
        public static EventHandler<clientKeyEvent> clientKeyDownEvent;
        public static EventHandler<clientKeyEvent> clientKeyHeldEvent;
        public static EventHandler<clientKeyEvent> clientKeyUpEvent;

        Dictionary<char, uint> downBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> noKey = new Dictionary<char, bool>();

        Dictionary<char, uint> releaseBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> yesKey = new Dictionary<char, bool>();

        public KeybindHandler()
        {
            handler = this;
            Console.WriteLine("Starting key thread");
            for (char c = (char)0; c < 0xFF; c++)
            {
                downBuffs.Add(c, 0);
                noKey.Add(c, true);
            }
            for (char c = (char)0; c < 0xFF; c++)
            {
                releaseBuffs.Add(c, 0);
                yesKey.Add(c, true);
            }
            Program.mainLoop += (object sen, EventArgs e)=>
            {
                try
                {
                    if (MCM.isMinecraftFocused())
                    {
                        for (char c = (char)0; c < 0xFF; c++)
                        {
                            noKey[c] = true;
                            yesKey[c] = false;
                            if (MCM.GetAsyncKeyState(c))
                            {
                                if (clientKeyHeldEvent != null)
                                    clientKeyHeldEvent.Invoke(this, new clientKeyEvent(c));
                                noKey[c] = false;
                                if (downBuffs[c] > 0)
                                {
                                    continue;
                                }
                                downBuffs[c]++;
                                if (OverlayHost.ui != null)
                                    OverlayHost.ui.Invalidate();
                                try
                                {
                                    if (clientKeyDownEvent != null)
                                    {
                                        clientKeyDownEvent.Invoke(this, new clientKeyEvent(c));
                                        //DBG.Debug("Dispatched key down [" + c.ToString() + "]");
                                    }
                                }
                                catch (Exception) { }
                            }
                            else
                            {
                                yesKey[c] = true;
                                if (releaseBuffs[c] > 0)
                                {
                                    continue;
                                }
                                releaseBuffs[c]++;
                                if(OverlayHost.ui != null)
                                    OverlayHost.ui.Invalidate();
                                if (clientKeyUpEvent != null)
                                {
                                    try
                                    {
                                        clientKeyUpEvent.Invoke(this, new clientKeyEvent(c));
                                        //DBG.Debug("Dispatched key up [" + c.ToString() + "]");
                                    }
                                    catch (Exception) { }
                                }
                            }
                            if (noKey[c])
                            {
                                downBuffs[c] = 0;
                            }
                            if (!yesKey[c])
                            {
                                releaseBuffs[c] = 0;
                            }
                        }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("KeyHandler failed a task!");
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
