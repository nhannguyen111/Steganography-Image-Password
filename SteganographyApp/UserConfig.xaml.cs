namespace SteganographyApp;

public partial class UserConfigPopUp : ContentPage
{
    public UserConfigPopUp()
    {
        InitializeComponent();
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        string input = NumberEntry.Text;

        // have the button do something here

        bool lowerIsChecked = LowerCaseCheckBox.IsChecked;

        bool upperIsChecked = UpperCaseCheckBox.IsChecked;

        bool numIsChecked = NumberCheckBox.IsChecked;

        bool specialIsChecked = SpecialCheckBox.IsChecked;

    }

}
