using System;
using System.Collections.Generic;
using System.Threading;

namespace HotCorners
{
    internal static class WorkerHelper
    {
        // keep the timers in a list to not have them garbage collected.
        private static List<Timer> _timers = new List<Timer>();

        public static void StartNew(Action callback, int step) =>
            _timers.Add(new Timer(o => callback(), null, 0, step));
    }
}
