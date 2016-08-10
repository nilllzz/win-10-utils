using System;
using System.Runtime.InteropServices;

namespace HotCorners
{
    internal static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_HIDE=0;

        public static void HideConsoleWindow()
        {
            ShowWindow(GetConsoleWindow(), SW_HIDE);
        } 
    }
}
