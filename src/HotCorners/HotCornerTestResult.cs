using System.Windows.Forms;

namespace HotCorners
{
    internal struct HotCornerTestResult
    {
        public bool Success { get; set; }
        public HotCorner Corner { get; set; }
        public Screen Screen { get; set; }
    }
}
