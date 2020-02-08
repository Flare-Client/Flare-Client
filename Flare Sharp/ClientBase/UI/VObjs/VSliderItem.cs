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
    public class VSliderItem : VSubShelfItem
    {
        public int minimum;
        public virtual int value
        {
            get;set;
        }
        public int maximum;
        bool dragging = false;

        int total
        {
            get
            {
                return Math.Abs(minimum) + Math.Abs(maximum)+1;
            }
        }
        int incBy
        {
            get
            {
                return width / total;
            }
        }
        List<Rectangle> increments = new List<Rectangle>();
        public VSliderItem(string name, int minimum, int value, int maximum) : base(24, false)
        {
            this.text = name;
            this.minimum = minimum;
            this.value = value;
            this.maximum = maximum;
            for(int i =0; i< total; i++)
            {
                increments.Add(new Rectangle(x + (i * incBy), 0, incBy, height));
            }
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < total; i++)
            {
                Rectangle drawn = increments[i];
                drawn.X = x + (i * incBy);
                drawn.Y = y;
                increments[i] = drawn;
                if (i <= value+ Math.Abs(minimum)-1)
                {
                    e.Graphics.FillRectangle(tertiary, drawn);
                }
            }
            e.Graphics.DrawString(text, font, primary, x, y);
            e.Graphics.DrawString(value.ToString(), font, primary, x + width - font.Size, y);
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (e.key == 0x1)
            {
                Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                if (objRect.Contains(p))
                {
                    this.dragging = true;
                }
            }
        }
        public override void OnInteractHeld(clientKeyEvent e)
        {
            base.OnInteractHeld(e);
            if (this.dragging)
            {
                if (e.key == 0x1)
                {
                    Point p = new Point(Cursor.Position.X - OverlayHost.ui.Left, Cursor.Position.Y - OverlayHost.ui.Top);
                    for (int i = 0; i < total; i++)
                    {
                        if (increments[i].Contains(p))
                        {
                            value = i-Math.Abs(minimum);
                        }
                    }
                    OverlayHost.ui.Invalidate();
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent e)
        {
            base.OnInteractUp(e);
            if (e.key == 0x1)
            {
                this.dragging = false;
                OverlayHost.ui.Invalidate();
            }
        }
    }
}
