using System.Windows.Forms;

namespace HotCorners
{
    internal static class CornerActions
    {
        public static HotCornerAction StartMenuAction => OpenStartMenu;
        public static HotCornerAction MissionControlAction => OpenMissionControl;

        private static void OpenStartMenu(HotCorner corner, Screen screen)
        {
            // get the start button's location on the screen and press the left mouse button there.
            var startButtonLocation = TaskbarHelper.GetStartButtonLocation(screen);
            MouseHelper.PressMouseButton(MouseButton.Left, startButtonLocation);
        }

        private static void OpenMissionControl(HotCorner corner, Screen screen)
        {
            // hold down Windows, then tab, then release tab, then Windows.
            // this results in the Win+Tab key combo.
            KeyboardHelper.KeyDown(Keys.LWin);
            KeyboardHelper.KeyDown(Keys.Tab);
            KeyboardHelper.KeyUp(Keys.Tab);
            KeyboardHelper.KeyUp(Keys.LWin);
        }
    }
}
