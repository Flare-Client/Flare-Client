﻿using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI.VObjs
{
    public class VModuleItem : VShelfItem
    {
        public VCatgoryWindow parent;
        public Module module;
        public VModuleItem(Module module, VCatgoryWindow parent):base(24)
        {
            this.parent = parent;
            this.module = module;
            this.text = module.name;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(secondary, objRect);
            if (module.enabled)
            {
                e.Graphics.FillRectangle(tertiary, objRect);
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
                    Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                    if (objRect.Contains(p))
                    {
                        module.enabled = !module.enabled;
                    }
                }
            }
        }
    }
}