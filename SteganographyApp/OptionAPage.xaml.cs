using System;
using System.IO;                       // ← for MemoryStream
using System.Threading.Tasks;
using Microsoft.Maui.Controls;         // ← for ImageSource
using Microsoft.Maui.Storage;          // ← for FilePicker
using SteganographyApp.ImageToMetaData;
using SteganographyApp.PasswordGenerator;

namespace SteganographyApp
{
    public partial class OptionAPage : ContentPage
    {
        // you can replace this with your real password logic later
        string password = "test";
        string metadata = "";

        public OptionAPage()
        {
            InitializeComponent();
        }

        // Fired when user taps the image
        private async void UploadBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Select an Image",
                    FileTypes = FilePickerFileType.Images
                });

                if (result == null)
                    return;

                string data = ConvertImage.DataDump(result.FullPath);
                metadata = Parser.GetReadableData(data);

                // 1) Load the file into a MemoryStream
                using var originalStream = await result.OpenReadAsync();
                var memoryStream = new MemoryStream();
                await originalStream.CopyToAsync(memoryStream);

                // 2) Reset to start before MAUI reads it
                memoryStream.Position = 0;

                // 3) Swap out the placeholder for the chosen image
                MyImageControl.Source = ImageSource.FromStream(() =>
                {
                    // if MAUI re-reads the stream, ensure it's at 0
                    memoryStream.Position = 0;
                    return memoryStream;
                });

                // — optional: if you want to extract metadata now —
                // var converter = new ConvertImage();
                // string data = converter.DataDump(result.FullPath);
                // MetadataLabel.Text = data;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void CopyPassword_Clicked(object sender, EventArgs e)
        {
            await Clipboard.Default.SetTextAsync(UserPassword.Text);
            await DisplayAlert("Copied", "New Password has been copied to clipboard! 👉👈", "OK");
        }

        private void CreatePassword_Clicked(object sender, EventArgs e)
        {
            UserPassword.Text = PasswordCreator.getKey(metadata, UserConfigPopUp.passwordSize);
        }
    }
}