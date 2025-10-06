using MakeATrinkspruch.Services;
using MakeATrinkspruch.ViewModels;

namespace MakeATrinkspruch.Views;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _mainPageViewModel;

	public MainPage()
	{
		InitializeComponent();
		this._mainPageViewModel = ServiceHelper.GetService<MainPageViewModel>();
		BindingContext = _mainPageViewModel;
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();
		_mainPageViewModel.GetRandomToastCommand.Execute(null);
	}
}

