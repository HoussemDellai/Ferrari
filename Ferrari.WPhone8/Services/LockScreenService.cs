using System;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Windows.Phone.System.UserProfile;
using Ferrari.Contracts;

namespace Ferrari.Services
{
    public class LockScreenService : ILockScreenService
    {
        #region ILockScreenService Members

        public async void TrySetImageAsLockScreenBackground(string imageUrl)
        {
            try
            {
                if (!LockScreenManager.IsProvidedByCurrentApplication)
                {
                    await LockScreenManager.RequestAccessAsync();
                }

                if (LockScreenManager.IsProvidedByCurrentApplication)
                {
                    StartDownloadImagefromServer(imageUrl);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred, please try again!");
            }
        }

        #endregion

        private void StartDownloadImagefromServer(string imageUrl)
        {
            var client = new WebClient();
            client.OpenReadCompleted -= client_OpenReadCompleted;
            client.OpenReadCompleted += client_OpenReadCompleted;

            client.OpenReadAsync(new Uri(imageUrl, UriKind.Absolute));
        }

        private void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var bitmap = new BitmapImage();
            bitmap.SetSource(e.Result);

            String tempJPEG = "MyWallpaper1.jpg";

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }

                var fileStream = myIsolatedStorage.CreateFile(tempJPEG);

                var uri = new Uri(tempJPEG, UriKind.Relative);
                Application.GetResourceStream(uri);

                var wb = new WriteableBitmap(bitmap);

                wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 90);

                fileStream.Close();
            }

            LockScreenChange(tempJPEG);
        }

        private async void LockScreenChange(string filePathOfTheImage)
        {
            if (!LockScreenManager.IsProvidedByCurrentApplication)
            {
                await LockScreenManager.RequestAccessAsync();
            }

            if (LockScreenManager.IsProvidedByCurrentApplication)
            {
                var schema = "ms-appdata:///Local/";
                var uri = new Uri(schema + filePathOfTheImage, UriKind.Absolute);

                LockScreen.SetImageUri(uri);

                MessageBox.Show("Success !", "LockScreen changed", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Background cant be changed. Please check your permissions to this application.");
            }
        }
    }
}