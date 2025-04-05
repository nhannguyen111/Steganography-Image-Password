using SteganographyApp.ImageToMetaData;
using System.Diagnostics;
﻿using System.Threading.Tasks;

namespace SteganographyApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            ConvertImage convertImage = new ConvertImage();
            //string data = convertImage.DataDump(@"C:\Users\justi\Downloads\Ocean.gif");
            //foreach (char x in data.ToCharArray()) {
            //    Debug.WriteLine();
            //}
            
        }

        private void OnOpenUserConfigWindowClicked(object sender, EventArgs e)
        {
            var UserConfigPopUp = new UserConfigPopUp();

            // Set preferred size (Windows/macOS only)
            var newWindow = new Window(UserConfigPopUp)
            {
                Width = 500,
                Height = 600
            };

            Application.Current.OpenWindow(newWindow);
        }
        private async void OnOptionAClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OptionAPage));
        }

        private async void OnOptionBClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OptionBPage));
        }



        
        // private async Task ClearClipboard() =>await Clipboard.Default.SetTextAsync(null);
    }

}
