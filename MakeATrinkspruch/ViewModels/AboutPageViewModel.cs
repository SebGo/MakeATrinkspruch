using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Services;
using System.Windows.Input;

namespace MakeATrinkspruch.ViewModels
{
	public class AboutPageViewModel : BaseViewModel
	{
		private readonly INavigationService _navigationService;

		public AboutPageViewModel() : base()
		{
			Title = "Über Make A Trinspruch";

			BackCommand = new Command(OnBackClicked);
			_navigationService = ServiceHelper.GetService<INavigationService>(); ;
		}

		public ICommand BackCommand { get; }

		public async void OnBackClicked()
		{
			await Application.Current.MainPage.Navigation.PopToRootAsync();
		}
	}
}
