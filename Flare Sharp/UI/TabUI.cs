using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI
{
    public class TabUI : Form
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr voidProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        public delegate void fixSizeDel();

        public static TabUI ui;
        public SolidBrush primary = new SolidBrush(Color.FromArgb(255, 100, 100));
        public SolidBrush secondary = new SolidBrush(Color.FromArgb(25, 25, 25));
        public SolidBrush tertiary = new SolidBrush(Color.FromArgb(100, 255, 100));
        public SolidBrush quaternary = new SolidBrush(Color.FromArgb(100, 100, 255));

        float scale = 1;
        int tFontSize = 72;
        int fontSize = 32;
        Font titleFont;
        Font textFont;
        int x = 0;
        int y = 0;
        int width = 0;
        int height = 0;
        public float catWidth = 0;
        public Graphics graphics;
        IntPtr hWnd;
        WinEventDelegate overDel;

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
            //this.Load += OnLoad;
            this.Location = new Point(0, 0);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            hWnd = this.Handle;
            overDel = new WinEventDelegate(adjustOverlay);
            IntPtr result = SetWinEventHook((uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, (uint)MCM.mcWinProcId, GetWindowThreadProcessId(MCM.mcWinHandle, IntPtr.Zero), (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            Console.WriteLine("Overlay hooked the win event! {0}",result.ToInt64().ToString("X"));
        }

        public void OnLoad(object sender, EventArgs e)
        {
            Thread posThread = new Thread(() =>
            {
                while (true)
                {
                    fixSizeDel del = new fixSizeDel(() =>
                    {
                        ui.Refresh();
                    });
                    ui.Invoke(del);
                    Thread.Sleep(Program.threadSleep);
                }
            });
            posThread.Start();
            Console.WriteLine("Tab GUI overlay loop started!");
        }

        public void adjustOverlay(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            //Adust window position
            MCM.RECT mcRect = MCM.getMinecraftRect();
            x = mcRect.Left + 16;
            y = mcRect.Top + 30;
            width = mcRect.Right - mcRect.Left;
            height = mcRect.Bottom - mcRect.Top;
            SetWindowPos(hWnd, MCM.isMinecraftFocusedInsert(), x, y, width, height, 0x0040);
        }

        public void OnPaint(object sender, PaintEventArgs args)
        {
            //Render
            graphics = args.Graphics;
            //Adjust fonts
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);

            graphics.DrawString("Flare", titleFont, primary, -10, 0);
            uint c = 0;
            catWidth = 0;
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
                graphics.FillRectangle(secondary, 0, tFontSize + (32 * scale) * c, catWidth*scale, 32*scale);
                if (category.active)
                {
                    graphics.FillRectangle(quaternary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                    //Draw modules
                    float modWidth = 0;
                    foreach (Module module in category.modules)
                    {
                        float wid = graphics.MeasureString(module.name, textFont, 400).Width;
                        if (wid > modWidth)
                        {
                            modWidth = wid;
                        }
                    }
                    uint m = 0;
                    foreach (Module module in category.modules)
                    {
                        graphics.FillRectangle(secondary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        if (module.enabled)
                        {
                            graphics.FillRectangle(quaternary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        graphics.DrawString(module.name, textFont, primary, catWidth, tFontSize + (32 * scale) * m);
                        float kwid = graphics.MeasureString(module.keybind.ToString(), textFont, 200).Width;
                        graphics.FillRectangle(secondary, catWidth + modWidth, tFontSize + (32 * scale) * m, kwid * scale, 32 * scale);
                        graphics.DrawString(module.keybind.ToString(), textFont, primary, catWidth + modWidth, tFontSize + (32 * scale) * m);
                        if (module.selected)
                        {
                            graphics.DrawRectangle(new Pen(tertiary.Color, 2), catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        m++;
                    }
                }
                else if (category.selected)
                {
                    graphics.FillRectangle(tertiary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                }
                graphics.DrawString(category.name, textFont, primary, 0, tFontSize + (32 * scale) * c);
                c++;
            }
            //Draw enabled modules
            uint yOff = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        float mwid = graphics.MeasureString(mod.name, textFont, 200).Width;
                        graphics.DrawString(mod.name, textFont, primary, width - mwid, tFontSize + (32 * scale) * yOff);
                        yOff++;
                    }
                }
            }
        }
    }
}