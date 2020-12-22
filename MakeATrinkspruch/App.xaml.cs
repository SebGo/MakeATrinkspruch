using MakeATrinkspruch.Data;
using MakeATrinkspruch.Services;
using MakeATrinkspruch.Views;

using Xamarin.Forms;

namespace MakeATrinkspruch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<DataService>();

            MainPage = new NavigationPage(new ToastPage());
        }

        //public int ResumeAtMakeATrinkspruchId { get; set; }
    }
}