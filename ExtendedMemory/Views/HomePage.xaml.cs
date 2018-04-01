using Xamarin.Forms;

namespace ExtendedMemory.Views
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            Children.Add(new SavePage());
            Children.Add(new SearchPage());
            InitializeComponent();
        }
    }
}
