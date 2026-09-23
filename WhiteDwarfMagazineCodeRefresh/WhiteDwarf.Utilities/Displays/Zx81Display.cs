using WhiteDwarf.Utilities.Interfaces;

namespace WhiteDwarf.Utilities.Displays
{
    public class Zx81Display : IScreen
    {
        public int Width { get { return 32; } }
        public int Height { get { return 24; } }
    }
}
