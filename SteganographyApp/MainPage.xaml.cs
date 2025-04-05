﻿


using System.Threading.Tasks;

namespace SteganographyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string password = "stop goonin";

        public MainPage()
        {
            InitializeComponent();
        }



        // Event handling the uploaded image
        private async void UploadBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Select an Image",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    using var originalStream = await result.OpenReadAsync();

                    var memoryStream = new MemoryStream();
                    await originalStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    MyImageControl.Source = ImageSource.FromStream(() => memoryStream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void CopyPassword_Clicked(object sender, EventArgs e)
        {
            

            await Clipboard.Default.SetTextAsync(password);

            await DisplayAlert("Copied", "New Passwored has been copied to clipboard! 👉👈", "OK");

        }
        // private async Task ClearClipboard() =>await Clipboard.Default.SetTextAsync(null);
    }

}
