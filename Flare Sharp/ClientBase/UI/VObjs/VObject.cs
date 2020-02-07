using Flare_Sharp.ClientBase.Keybinds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public abstract class VObject
    {
        public string text = "Object";
        public bool visible = false;
        public Font font = new Font("Arial", 16, FontStyle.Regular);

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

        public SolidBrush primary;
        public SolidBrush secondary;
        public SolidBrush tertiary;
        public SolidBrush quaternary;
        public SolidBrush rainbow;

        public VObject()
        {
            primary = OverlayHost.ui.primary;
            secondary = OverlayHost.ui.secondary;
            tertiary = OverlayHost.ui.tertiary;
            quaternary = OverlayHost.ui.quaternary;
            rainbow = OverlayHost.ui.rainbow;
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
