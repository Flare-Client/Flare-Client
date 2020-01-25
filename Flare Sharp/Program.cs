using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flare# Client");
            Console.WriteLine("Flare port to C#");
            Console.WriteLine("Discord: https://discord.gg/Hz3Dxg8");

            CategoryHandler ch = new CategoryHandler();
            ModuleHandler mh = new ModuleHandler();
            TabUI ui = new TabUI();
            Application.Run(ui);
        }
    }
}
