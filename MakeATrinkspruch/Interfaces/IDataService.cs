using MakeATrinkspruch.Data;
using MakeATrinkspruch.Models;

namespace MakeATrinkspruch.Interfaces
{
	public interface IDataService
	{
		Task<IEnumerable<Keywords>> GetAllKeywords();

		Task<Toasts> GetRandomToast();

		Task<Toasts> GetAFilteredToast(IEnumerable<long> KeywordFilter);
	}
}
