using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.UI;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
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
        public static bool isKeyDown(char key) { return SDK.instance.GetKeyState(key); }

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
            Console.WriteLine("Starting key handler");
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
                for (char c = (char)0; c < 0xFF; c++)
                {
                    noKey[c] = true;
                    yesKey[c] = false;
                    if (SDK.instance.GetKeyState(c) || (c < 0x7&&SDK.instance.GetMouseState(c)))
                    {
                        if (clientKeyHeldEvent != null)
                            try
                            {
                                clientKeyHeldEvent.Invoke(this, new clientKeyEvent(c));
                            }catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.StackTrace);
                            }
                        noKey[c] = false;
                        if (downBuffs[c] > 0)
                        {
                            continue;
                        }
                        downBuffs[c]++;
                        try
                        {
                            if (clientKeyDownEvent!=null)
                                clientKeyDownEvent.Invoke(this, new clientKeyEvent(c));
                            OverlayHost.ui.repaint();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                    else
                    {
                        yesKey[c] = true;
                        if (releaseBuffs[c] > 0)
                        {
                            continue;
                        }
                        releaseBuffs[c]++;
                        if (clientKeyUpEvent != null)
                        {
                            try
                            {
                                clientKeyUpEvent.Invoke(this, new clientKeyEvent(c));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.StackTrace);
                            }
                        }
                        OverlayHost.ui.repaint();
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
            };

            clientKeyDownEvent += dispatchKeybinds;
            Console.WriteLine("key handler started");
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
