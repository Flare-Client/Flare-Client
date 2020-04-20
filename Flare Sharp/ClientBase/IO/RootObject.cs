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
        public List<int> moduleKeybinds = new List<int>();
        public List<int> moduleSliderSettings = new List<int>();
        public List<float> moduleFloatSliderSetting = new List<float>();
        public List<string> targets = new List<string>();
        public RootObject()
        {

        }
    }
}