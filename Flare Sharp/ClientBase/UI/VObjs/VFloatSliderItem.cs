
using Flare_Sharp.ClientBase.Keybinds;
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
    public class VFloatSliderItem : VSubShelfItem
    {
        public float minimum;
        public virtual float value
        {
            get; set;
        }
        public float maximum;
        bool dragging = false;

        float total
        {
            get
            {
                return Math.Abs(minimum) + Math.Abs(maximum);
                //return minimum + maximum;
            }
        }
        float incBy
        {
            get
            {
                return (float)width / total;
            }
        }
        List<RectangleF> increments = new List<RectangleF>();
        public VFloatSliderItem(string name, float minimum, float value, float maximum, VShelfItem parent) : base(24, false, parent)
        {
            this.text = name;
            this.minimum = minimum;
            this.value = value;
            this.maximum = maximum;
            for (int i = 0; i < total + 1; i++)
            {
                increments.Add(new RectangleF(x + (i * incBy), 0, incBy, height));
            }
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < total + 1; i++)
            {
                RectangleF drawn = increments[i];
                drawn.X = x + (i * incBy);
                drawn.Y = y;
                increments[i] = drawn;
                if (i <= value + Math.Abs(minimum) - 1)
                {
                    e.Graphics.FillRectangle(tertiary, drawn);
                }
            }
            if (value < minimum)
            {
                value = minimum;
            } else if(value > maximum) value = maximum;
            e.Graphics.DrawString(value.ToString(), font, primary, x + width - (font.Size * value.ToString().Length), y);
            e.Graphics.DrawString(text, font, primary, x, y);
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (opened)
            {
                if (e.key == 0x1)
                {
                    Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                    if (objRect.Contains(p))
                    {
                        this.dragging = true;
                    }
                }
            }
        }
        public override void OnInteractHeld(clientKeyEvent e)
        {
            base.OnInteractHeld(e);
            if (opened)
            {
                if (this.dragging)
                {
                    if (e.key == 0x1)
                    {
                        Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                        for (int i = 0; i < total + 1; i++)
                        {
                            if (increments[i].Contains(p))
                            {
                                value = i - Math.Abs(minimum);
                            }
                        }
                        OverlayHost.ui.Invalidate();
                    }
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent e)
        {
            base.OnInteractUp(e);
            if (opened)
            {
                if (e.key == 0x1)
                {
                    this.dragging = false;
                    //
                    OverlayHost.ui.Invalidate();
                }
            }
        }
    }
}
