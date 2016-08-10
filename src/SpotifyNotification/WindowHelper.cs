using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpotifyNotification
{
    internal static class WindowHelper
    {
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void BringToFront(Process p)
        {
            var handle = p.MainWindowHandle;
            SetForegroundWindow(handle);
        }
    }
}
