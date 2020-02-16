using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VKeybindItem : VSubShelfItem
    {
        public VModuleItem parent;
        bool changing = false;
        public string renderedKeybind = "";
        public Module module
        {
            get
            {
                return parent.module;
            }
        }

        public VKeybindItem(VModuleItem parent) :base(24, false)
        {
            this.parent = parent;
            this.text = "Keybind";
            renderedKeybind = module.keybind.ToString();
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (visible)
            {
                if (a.key == 0x1)
                {
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
                    if (objRect.Contains(p))
                    {
                        if (!changing)
                        {
                            changing = true;
                            this.renderedKeybind = "...";
                        }
                    }
                }
                if (a.key != 0x1)
                {
                    if (changing)
                    {
                        if (a.key == 0x1B)
                        {
                            module.keybind = 0x07;
                        }
                        else
                        {
                            module.keybind = a.key;
                        }
                        this.renderedKeybind = ((int)a.key).ToString();
                        changing = false;
                    }
                }
            }
        }


        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            FormattedText ftext = DrawUtils.stringToFormatted(renderedKeybind, "Roboto", 16, primary);
            e.DrawText(ftext, new Point(x +width - ftext.Width, y));
        }
    }
}
