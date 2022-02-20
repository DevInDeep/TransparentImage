using System;
using System.Drawing;
using System.Windows.Forms;

namespace TransparentImage.Common
{
    public static class FileDialogExtensions
    {
        public static void OpenImage(this OpenFileDialog ofd, Action<string,Bitmap> onSelectedImage)
        {
            ofd.Title = "Open Image";
            ofd.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.bmp; *.tiff;";
            if (ofd.ShowDialog() == DialogResult.OK)
                onSelectedImage(ofd.FileName, new Bitmap(ofd.FileName));
        }

        public static void SaveImage(this SaveFileDialog sfd, Action<string> onFilePathSelected)
        {
            sfd.Title = "Save Image";
            sfd.Filter = "PNG File | *.png;";
            if (sfd.ShowDialog() == DialogResult.OK)
                onFilePathSelected(sfd.FileName);
        }
    }
}
