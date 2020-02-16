using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

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
                return Math.Abs(minimum) + Math.Abs(maximum);
            }
        }
        float incBy
        {
            get
            {
                return (float)width / total;
            }
        }
        List<Rect> increments = new List<Rect>();
        public VSliderItem(string name, int minimum, int value, int maximum, VShelfItem parent) : base(24, false, parent)
        {
            this.text = name;
            this.minimum = minimum;
            this.value = value;
            this.maximum = maximum;
            for(int i =0; i< total+1; i++)
            {
                increments.Add(new Rect(x + (i * incBy), 0, incBy, height));
            }
        }

        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            for (int i = 0; i < total+1; i++)
            {
                Rect drawn = increments[i];
                drawn.X = x + (i * incBy);
                drawn.Y = y;
                increments[i] = drawn;
                if (i <= value+ Math.Abs(minimum)-1)
                {
                    e.DrawRectangle(tertiary, null, drawn);
                }
            }
            FormattedText ftext = DrawUtils.stringToFormatted(value.ToString(), "Roboto", 16, secondary);
            e.DrawText(ftext, new Point(x + width - ftext.Width, y));
            e.DrawText(DrawUtils.stringToFormatted(text, "Roboto", 16, primary), new Point(x, y));
        }

        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (visible)
            {
                if (parent.expanded)
                {
                    if (e.key == 0x1)
                    {
                        Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
                        if (objRect.Contains(p))
                        {
                            this.dragging = true;
                        }
                    }
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
                    Point p = new Point(GetMousePosition().X - OverlayHost.ui.x, GetMousePosition().Y - OverlayHost.ui.y);
                    for (int i = 0; i < total+1; i++)
                    {
                        if (increments[i].Contains(p))
                        {
                            value = i-Math.Abs(minimum);
                        }
                    }
                    OverlayHost.ui.repaint();
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent e)
        {
            base.OnInteractUp(e);
            if (e.key == 0x1)
            {
                this.dragging = false;
                FileMan.man.saveConfig();
                OverlayHost.ui.repaint();
            }
        }
    }
}
