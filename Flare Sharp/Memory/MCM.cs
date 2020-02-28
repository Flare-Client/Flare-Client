using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory
{
    /*
     * My awesome memory lib i used in FAKE
     * - ASM
     */
    public class MCM
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern int ReadProcessMemory(IntPtr hProcess, UInt64 lpBase, ref UInt64 lpBuffer, int nSize, int lpNumberOfBytesRead);
        [DllImport("kernel32", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, int lpNumberOfBytesWritten);
        [DllImport("kernel32", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref byte lpBuffer, int nSize, int lpNumberOfBytesWritten);
        [DllImport("kernel32", SetLastError = true)]
        public static extern int VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, Int64 flNewProtect, ref Int64 lpflOldProtect
        );
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);
        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }
        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        public static IntPtr mcProcHandle;
        public static ProcessModule mcMainModule;
        public static IntPtr mcBaseAddress;
        public static IntPtr mcWinHandle;
        public static uint mcProcId;
        public static uint mcWinProcId;
        public static Process mcProc;

        public static void openGame()
        {
            Process[] procs = Process.GetProcessesByName("Minecraft.Windows");
            Process mcw10 = procs[0];
            IntPtr proc = OpenProcess(0x1F0FFF, false, mcw10.Id);
            mcProcId = (uint)mcw10.Id;
            mcProcHandle = proc;
            mcMainModule = mcw10.MainModule;
            mcBaseAddress = mcMainModule.BaseAddress;
            mcProc = mcw10;
        }
        public static void openWindowHost()
        {
            Process[] procs = Process.GetProcessesByName("ApplicationFrameHost");
            mcWinHandle = procs[0].MainWindowHandle;
            mcWinProcId = (uint)procs[0].Id;
        }

        public static RECT getMinecraftRect()
        {
            RECT rectMC = new RECT();
            GetWindowRect(mcWinHandle, out rectMC);
            return rectMC;
        }
        public static bool isMinecraftFocused()
        {
            StringBuilder sb = new StringBuilder("Minecraft".Length + 1);
            GetWindowText(GetForegroundWindow(), sb, "Minecraft".Length + 1);
            return sb.ToString() == "Minecraft";
        }
        public static IntPtr isMinecraftFocusedInsert()
        {
            StringBuilder sb = new StringBuilder("Minecraft".Length + 1);
            GetWindowText(GetForegroundWindow(), sb, "Minecraft".Length + 1);
            if(sb.ToString() == "Minecraft")
            {
                return (IntPtr)(-1);
            }
            else
            {
                return (IntPtr)(-2);
            }
        }

        public static void unprotectMemory(IntPtr address, int bytesToUnprotect)
        {
            Int64 receiver = 0;
            VirtualProtectEx(mcProcHandle, address, bytesToUnprotect, 0x40, ref receiver);
        }

        //CE bytes to real bytes for ease
        public static byte[] ceByte2Bytes(string byteString)
        {
            string[] byteStr = byteString.Split(' ');
            byte[] bytes = new byte[byteStr.Length];
            int c = 0;
            foreach (string b in byteStr)
            {
                bytes[c] = (Convert.ToByte(b, 16));
                c++;
            }
            return bytes;
        }
        public static int[] ceByte2Ints(string byteString)
        {
            string[] intStr = byteString.Split(' ');
            int[] ints = new int[intStr.Length];
            int c = 0;
            foreach (string b in intStr)
            {
                ints[c] = (int.Parse(b, System.Globalization.NumberStyles.HexNumber));
                c++;
            }
            return ints;
        }

        public static UInt64 baseEvaluatePointer(UInt64 offset, UInt64[] offsets)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, (UInt64)mcBaseAddress + offset, ref buffer, sizeof(UInt64), 0);
            for (int i = 0; i < offsets.Length - 1; i++)
            {
                ReadProcessMemory(mcProcHandle, (UInt64)(buffer + offsets[i]), ref buffer, sizeof(UInt64), 0);
            }
            return buffer + offsets[offsets.Length - 1];
        }
        public static UInt64 evaluatePointer(UInt64 addr, UInt64[] offsets)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, addr, ref buffer, sizeof(UInt64), 0);
            for (int i = 0; i < offsets.Length - 1; i++)
            {
                ReadProcessMemory(mcProcHandle, (UInt64)(buffer + offsets[i]), ref buffer, sizeof(UInt64), 0);
            }
            return buffer + offsets[offsets.Length - 1];
        }

        //Read base
        public static int readBaseByte(int offset)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, (UInt64)(mcBaseAddress + offset), ref buffer, sizeof(byte), 0);
            return (byte)buffer;
        }
        public static int readBaseInt(int offset)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, (UInt64)(mcBaseAddress + offset), ref buffer, sizeof(int), 0);
            return (int)buffer;
        }
        public static UInt64 readBaseInt64(int offset)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, (UInt64)(mcBaseAddress + offset), ref buffer, sizeof(Int64), 0);
            return buffer;
        }

        //Write base
        public static void writeBaseByte(int offset, byte value)
        {
            WriteProcessMemory(mcProcHandle, (mcBaseAddress + offset), ref value, sizeof(byte), 0);
        }
        public static void writeBaseInt(int offset, int value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }
        public static void writeBaseBytes(int offset, byte[] value)
        {
            int inc = 0;
            foreach (byte b in value)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }
        public static void writeBaseFloat(int offset, float value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }
        public static void writeBaseInt64(int offset, UInt64 value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }

        //Read direct
        public static byte readByte(UInt64 address)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(byte), 0);
            return (byte)buffer;
        }
        public static int readInt(UInt64 address)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(int), 0);
            return (int)buffer;
        }
        public static float readFloat(UInt64 address)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(float), 0);
            byte[] raw = BitConverter.GetBytes(buffer);
            return BitConverter.ToSingle(raw, 0);
        }
        public static UInt64 readInt64(UInt64 address)
        {
            UInt64 buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(ulong), 0);
            return buffer;
        }
        public static string readString(UInt64 address, UInt64 length)
        {
            byte[] strByte = new byte[length];
            int inc = 0;
            foreach (byte b in strByte)
            {
                byte next = readByte(address + (UInt64)inc);
                if (next == 0)
                    break;
                strByte[inc] = next;
                inc++;
            }
            return new string(Encoding.Default.GetString(strByte).Take(inc).ToArray());
        }

        //Write direct
        public static void writeByte(UInt64 address, byte value)
        {
            WriteProcessMemory(mcProcHandle, (IntPtr)address, ref value, sizeof(byte), 0);
        }
        public static void writeBytes(UInt64 address, byte[] value)
        {
            int inc = 0;
            foreach (byte b in value)
            {
                writeByte(address + (UInt64)inc, b);
                inc++;
            }
        }
        public static void writeInt(UInt64 address, int value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeByte(address + (UInt64)inc, b);
                inc++;
            }
        }
        public static void writeFloat(UInt64 address, float value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeByte(address + (UInt64)inc, b);
                inc++;
            }
        }
        public static void writeInt64(UInt64 address, UInt64 value)
        {
            byte[] intByte = BitConverter.GetBytes(value);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeByte(address + (UInt64)inc, b);
                inc++;
            }
        }
        public static void writeString(UInt64 address, string str)
        {
            byte[] intByte = Encoding.ASCII.GetBytes(str);
            int inc = 0;
            foreach (byte b in intByte)
            {
                writeByte(address + (UInt64)inc, b);
                inc++;
            }
        }
    }
}
