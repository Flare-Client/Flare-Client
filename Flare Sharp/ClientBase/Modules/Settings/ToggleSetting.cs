using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Settings
{
    public class ToggleSetting : Setting
    {
        public bool value = false;
        public ToggleSetting(string text, bool value) : base(text)
        {
            this.value = value;
        }
    }
}
