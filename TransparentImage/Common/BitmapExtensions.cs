using System;
using System.Drawing;
using System.Threading.Tasks;

namespace TransparentImage.Common
{
    public static class BitmapExtensions
    {
        public static Task<Bitmap> TransparentAsync(this Bitmap image, Color color, int tolerance) =>
            Task.Run(()=>image.Transparent(color,tolerance));
        public static Bitmap Transparent(this Bitmap image, Color color, int tolerance)
        {
            Bitmap b = new Bitmap(image);

            b.ForEachPixel((i,j,col) => {
                if (col.IsCloseTo(color, tolerance))
                    b.SetPixel(i, j, color);
            });

            b.MakeTransparent(color);

            return b;
        }

        public static void ForEachPixel(this Bitmap image, Action<int,int,Color> onPixel)
        {
            for (int i = image.Size.Width - 1; i >= 0; i--)
            {
                for (int j = image.Size.Height - 1; j >= 0; j--)
                {
                    onPixel(i,j,image.GetPixel(i, j));
                }
            }
        }
    }
}
