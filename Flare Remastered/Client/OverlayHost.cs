using Flare_Remastered.Memory;
using Flare_Remastered.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Remastered.Client
{
    public class OverlayHost
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
        public static extern UInt64 SetWindowLong(IntPtr hWnd, int nIndex, UInt64 dwNewLong);
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

        public static SolidBrush primary = new SolidBrush(Color.FromArgb(255, 255, 255));
        public static SolidBrush secondary = new SolidBrush(Color.FromArgb(25, 25, 25));
        public static SolidBrush tertiary = new SolidBrush(Color.FromArgb(100, 100, 255));
        public static SolidBrush quaternary = new SolidBrush(Color.FromArgb(255, 0, 255));
        public static SolidBrush quinary = new SolidBrush(Color.FromArgb(50, 50, 50));

        static WinEventDelegate overDel;
        static IntPtr hWnd;
        public static int x = 0;
        public static int y = 0;
        public static int width = 0;
        public static int height = 0;
        public static int fullScOff = 0;

        public static Font font = new Font("Arial", 16, FontStyle.Regular);

        public static Form overlayForm;

        static Color transparencyKey = Color.FromArgb(77, 77, 77);

        public static void runOverlay()
        {
            overlayForm = new Form();

            hWnd = overlayForm.Handle;

            overDel = new WinEventDelegate(adjustOverlay);
            SetWinEventHook((uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, (uint)MCM.mcWinProcId, GetWindowThreadProcessId(MCM.mcWinHandle, IntPtr.Zero), (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            SetWinEventHook((uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, (uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, overDel, 0, 0, (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);

            //UInt64 initialStyle = GetWindowLong(overlayForm.Handle, -20);
            //SetWindowLong(overlayForm.Handle, -20, initialStyle | 0x80000 | 0x20);

            overlayForm.Size = new Size(1280, 720);
            overlayForm.TransparencyKey = transparencyKey;
            overlayForm.BackColor = transparencyKey;
            overlayForm.Paint += OverlayForm_Paint;
            overlayForm.FormBorderStyle = FormBorderStyle.None;

            Application.Run(overlayForm);
            //overlayForm.Invalidate();
        }

        public static void adjustOverlay(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            trueAdjust();
        }
        static void trueAdjust()
        {
            //If it is fullscreen, the title bar is larger
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(MCM.mcWinHandle, ref placement);
            if (placement.showCmd == SW_MAXIMIZE)
            {
                fullScOff = 8;
                overlayForm.TopMost = true;
                overlayForm.WindowState = FormWindowState.Maximized;
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


        public static EventHandler<PaintEventArgs> onRender;
        private static void OverlayForm_Paint(object sender, PaintEventArgs e)
        {
            Brush transparentBrush = new SolidBrush(transparencyKey);
            int doublebuff = 0;
            int framesUntilClear = 5;
            Graphics g = e.Graphics;
            while (true)
            {
                if (doublebuff > framesUntilClear)
                {
                    g.FillRectangle(transparentBrush, new Rectangle(new Point(0, 0), overlayForm.ClientSize));
                    doublebuff = 0;
                }
                doublebuff++;
                trueAdjust();
                onRender.Invoke(null, e);
                Thread.Sleep(1);
                overlayForm.ClientSize = overlayForm.Size;
                g = overlayForm.CreateGraphics();
            }
        }
    }
}
