using System.Drawing;
using System.Windows.Forms;
using TransparentImage.Common;

namespace TransparentImage
{
    public partial class ScrollablePictureBox : UserControl
    {
        private Optional<Bitmap> image;
        public ScrollablePictureBox()
        {
            InitializeComponent();
            image = Optional<Bitmap>.None();
        }

        public void SetImage(Bitmap bitmap)
        {
            if (bitmap == null) return;
            image = Optional<Bitmap>.Some(bitmap);
            image.Do(img => pictureBox.Image = img);
        }

        public Optional<Bitmap> GetImage() => image;

        private void chkZoom_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkZoom.Checked)
                ZoomAndDockFill();
            else
                AutoSizeAndUndock();
        }

        public void ZoomAndDockFill()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;
        }

        public void AutoSizeAndUndock()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Dock = DockStyle.None;
        }
    }
}
