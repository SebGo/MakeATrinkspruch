using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Models;
using MakeATrinkspruch.Services;
using MakeATrinkspruch.Views;
using System.Windows.Input;

namespace MakeATrinkspruch.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		private readonly FilterState _filterState;
		private readonly INavigationService _navigationService;
		private IDataService _dataService;

		private CancellationTokenSource cts;
		private Toasts? currentToast;

		public MainPageViewModel() : base()
		{
			this._dataService = ServiceHelper.GetService<IDataService>();
			this._navigationService = ServiceHelper.GetService<INavigationService>();
			this._filterState = ServiceHelper.GetService<FilterState>();

			Title = "Make A Trinkspruch";

			SwipeCommand = new Command<string>(async (string swipeDirection) => await OnSwipeAsync(swipeDirection));
			ReadCommand = new Command(async () => await OnReadClicked());
			FilterCommand = new Command(async () => await OnFilterClicked());
			AboutCommand = new Command(async () => await OnAbout());
			GetRandomToastCommand = new Command(async () => await OnGetRandomToast());
		}

		public ICommand AboutCommand { get; }
		public ICommand BuyABeerCommand { get; }
		public Toasts? CurrentToast
		{
			get => currentToast;
			set
			{
				if (currentToast != value)
				{
					currentToast = value;
					OnPropertyChanged(); // reports this property
				}
			}
		}

		public ICommand FilterCommand { get; }
		public ICommand GetRandomToastCommand { get; }
		public IEnumerable<Keywords> Keywords { get; private set; }
		public ICommand LoadKeywordsCommand { get; }
		public ICommand ReadCommand { get; }
		public ICommand SwipeCommand { get; }
		public void CancelSpeech()
		{
			if (cts?.IsCancellationRequested ?? true)
			{
				return;
			}

			cts.Cancel();
		}

		private async Task OnAbout()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());
		}

		private async Task OnFilterClicked()
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(new FilterPage());
		}

		private async Task OnGetRandomToast()
		{

			if (_filterState.SelectedKeywords.Count == 0)
			{
				CurrentToast = await _dataService.GetRandomToast();
			}
			else
			{
				CurrentToast = await _dataService.GetAFilteredToast(_filterState.SelectedKeywordIds);
			}
		}



		private async Task OnReadClicked()
		{
			if (CurrentToast != null)
			{
				cts = new CancellationTokenSource();
				await TextToSpeech.Default.SpeakAsync(CurrentToast.ToastText, cancelToken: cts.Token);
			}
		}
		private async Task OnSwipeAsync(string swipeDirection)
		{
			if (swipeDirection.Equals("Left"))
			{
				CancelSpeech();
				CurrentToast = await _dataService.GetAFilteredToast(_filterState.SelectedKeywordIds);
			}
		}
	}
}
