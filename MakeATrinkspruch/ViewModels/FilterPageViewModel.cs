using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Models;
using MakeATrinkspruch.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MakeATrinkspruch.ViewModels
{
	public class FilterPageViewModel : BaseViewModel
	{
		private readonly IDataService _dataService;
		private readonly FilterState _filterState;

		public FilterPageViewModel() : base()
		{
			Title = "Filter";
			_dataService = ServiceHelper.GetService<IDataService>();
			_filterState = ServiceHelper.GetService<FilterState>();

			CloseCommand = new Command(async () => await OnCloseClicked());
			SetFilterCommand = new Command(async () => await OnSetFilter());

			Keywords = new ObservableCollection<Keywords>(_filterState.Keywords);
			SelectedKeywords = new ObservableCollection<object>(_filterState.SelectedKeywords);
		}


		public ObservableCollection<Keywords> Keywords { get; }
		public ObservableCollection<object> SelectedKeywords { get; set; }


		public ICommand CloseCommand { get; }
		public ICommand SetFilterCommand { get; }

		public async Task OnCloseClicked()
		{
			await Application.Current.MainPage.Navigation.PopModalAsync();
		}

		private async Task OnSetFilter()
		{
			List<Keywords> keywordList = SelectedKeywords.OfType<Keywords>().ToList();
			_filterState.SelectedKeywords = keywordList;
			await Application.Current.MainPage.Navigation.PopModalAsync();
		}
	}
}
