using MakeATrinkspruch.Data;
using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Models;
using MakeATrinkspruch.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataService))]

namespace MakeATrinkspruch.Services
{
    public class DataService : IDataService
    {
        private readonly MakeATrinkspruchDbContext dbContext;
        private readonly Random random;
        private int totalAmount;

        public DataService()
        {
            dbContext = DependencyService.Get<IDatabase>().CreateConnection();
            random = new Random();
            totalAmount = 0;
        }

        public async Task<Toast> GetAFilteredToast(IEnumerable<Keyword> keywordFilter)
        {
            if (keywordFilter != null && keywordFilter.Count() > 0)
            {
                IQueryable<Toast> res1 = dbContext.ToastKeywords.Where(tk => keywordFilter.Contains(tk.Keyword)).Select(tk => tk.Toast);
                int index = random.Next(0, res1.Count());
                List<Toast> toasts = await res1.ToListAsync();

                return toasts.ElementAt(index);
            }
            else
            {
                return await GetRandomToast();
            }
        }

        public async Task<IEnumerable<Keyword>> GetAllKeywords()
        {
            return await dbContext.Keywords.ToListAsync();
        }

        public async Task<int> GetAmountOfToasts()
        {
            return await dbContext.Toasts.CountAsync(); // Table<Toast>().CountAsync();
        }

        public async Task<Toast> GetRandomToast()
        {
            if (totalAmount == 0)
            {
                totalAmount = await GetAmountOfToasts();
            }

            int newId = random.Next(1, totalAmount);
            Toast toast = dbContext.Toasts.Where(i => i.Id == newId).FirstOrDefault();
            return toast;
        }
    }
}