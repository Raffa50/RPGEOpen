using RpgeOpen.Models;

namespace RpgeOpen.IDE.Extensions
{
    public static class SizeExtensions
    {
        public static System.Drawing.Rectangle GetTileCell(this Size s, int x, int y)
        {
            return new System.Drawing.Rectangle(x * s.Width, y * s.Height, s.Width, s.Height);
        }
    }
}
