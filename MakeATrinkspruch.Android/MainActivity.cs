using Android.App;
using Android.Content.PM;
using Android.OS;
using MakeATrinkspruch.MakeATrinkspruch;
using System.IO;

namespace MakeATrinkspruch
{
    [Activity(Label = "MakeATrinkspruch", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            string fileName = "MakeAToast.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completePath = Path.Combine(folderPath, fileName);


            var db = new DBHelper(this, folderPath, fileName);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);


            LoadApplication(new App(completePath));
        }
    }
}
