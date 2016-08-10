using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HotCorners
{
    internal static class KeyboardHelper
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;

        public static void KeyDown(Keys keys)
        {
            keybd_event((byte)keys, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        public static void KeyUp(Keys keys)
        {
            keybd_event((byte)keys, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
}
