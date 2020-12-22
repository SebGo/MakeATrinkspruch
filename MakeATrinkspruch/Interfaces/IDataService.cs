using MakeATrinkspruch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeATrinkspruch.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Keyword>> GetAllKeywords();

        Task<Toast> GetRandomToast();

        Task<Toast> GetAFilteredToast(IEnumerable<Keyword> KeywordFilter);
    }
}