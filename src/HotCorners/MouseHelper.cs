using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HotCorners
{
    internal static class MouseHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void PressMouseButton(MouseButton button, Point position)
        {
            var currentPos = Cursor.Position;
            SetCursorPos(position.X, position.Y);

            if (button == MouseButton.Left)
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)position.X, (uint)position.Y, 0, 0);
            else
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)position.X, (uint)position.Y, 0, 0);

            SetCursorPos(currentPos.X, currentPos.Y);
        }
    }

    internal enum MouseButton
    {
        Left,
        Right
    }
}
