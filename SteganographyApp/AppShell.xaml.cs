namespace SteganographyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OptionAPage), typeof(OptionAPage));
            Routing.RegisterRoute(nameof(OptionBPage), typeof(OptionBPage));
            Routing.RegisterRoute(nameof(UserConfigPopUp), typeof(UserConfigPopUp));
        }
    }
}
