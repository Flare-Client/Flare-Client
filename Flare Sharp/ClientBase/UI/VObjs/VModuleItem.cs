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
            e.DrawRectangle(secondary, null, toggleAbleArea);
            if (module.enabled)
            {
                e.DrawRectangle(rainbow, null, toggleAbleArea);
            }
            base.OnPaint(e);
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            visible = parent.visible;
            if (visible)
            {
                if (a.key == 0x1)
                {
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.Left, GetMousePosition().Y - OverlayHost.ui.Top);
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
