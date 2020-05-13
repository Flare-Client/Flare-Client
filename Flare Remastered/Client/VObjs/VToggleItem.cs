using Flare_Remastered.Client.Keybinds;

using System.Drawing;
using System.Windows.Forms;

namespace Flare_Remastered.Client.VObjs
{
    public class VToggleItem : VSubShelfItem
    {
        bool clicked = false;
        public virtual bool value
        {
            get; set;
        }
        public VToggleItem(string name, bool value, VShelfItem parent) : base(24, false, parent)
        {
            this.text = name;
            this.value = value;
        }
        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (clicked)
                e.Graphics.FillRectangle(tertiary, objRect);
            string btext = value.ToString();
            float wid = e.Graphics.MeasureString(btext, font).Width;
            e.Graphics.DrawString(btext, font, primary, x + width - wid, y);
            e.Graphics.DrawString(text, font, primary, x, y);
        }
        public override void OnInteractDown(clientKeyEvent e)
        {
            base.OnInteractDown(e);
            if (opened)
            {
                if (e.key == 0x1)
                {
                    Point p = new Point(Cursor.Position.X - OverlayHost.overlayForm.Left, Cursor.Position.Y - OverlayHost.overlayForm.Top);
                    if (objRect.Contains(p))
                    {
                        this.value = !this.value;
                        clicked = true;
                        
                    }
                }
            }
        }
        public override void OnInteractUp(clientKeyEvent a)
        {
            base.OnInteractUp(a);
            clicked = false;
            
        }
    }
}
