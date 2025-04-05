using SteganographyApp.ImageToMetaData;
using System.Diagnostics;

namespace SteganographyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            ConvertImage convertImage = new ConvertImage();
            string data = convertImage.DataDump(@"C:\Users\justi\Downloads\Ocean.gif");
            //foreach (char x in data.ToCharArray()) {
            //    Debug.WriteLine();
            //}
            
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
    }

}
