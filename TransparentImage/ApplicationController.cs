using System;
using System.Drawing;
using System.Windows.Forms;
using TransparentImage.Common;

namespace TransparentImage
{
    public class ApplicationController
    {
        private MainView mainView;
        public void RunApplication()
        {
            mainView = new MainView();
            var mainViewPresenter = new MainViewPresenter(mainView, this);
            Application.Run(mainView);
        }

        public void ShowOpenImageFileDialog(Action<string, Bitmap> setImage) =>
            new OpenFileDialog().OpenImage(setImage);

        public void ShowSaveImageFileDialog(Action<string> action) =>
            new SaveFileDialog().SaveImage(action);

        public void Exit() => mainView.Close();

        public void ShowColorPicker(Action<Color> setColor) =>
            new ColorDialog().PickColor(setColor);

        public void ShowError(string message) =>
            MessageBox.Show(message, "Transparent Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
