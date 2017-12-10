using System;

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
        }
    }
}
