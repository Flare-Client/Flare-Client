using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VKeybindItem : VSubShelfItem
    {
        public new VModuleItem parent;
        bool changing = false;
        public string renderedKeybind = "";
        public Module module
        {
            get
            {
                return parent.module;
            }
        }

        public VKeybindItem(VModuleItem parent) :base(24, false, parent)
        {
            this.parent = parent;
            this.text = "Keybind";
            renderedKeybind = module.keybind.ToString();
        }

        public override void OnInteractDown(clientKeyEvent a)
        {
            base.OnInteractDown(a);
            if (opened)
            {
                if (visible)
                {
                    if (a.key == 0x1)
                    {
                        Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
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
        }


        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(renderedKeybind, font, primary, x+width - font.Size-5, y);
        }
    }
}
