using Flare_Remastered.Client;
using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Remastered.Client.VObjs
{
    public abstract class VObject
    {
        public bool debugMode = false;
        public string text = "Object";
        public bool visible {
            get
            {
                return CategoryHandler.registry.categories[3].modules[3].enabled;
            }
        }
        public Font font
        {
            get
            {
                return OverlayHost.font;
            }
        }

        public Rectangle objRect
        {
            get
            {
                return new Rectangle(x, y, width, height);
            }
            set
            {
                x = value.X;
                y = value.Y;
                width = value.Width;
                height = value.Height;
            }
        }
        public int x;
        public int y;
        public int width;
        public int height;

        public SolidBrush primary {
            get
            {
                return OverlayHost.primary;
            }
        }
        public SolidBrush secondary
        {
            get
            {
                return OverlayHost.secondary;
            }
        }
        public SolidBrush tertiary
        {
            get
            {
                return OverlayHost.tertiary;
            }
        }
        public SolidBrush quaternary
        {
            get
            {
                return OverlayHost.quaternary;
            }
        }
        public SolidBrush quinary
        {
            get
            {
                return OverlayHost.quinary;
            }
        }

        public VObject()
        {
            KeybindHandler.clientKeyDownEvent += (object s, clientKeyEvent a) =>
            {
                if (visible)
                {
                    OnInteractDown(a);
                }
            };
            KeybindHandler.clientKeyHeldEvent += (object s, clientKeyEvent a) =>
            {
                if (visible)
                {
                    OnInteractHeld(a);
                }
            };
            KeybindHandler.clientKeyUpEvent += (object s, clientKeyEvent a) =>
            {
                if (visible)
                {
                    OnInteractUp(a);
                }
            };
        }

        public virtual void OnPaint(PaintEventArgs e)
        {
            if (debugMode)
                OnPaintDBG(e);
        }

        public virtual void OnPaintDBG(PaintEventArgs e)
        {
            Point p = new Point(Cursor.Position.X - OverlayHost.overlayForm.Left, Cursor.Position.Y - OverlayHost.overlayForm.Top);
            e.Graphics.DrawLine(new Pen(primary), x, y, p.X, p.Y);
        }

        public virtual void OnInteractDown(clientKeyEvent a)
        {

        }
        public virtual void OnInteractHeld(clientKeyEvent a)
        {

        }
        public virtual void OnInteractUp(clientKeyEvent a)
        {

        }
    }
}
