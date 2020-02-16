using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VModuleItem : VShelfItem
    {
        public VCatgoryWindow parent;
        public Module module;
        Rect toggleAbleArea;
        public VModuleItem(Module module, VCatgoryWindow parent):base(24, true)
        {
            this.parent = parent;
            this.module = module;
            this.text = module.name;
            children.Add(new VKeybindItem(this));
        }

        public override void OnPaint(DrawingContext e)
        {
            toggleAbleArea = objRect;
            toggleAbleArea.Height = 24;
            e.DrawRectangle(primary, null, toggleAbleArea);
            if (module.enabled)
            {
                e.DrawRectangle(tertiary, null, toggleAbleArea);
            }
            base.OnPaint(e);
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (visible)
            {
                if (a.key == 0x1)
                {
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
                    toggleAbleArea = objRect;
                    toggleAbleArea.Height = 24;
                    if (toggleAbleArea.Contains(p))
                    {
                        module.enabled = !module.enabled;
                    }
                }
            }
        }
    }
}
