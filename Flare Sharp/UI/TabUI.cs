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
        SolidBrush tertiary = new SolidBrush(Color.FromArgb(100, 255, 100));
        SolidBrush quaternary = new SolidBrush(Color.FromArgb(100, 100, 255));

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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                        ui.TopMost = MCM.isMinecraftFocused();
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
            foreach (Category category in CategoryHandler.registry.categories)
            {
                float wid = graphics.MeasureString(category.name, textFont, 200).Width;
                if(wid > catWidth)
                {
                    catWidth = wid;
                }
            }
            foreach (Category category in CategoryHandler.registry.categories)
            {
                //Draw category
                graphics.FillRectangle(secondary, x, y + tFontSize + (32 * scale) * c, catWidth*scale, 32*scale);
                if (category.active)
                {
                    graphics.FillRectangle(quaternary, x, y + tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                    //Draw modules
                    float modWidth = 0;
                    foreach (Module module in category.modules)
                    {
                        float wid = graphics.MeasureString(module.name, textFont, 200).Width;
                        if (wid > modWidth)
                        {
                            modWidth = wid;
                        }
                    }
                    uint m = 0;
                    foreach (Module module in category.modules)
                    {
                        graphics.FillRectangle(secondary, x + catWidth, y + tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        if (module.enabled)
                        {
                            graphics.FillRectangle(quaternary, x + catWidth, y + tFontSize + (32 * scale) * m, catWidth * scale, 32 * scale);
                        }
                        else if (module.selected)
                        {
                            graphics.FillRectangle(tertiary, x + catWidth, y + tFontSize + (32 * scale) * m, catWidth * scale, 32 * scale);
                        }
                        graphics.DrawString(module.name, textFont, primary, x + catWidth, y + tFontSize + (32 * scale) * m);
                        m++;
                    }
                }
                else if (category.selected)
                {
                    graphics.FillRectangle(tertiary, x, y + tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                }
                graphics.DrawString(category.name, textFont, primary, x, y+tFontSize + (32 * scale) * c);
                c++;
            }
        }
    }
}