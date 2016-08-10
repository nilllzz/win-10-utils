using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotCorners
{
    internal delegate void HotCornerAction(HotCorner corner, Screen screen);

    internal class HotCorner
    {
        // size of a corner rectangle in pixels
        private const int SIZE = 4;

        private readonly ScreenCorner _corner;
        private readonly HotCornerAction _command;

        public HotCorner(ScreenCorner corner, HotCornerAction command)
        {
            _corner = corner;
            _command = command;
        }

        private static Point GetPointFromScreenCorner(Screen screen, ScreenCorner corner)
        {
            switch (corner)
            {
                case ScreenCorner.TopLeft:
                    return new Point(screen.Bounds.X, screen.Bounds.Y);
                case ScreenCorner.TopRight:
                    return new Point(screen.Bounds.Right, screen.Bounds.Y);
                case ScreenCorner.BottomLeft:
                    return new Point(screen.Bounds.X, screen.Bounds.Bottom);
                case ScreenCorner.BottomRight:
                    return new Point(screen.Bounds.Right, screen.Bounds.Bottom);
            }

            return Point.Empty;
        }

        private Rectangle ComposeRectangle(Screen screen)
        {
            var position = GetPointFromScreenCorner(screen, _corner);

            var rect = new Rectangle()
            {
                X = position.X,
                Y = position.Y,
                Width = SIZE,
                Height = SIZE
            };

            if (_corner == ScreenCorner.BottomLeft || _corner == ScreenCorner.BottomRight)
                rect.Y -= SIZE;
            if (_corner == ScreenCorner.TopRight || _corner == ScreenCorner.BottomRight)
                rect.X -= SIZE;

            return rect;
        }

        public HotCornerTestResult ContainsCursor(Point cursorPosition)
        {
            var screen = Screen.AllScreens.FirstOrDefault(s => ComposeRectangle(s).Contains(cursorPosition));

            return new HotCornerTestResult()
            {
                Success = screen != null,
                Corner = this,
                Screen = screen
            };
        }

        public void Execute(Screen screen) => _command(this, screen);
    }
}
