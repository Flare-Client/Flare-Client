using Flare_Sharp.ClientBase.Categories;
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
        SolidBrush secondary = new SolidBrush(Color.FromArgb(100, 100, 100));
        SolidBrush ternary = new SolidBrush(Color.FromArgb(100, 255, 100));

        float scale = 1;
        int tFontSize = 72;
        int fontSize = 32;
        Font titleFont;
        Font textFont;

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
        }

        public void OnLoad(object sender, EventArgs e)
        {
            Thread posThread = new Thread(() =>
            {
                int leftC = 0;
                while (true)
                {
                    fixSizeDel del = new fixSizeDel(() =>
                    {
                        if (MCM.getMinecraftRect().Left != leftC)
                        {
                            this.Location = new Point(MCM.getMinecraftRect().Left, MCM.getMinecraftRect().Top);
                            this.Size = new Size(MCM.getMinecraftRect().Right, MCM.getMinecraftRect().Bottom);
                            leftC = MCM.getMinecraftRect().Left;
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

            graphics.DrawString("Flare", titleFont, primary, 0, 0);
            uint c = 0;
            foreach (ICategory category in CategoryHandler.registry.categories)
            {
                graphics.FillRectangle(secondary, 8, tFontSize + (32 * scale) * c, 200, 32);
                if (category.getSelected())
                {
                    graphics.FillRectangle(ternary, 8, tFontSize + (32 * scale) * c, 200, 32);
                }
                graphics.DrawString(category.getName(), textFont, primary, 8, tFontSize + (32 * scale) * c);
                //uint m = 0;
                //foreach (IModule module in ModuleHandler.registry.modules)
                //{
                //    m++;
                //}
                c++;
            }
        }
    }
}
