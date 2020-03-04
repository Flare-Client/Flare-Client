using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Flare_Sharp.ClientBase.Modules
{
    public abstract class VisualModule : Module
    {
        public Color primary
        {
            get
            {
                return OverlayHost.primary;
            }
        }
        public Color secondary
        {
            get
            {
                return OverlayHost.secondary;
            }
        }
        public Color tertiary
        {
            get
            {
                return OverlayHost.tertiary;
            }
        }
        public Color quaternary
        {
            get
            {
                return OverlayHost.quaternary;
            }
        }
        public Color rainbow
        {
            get
            {
                return OverlayHost.rainbow;
            }
        }
        public WriteableBitmap screen
        {
            get
            {
                return OverlayHost.writeableBitmap;
            }
        }
        public VisualModule(string name, Category category, int keybind, bool enabled) : base(name, category, keybind, enabled)
        {
        }

        public virtual void onRender()
        {
            
        }
    }
}
