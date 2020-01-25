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
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool GetAsyncKeyState(char vKey);

        public static KeybindHandler handler;
        public static EventHandler<ClientKeyEvent> clientKeyEvent;

        public KeybindHandler()
        {
            handler = this;
            Console.WriteLine("Starting key thread");
            Thread keyThread = new Thread(()=>
            {
                while (true)
                {
                    for(char c = (char)0; c<255; c++)
                    {
                        if (GetAsyncKeyState(c))
                        {
                            clientKeyEvent.Invoke(this, new ClientKeyEvent(c));
                        }
                    }
                }
            });
            keyThread.Start();
            Console.WriteLine("key thread started");
        }
    }
    public class ClientKeyEvent : EventArgs
    {
        public char key;
        public ClientKeyEvent(char key)
        {
            this.key = key;
        }
    }
}
