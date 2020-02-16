using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.Modules
{
    public abstract class VisualModule : Module
    {
        public SolidColorBrush primary
        {
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
        public SolidColorBrush rainbow
        {
            get
            {
                return OverlayHost.rainbow;
            }
        }
        public VisualModule(string name, Category category, int keybind, bool enabled) : base(name, category, keybind, enabled)
        {
        }

        public virtual void onRender()
        {

        }
        public virtual void onDraw(DrawingContext context)
        {

        }
    }
}
