using MakeATrinkspruch.Models;
using MakeATrinkspruch.Services;
using MakeATrinkspruch.ViewModels;

namespace MakeATrinkspruch.Views;

public partial class FilterPage : ContentPage
{
	private readonly FilterPageViewModel _viewModel;

	public FilterPage()
	{
		InitializeComponent();
		_viewModel = ServiceHelper.GetService<FilterPageViewModel>();
		BindingContext = _viewModel;
	}

	//public void OnSelectionChanged(Object sender, SelectionChangedEventArgs e)
	//{
	//	Console.WriteLine("Selection changed click");
	//	var kewords = e.CurrentSelection as List<Keywords>;
	//	if (kewords != null)
	//	{
	//		_viewModel.Keywords = kewords;
	//	}
	//}

}