using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public static class ConsoleManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(IntPtr consoleOutput, bool maximumWindow, ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFont);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        const int STD_OUTPUT_HANDLE = -11;
        const int TMPF_TRUETYPE = 4;
        const int LF_FACESIZE = 32;

        public static void blockWindowResize()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, 0xF030, 0x00000000);
                DeleteMenu(sysMenu, 0xF000, 0x00000000);
            }
        }

        public static void SetConsoleFont(int fontSizeX, int fontSizeY, int fontFamily, int fontWeight)
        {
            IntPtr consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            CONSOLE_FONT_INFO_EX fontInfo = new CONSOLE_FONT_INFO_EX();
            fontInfo.cbSize = (uint)Marshal.SizeOf(fontInfo);
            fontInfo.dwFontSize = new COORD((short)fontSizeX, (short)fontSizeY);
            fontInfo.FontFamily = fontFamily;
            fontInfo.FontWeight = fontWeight;

            SetCurrentConsoleFontEx(consoleHandle, false, ref fontInfo);
        }
    }
}
