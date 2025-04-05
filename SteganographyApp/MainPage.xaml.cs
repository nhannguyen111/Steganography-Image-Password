namespace SteganographyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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

    }

}
