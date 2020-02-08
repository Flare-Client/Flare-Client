using Flare_Sharp.ClientBase.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.IO
{
    public class RootObject
    {
        public List<bool> enabledModules = new List<bool>();
        public List<char> moduleKeybinds = new List<char>();
        public RootObject()
        {

        }
    }
}
