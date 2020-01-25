using Flare_Sharp.ClientBase.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules
{
    public interface IModule
    {
        ICategory getCategory();
        void onEnable();
        void onDisable();
        void onTick();
    }
}
