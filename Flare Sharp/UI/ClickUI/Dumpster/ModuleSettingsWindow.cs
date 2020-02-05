using Flare_Sharp.UI.ClickUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public class ModuleSettingsWindow : CUIClosableWindow
    {
        CUIModuleItem parent;
        bool interactable = false;
        public ModuleSettingsWindow(CUIModuleItem parent, bool open) : base(open)
        {
            this.parent = parent;
            this.visible = false;

        }


    }
}
