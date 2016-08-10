using System;
using System.Linq;
using System.Windows.Forms;

namespace HotCorners
{
    internal class HotCornerController
    {
        private HotCorner[] _corners;
        private bool _isMouseInHotCorner = false;

        public void Run()
        {
            InitializeCorners();
            WorkerHelper.StartNew(Update, 10);
        }

        private void Update()
        {
            var pos = Cursor.Position;
            var cornerTestResult = _corners.Select(c => c.ContainsCursor(pos)).FirstOrDefault(r => r.Success);

            Console.WriteLine("Success: " + cornerTestResult.Success);

            if (!_isMouseInHotCorner && cornerTestResult.Success)
            {
                Console.WriteLine("In corner: " + _isMouseInHotCorner.ToString());

                _isMouseInHotCorner = true;
                cornerTestResult.Corner.Execute(cornerTestResult.Screen);
            }
            else if (_isMouseInHotCorner && !cornerTestResult.Success)
                _isMouseInHotCorner = false;
        }

        private void InitializeCorners()
        {
            _corners = new[]
            {
                new HotCorner(ScreenCorner.TopLeft, CornerActions.StartMenuAction),
                new HotCorner(ScreenCorner.TopRight, CornerActions.MissionControlAction)
            };
        }
    }
}
