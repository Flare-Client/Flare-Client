using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI
{
    public class TabUI : Form
    {
        public delegate void fixSizeDel();

        public static TabUI ui;
        SolidBrush primary = new SolidBrush(Color.FromArgb(255, 100, 100));
        SolidBrush secondary = new SolidBrush(Color.FromArgb(25, 25, 25));
        SolidBrush ternary = new SolidBrush(Color.FromArgb(100, 255, 100));

        float scale = 1;
        int tFontSize = 72;
        int fontSize = 32;
        Font titleFont;
        Font textFont;
        int x = 0;
        int y = 0;

        public TabUI()
        {
            ui = this;
            this.TopMost = true;
            Console.WriteLine("Starting Tab GUI...");
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(77, 77, 77);
            this.BackColor = this.TransparencyKey;
            this.Paint += OnPaint;
            this.Load += OnLoad;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public void OnLoad(object sender, EventArgs e)
        {
            Thread posThread = new Thread(() =>
            {
                int lx = 0;
                int ly = 0;
                while (true)
                {
                    fixSizeDel del = new fixSizeDel(() =>
                    {
                        MCM.RECT mcRect = MCM.getMinecraftRect();
                        x = mcRect.Left+16;
                        y = mcRect.Top+30;
                        if (x != lx || y!= ly)
                        {
                            lx = x;
                            ly = y;
                            ui.Refresh();
                        }
                    });
                    ui.Invoke(del);
                }
            });
            posThread.Start();
            Console.WriteLine("Tab GUI overlay loop started!");
        }

        public void OnPaint(object sender, PaintEventArgs args)
        {
            Graphics graphics = args.Graphics;
            //Adjust fonts
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);

            graphics.DrawString("Flare", titleFont, primary, x-16, y);
            uint c = 0;
            float catWidth = 0;
            foreach (ICategory category in CategoryHandler.registry.categories)
            {
                float wid = graphics.MeasureString(category.getName(), textFont, 200).Width;
                if(wid > catWidth)
                {
                    catWidth = wid;
                }
            }
            foreach (ICategory category in CategoryHandler.registry.categories)
            {
                graphics.FillRectangle(secondary, x, y + tFontSize + (32 * scale) * c, catWidth*scale, 32*scale);
                if (category.getSelected())
                {
                    graphics.FillRectangle(ternary, x, y+tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                }
                graphics.DrawString(category.getName(), textFont, primary, x, y+tFontSize + (32 * scale) * c);
                c++;
            }
        }
    }
}
/*
uint m = 0;
                foreach (Module module in ModuleHandler.registry.modules)
                {
                    if (module.category.getActive())
                    {

                    }
                    m++;
                }
*/