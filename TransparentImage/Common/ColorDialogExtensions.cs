using System;
using System.Drawing;
using System.Windows.Forms;

namespace TransparentImage.Common
{
    public static class ColorDialogExtensions
    {
        public static void PickColor(this ColorDialog colorDialog, Action<Color> onColorPicked)
        {
            colorDialog.Color = Color.White;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                onColorPicked(colorDialog.Color);
        }
    }
}
