using MakeATrinkspruch.Data;
using MakeATrinkspruch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MakeATrinkspruch
{
    public class App : Application
    {
        private static DbService database;

        public static DbService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DbService();
                }
                return database;
            }
        }

        public App()
        {
            var nav = new NavigationPage(new ToastPage());
            MainPage = nav;
        }

        public int ResumeAtMakeATrinkspruchId { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}