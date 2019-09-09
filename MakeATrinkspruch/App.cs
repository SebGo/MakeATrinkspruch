using MakeATrinkspruch.Data;
using MakeATrinkspruch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MakeATrinkspruch
{
    public class App : Application
    {
        static ToastDatabase database;
        public static ToastDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ToastDatabase(FilePath);
                }
                return database;
            }
        }

        public static string FilePath;

        //public App()
        //{
        //    Resources = new ResourceDictionary();
        //    Resources.Add("primaryGreen", Color.FromHex("91CA47"));
        //    Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

        //    var nav = new NavigationPage(new ToastPage());
        //    nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
        //    nav.BarTextColor = Color.White;

        //    MainPage = nav;
        //}


        public App(string filePath)
        {
            FilePath = filePath;

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("#668000"));
            Resources.Add("primaryDarkGreen", Color.FromHex("#475900"));

            var nav = new NavigationPage(new ToastPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

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

