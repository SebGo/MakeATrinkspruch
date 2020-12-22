using MakeATrinkspruch.ViewModels;

using Xamarin.Forms;

namespace MakeATrinkspruch.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }
    }
}