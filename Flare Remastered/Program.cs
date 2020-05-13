using Flare_Remastered.Client;
using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using Flare_Remastered.Client.Modules;
using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Remastered
{
    class Program
    {
        public static EventHandler<EventArgs> mainLoop;
        static void Main(string[] args)
        {
            Console.WriteLine("Flare Remastered");
            Console.WriteLine("A NEW Flare Client using an extension of Flare's Flame SDK, Spark.");

            Console.WriteLine("Attaching game");
            MCM.openGame();
            MCM.openWindowHost();
            Console.WriteLine("Game attached");

            CategoryHandler ch = new CategoryHandler();
            ModuleHandler mh = new ModuleHandler();
            KeybindHandler kh = new KeybindHandler();

            //Hack loop thread
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        mainLoop.Invoke(null, new EventArgs());
                        Thread.Sleep(1);
                    }
                    catch (Exception)
                    {

                    }
                }
            }).Start();

            OverlayHost.runOverlay();
            Console.ReadLine();
        }
    }
}
