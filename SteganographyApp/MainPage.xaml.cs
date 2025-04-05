


using System.Threading.Tasks;

namespace SteganographyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
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

        private void CopyPassword_Clicked(object sender, EventArgs e)
        {
            //TODO: Copy new password to clipboard

        }
    }

}
