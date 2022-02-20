using System;
using System.Drawing;

namespace TransparentImage.Common
{
    public static class ColorExtensions
    {
        public static bool IsCloseTo(this Color color, Color anotherColor, int tolerance)
        {
            return Math.Abs(color.R - anotherColor.R) < tolerance &&
                   Math.Abs(color.G - anotherColor.G) < tolerance &&
                   Math.Abs(color.B - anotherColor.B) < tolerance;
        }
    }
}
