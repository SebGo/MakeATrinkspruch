using Android.App;
using Android.Content.PM;

namespace MakeATrinkspruch.Droid;

[
    Activity(
    Icon = "@mipmap/ic_launcher",
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density
    )
]
public class MainActivity : MauiAppCompatActivity
{

}
