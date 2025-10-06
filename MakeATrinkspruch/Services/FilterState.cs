using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Models;

namespace MakeATrinkspruch.Services
{
	public class FilterState
	{
		public List<Keywords> Keywords { get; private set; }
		public List<Keywords> SelectedKeywords { get; set; }

		public List<long> SelectedKeywordIds { get { return SelectedKeywords.Select(k => k.Id).ToList(); } }

		private IDataService dataService;

		public FilterState()
		{
			Keywords = new List<Keywords>();
			SelectedKeywords = new List<Keywords>();
			dataService = ServiceHelper.GetService<IDataService>();
			Task.Run(LoadKeywords).Wait();

		}

		public async Task LoadKeywords()
		{
			Keywords = (List<Keywords>)await dataService.GetAllKeywords();
		}
	}
}
