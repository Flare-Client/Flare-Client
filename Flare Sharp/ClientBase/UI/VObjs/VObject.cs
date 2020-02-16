using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
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
    public abstract class VObject
    {
        public string text = "Object";
        public bool visible
        {
            get
            {
                return CategoryHandler.registry.categories[3].modules[2].enabled;
            }
        }

        public Rect objRect
        {
            get
            {
                return new Rect(x, y, width, height);
            }
            set
            {
                x = value.X;
                y = value.Y;
                width = value.Width;
                height = value.Height;
            }
        }
        public double x;
        public double y;
        public double width;
        public double height;

        public Point GetMousePosition()
        {
            Win32.Win32Point w32Mouse = new Win32.Win32Point();
            Win32.GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        public SolidColorBrush primary {
            get
            {
                return OverlayHost.primary;
            }
        }
        public SolidColorBrush secondary
        {
            get
            {
                return OverlayHost.secondary;
            }
        }
        public SolidColorBrush tertiary
        {
            get
            {
                return OverlayHost.tertiary;
            }
        }
        public SolidColorBrush quaternary
        {
            get
            {
                return OverlayHost.quaternary;
            }
        }
        public SolidColorBrush quinary
        {
            get
            {
                return OverlayHost.quinary;
            }
        }
        public SolidColorBrush rainbow
        {
            get
            {
                return OverlayHost.rainbow;
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

        public virtual void OnPaint(DrawingContext context)
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
