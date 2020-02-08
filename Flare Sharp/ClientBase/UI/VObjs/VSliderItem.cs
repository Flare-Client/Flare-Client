using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VSliderItem : VSubShelfItem
    {
        public int minimum;
        public int value;
        public int maximum;

        public VSliderItem(string name, int minimum, int value, int maximum) : base(24, false)
        {
            this.text = name;
            this.minimum = minimum;
            this.value = value;
            this.maximum = maximum;
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(text, font, primary, x, y);
            e.Graphics.DrawString(value.ToString(), font, primary, x + width - font.Size, y);
        }
    }
}
