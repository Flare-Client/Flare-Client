using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Modules;
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
using Timer = System.Windows.Forms.Timer;

namespace Flare_Sharp.UI
{
    public class OverlayHost : Form
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr voidProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        public static extern UInt64 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        public static extern UInt64 SetWindowLong(IntPtr hWnd,int nIndex, UInt64 dwNewLong);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
        const UInt32 SW_HIDE = 0;
        const UInt32 SW_SHOWNORMAL = 1;
        const UInt32 SW_NORMAL = 1;
        const UInt32 SW_SHOWMINIMIZED = 2;
        const UInt32 SW_SHOWMAXIMIZED = 3;
        const UInt32 SW_MAXIMIZE = 3;
        const UInt32 SW_SHOWNOACTIVATE = 4;
        const UInt32 SW_SHOW = 5;
        const UInt32 SW_MINIMIZE = 6;
        const UInt32 SW_SHOWMINNOACTIVE = 7;
        const UInt32 SW_SHOWNA = 8;

        public static event EventHandler postOverlayLoad;
        public delegate void fixSizeDel();
        public static OverlayHost ui;

        public float rainbowProg = 0f;

        WinEventDelegate overDel;

        IntPtr hWnd;
        public int x = 0;
        public int y = 0;
        public int width = 0;
        public int height = 0;
        public int fullScOff = 0;

        public SolidBrush primary = new SolidBrush(Color.FromArgb(255, 255, 255));
        public SolidBrush secondary = new SolidBrush(Color.FromArgb(25, 25, 25));
        public SolidBrush tertiary = new SolidBrush(Color.FromArgb(100, 100, 255));
        public SolidBrush quaternary = new SolidBrush(Color.FromArgb(255, 0, 255));
        public SolidBrush quinary = new SolidBrush(Color.FromArgb(50, 50, 50));
        public SolidBrush rainbow
        {
            get
            {
                return new SolidBrush(Rainbow(rainbowProg));
            }
        }

        public Font font = new Font("Arial", 16, FontStyle.Regular);

        public OverlayHost()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            ui = this;
            this.TopMost = true;
            Console.WriteLine("Starting Tab GUI...");
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(77, 77, 77);
            this.BackColor = this.TransparencyKey;
            this.Location = new Point(0, 0);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //DBG.Debug("Set overlay styles");
            hWnd = this.Handle;
            overDel = new WinEventDelegate(adjustOverlay);
            //DBG.Debug("Registered event delegates");
            SetWinEventHook((uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, (uint)MCM.mcWinProcId, GetWindowThreadProcessId(MCM.mcWinHandle, IntPtr.Zero), (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            SetWinEventHook((uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, (uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, overDel, 0, 0, (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            //DBG.Debug("Hooked win events");
            //mouseHookID= SetWindowsHookEx(14, mouseMove, GetModuleHandle("user32"), 0);
            UInt64 initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            //DBG.Debug("Set overlay window styles (2)");
            if (postOverlayLoad != null)
            {
                postOverlayLoad.Invoke(this, new EventArgs());
                //DBG.Debug("Invoked post overlay event");
            }
            Paint += OverlayHost_Paint;
            //DBG.Debug("paint hooked");
        }

        private void OverlayHost_Paint(object sender, PaintEventArgs e)
        {
            //DBG.Debug("Drawing to screen...");
            e.Graphics.DrawString("Flare "+Program.version, font, primary, width - (font.Size * Program.version.Length * (float)1.37), height - font.Height);
            foreach(Category cat in CategoryHandler.registry.categories)
            {
                foreach(Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        if (mod is VisualModule)
                        {
                            VisualModule vmod = (VisualModule)mod;
                            vmod.onDraw(e.Graphics);
                        }
                    }
                }
            }
            //DBG.Debug("Drawn!");
        }

        public void adjustOverlay(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            trueAdjust();
        }
        void trueAdjust()
        {
            //If it is fullscreen, the title bar is larger
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(MCM.mcWinHandle, ref placement);
            if (placement.showCmd == SW_MAXIMIZE)
            {
                fullScOff = 8;
                TopMost = true;
                WindowState = FormWindowState.Maximized;
            }
            else
                fullScOff = 0;
            //Adust window position
            MCM.RECT mcRect = MCM.getMinecraftRect();
            x = mcRect.Left + 9;
            y = mcRect.Top + 34 + fullScOff;
            width = mcRect.Right - mcRect.Left - 18;
            height = mcRect.Bottom - mcRect.Top - 43 - fullScOff;
            SetWindowPos(hWnd, MCM.isMinecraftFocusedInsert(), x, y, width, height, 0x0040);
        }

        public static Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, 255, ascending, 0);
                case 1:
                    return Color.FromArgb(255, descending, 255, 0);
                case 2:
                    return Color.FromArgb(255, 0, 255, ascending);
                case 3:
                    return Color.FromArgb(255, 0, descending, 255);
                case 4:
                    return Color.FromArgb(255, ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 255, 0, descending);
            }
        }
    }
}