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

        private void OnOpenUserConfigWindowClicked(object sender, EventArgs e)
        {
            var UserConfigPopUp = new UserConfigPopUp();

            var newWindow = new Window(UserConfigPopUp);
            Application.Current.OpenWindow(newWindow);
        }

    }

}
