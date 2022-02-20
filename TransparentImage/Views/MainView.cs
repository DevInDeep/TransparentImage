using System;
using System.Drawing;
using System.Windows.Forms;
using TransparentImage.Common;

namespace TransparentImage
{
    public partial class MainView : Form
    {
        private MainViewPresenter presenter;
        public MainViewPresenter Presenter
        {
            set
            {
                if (presenter == null)
                    presenter = value;
            }
        }
        public MainView()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e) => presenter.OpenImage();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => presenter.Exit();

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e) => presenter.SaveImage();

        public void SetImage(string filePath, Bitmap bitmap)
        {
            pictureBox.SetImage(bitmap);
            lblImagePath.Text = filePath;
        }

        public void SetColor(Color color) => picColor.BackColor = color;

        public void Disable() =>
            openImageToolStripMenuItem.Enabled = saveImageToolStripMenuItem.Enabled = picColor.Enabled = nTolerance.Enabled = btnTransparent.Enabled = false;
        public void Enable() =>
            openImageToolStripMenuItem.Enabled = saveImageToolStripMenuItem.Enabled = picColor.Enabled = nTolerance.Enabled = btnTransparent.Enabled = true;
        
        public int GetTolerance() => (int)nTolerance.Value;

        public Color GetColor() => picColor.BackColor;

        public Optional<Bitmap> GetImage() => pictureBox.GetImage();

        private void picColor_Click(object sender, EventArgs e) =>
            presenter.PickColor();

        private void btnTransparent_Click(object sender, EventArgs e) =>
            presenter.CreateTransparentImage();
    }
}
