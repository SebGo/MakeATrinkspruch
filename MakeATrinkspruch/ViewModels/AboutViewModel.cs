using MakeATrinkspruch.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace MakeATrinkspruch.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; }

        public AboutViewModel()
        {
            Title = "Über Make A Trinspruch";

            BackCommand = new Command(OnBackClicked);
        }

        public async void OnBackClicked()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}