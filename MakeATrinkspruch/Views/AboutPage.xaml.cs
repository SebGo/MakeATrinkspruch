using MakeATrinkspruch.Services;
using MakeATrinkspruch.ViewModels;

namespace MakeATrinkspruch.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
		BindingContext = ServiceHelper.GetService<AboutPageViewModel>();
		;
	}
}