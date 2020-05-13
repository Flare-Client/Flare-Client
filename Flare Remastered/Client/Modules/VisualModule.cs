using Flare_Remastered.Client.Categories;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.Client.Modules
{
    public abstract class VisualModule : Module
    {
        public int tFontSize = 72;
        public int fontSize = 32;
        public Font titleFont;
        public Font textFont;
        public Font textFontSmall;
        public float scale = 1;
        public SolidBrush primary
        {
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

        public VisualModule(string name, Category category, int keybind, bool enabled) : base(name, category, keybind, enabled)
        {
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFontSmall = new Font(new FontFamily("Arial"), fontSize * scale / 2, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public virtual void onDraw(Graphics graphics)
        {

        }
    }
}
