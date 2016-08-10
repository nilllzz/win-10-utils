using System;

namespace HotCorners
{
    internal class Program
    {
        private static HotCornerController _controller;

        static void Main(string[] args)
        {
            WindowHelper.HideConsoleWindow();

            _controller = new HotCornerController();
            _controller.Run();

            // dirty trick to keep the console from closing:
            Console.ReadLine();
        }
    }
}
