using System;
using System.IO;
using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            lblDisplay.Text = txtEntry.Text;

            // /Users/rohit/Library/Developer/CoreSimulator/Devices/45163EF8-B7EB-4321-877C-F8CAA9B5D484/data/Containers/Data/Application/77BFD79E-8A35-436C-B8F2-1E5CB1D047B1/Documents
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "out.txt");
            File.AppendAllText(filePath, $"{txtEntry.Text}#{DateTime.Now}#\n");

            //testing start
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
            //testing end
        }
    }
}
