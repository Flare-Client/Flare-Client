using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Settings
{
    public class CheckboxSetting : Setting
    {
        bool isChecked;
        public CheckboxSetting(string name, bool isChecked) : base(name)
        {
            this.isChecked = isChecked;
        }
    }
}
