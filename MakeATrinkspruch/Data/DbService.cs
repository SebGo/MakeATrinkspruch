using MakeATrinkspruch.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MakeATrinkspruch.Data
{
    public class DbService
    {
        private readonly SQLiteAsyncConnection dbConnection;

        private int totalAmount;
        private Random random;

        public DbService()
        {
            dbConnection = DependencyService.Get<IDatabase>().CreateConnection();
            dbConnection.CreateTableAsync<Toast>().Wait();

            totalAmount = GetItemsAsync().Result.Count;
            random = new Random();
        }

        public Task<List<Toast>> GetItemsAsync()
        {
            var res = dbConnection.Table<Toast>().ToListAsync();
            return res;
        }

        public Task<Toast> GetItemAsync(int id)
        {
            var res = dbConnection.Table<Toast>().Where(i => i.Id == id).FirstOrDefaultAsync();
            return res;
        }

        public Task<int> SaveItemAsync(Toast item)
        {
            if (item.Id != 0)
            {
                return dbConnection.UpdateAsync(item);
            }
            else
            {
                return dbConnection.InsertAsync(item);
            }
        }

        public Task<Toast> GetNewToastAsync(Toast toast)
        {
            int newId = 0;
            do
            {
                newId = random.Next(1, totalAmount);
            } while (newId == toast.Id);
            Task<Toast> res = dbConnection.Table<Toast>().Where(i => i.Id == newId).FirstOrDefaultAsync();
            return res;
        }

        public Task<int> DeleteItemAsync(Toast item)
        {
            return dbConnection.DeleteAsync(item);
        }
    }
}