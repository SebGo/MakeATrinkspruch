using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;

namespace MakeATrinkspruch.Droid
{
    [Activity(Theme = "@style/MakeATrinkspruchTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            //Task startupWork = new Task(() => { SimulateStartup(); });
            //startupWork.Start();
        }
    }
}