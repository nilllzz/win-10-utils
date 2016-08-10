using System.Drawing;
using System.Windows.Forms;

namespace HotCorners
{
    internal static class TaskbarHelper
    {
        private enum TaskbarLocation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private static TaskbarLocation GetTaskbarLocation(Screen screen)
        {
            var taskbarLocation = TaskbarLocation.Bottom;

            if (screen.WorkingArea.Width == screen.Bounds.Width)
            {
                if (screen.WorkingArea.Top > 0)
                    taskbarLocation = TaskbarLocation.Top;
            }
            else
            {
                if (screen.WorkingArea.Left > 0)
                    taskbarLocation = TaskbarLocation.Left;
                else
                    taskbarLocation = TaskbarLocation.Right;
            }
            return taskbarLocation;
        }

        public static Point GetStartButtonLocation(Screen screen)
        {
            var taskbarLocation = GetTaskbarLocation(screen);

            switch (taskbarLocation)
            {
                case TaskbarLocation.Bottom:
                    return new Point(screen.Bounds.X, screen.Bounds.Bottom);
                case TaskbarLocation.Right:
                    return new Point(screen.Bounds.Right, screen.Bounds.Y);
                case TaskbarLocation.Top:
                case TaskbarLocation.Left:
                default:
                    return new Point(screen.Bounds.X, screen.Bounds.Y);
            }
        }
    }
}
