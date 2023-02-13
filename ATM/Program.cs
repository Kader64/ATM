using System.Runtime.InteropServices;

[DllImport("user32.dll")]
static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

[DllImport("user32.dll")]
static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

[DllImport("kernel32.dll", ExactSpelling = true)]
static extern IntPtr GetConsoleWindow();

IntPtr window = GetConsoleWindow();
IntPtr sysMenu = GetSystemMenu(window, false);
if (window != IntPtr.Zero)
{
    DeleteMenu(sysMenu, 0xF030, 0x00000000);
    DeleteMenu(sysMenu, 0xF000, 0x00000000);
}
