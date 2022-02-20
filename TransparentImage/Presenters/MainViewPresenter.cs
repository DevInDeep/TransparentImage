using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using TransparentImage.Common;

namespace TransparentImage
{
    public class MainViewPresenter
    {
        private readonly ApplicationController applicationController;
        private readonly MainView view;

        public MainViewPresenter(MainView view, ApplicationController applicationController)
        {
            this.applicationController = applicationController;
            this.view = view;
            this.view.Presenter = this;
        }

        public void OpenImage() =>
            applicationController.ShowOpenImageFileDialog(view.SetImage);

        public void Exit() => applicationController.Exit();

        public void SaveImage() =>
            view.GetImage()
            .Do(image => applicationController.ShowSaveImageFileDialog(filePath=>image.Save(filePath, ImageFormat.Png)));

        public void PickColor() =>
            applicationController.ShowColorPicker(view.SetColor);

        public void CreateTransparentImage() =>
            view.GetImage()
            .Do(async image =>
            {
                view.Disable();
                await TryCreateTransparentImage(image);
                view.Enable();
            });

        private async Task TryCreateTransparentImage(Bitmap image)
        {
            try
            {
                view.SetImage(string.Empty, await image.TransparentAsync(view.GetColor(), view.GetTolerance()));
            }
            catch (Exception ex)
            {
                applicationController.ShowError(ex.Message);
            }
        }
    }
}
