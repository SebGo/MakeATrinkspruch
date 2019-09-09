using MakeATrinkspruch.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeATrinkspruch.Data
{

    public class ToastDatabase
    {
        readonly SQLiteAsyncConnection database;

        private int totalAmount;
        Random random;


        public ToastDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Toast>().Wait();

            totalAmount = GetItemsAsync().Result.Count;
            random = new Random();
        }

        public Task<List<Toast>> GetItemsAsync()
        {
            var res = database.Table<Toast>().ToListAsync();
            return res;
        }

        public Task<Toast> GetItemAsync(int id)
        {
            var res = database.Table<Toast>().Where(i => i.Id == id).FirstOrDefaultAsync();
            return res;
        }

        public Task<int> SaveItemAsync(Toast item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<Toast> GetNewToastAsync(Toast toast)
        {
            int newId = 0;
            do
            {
                newId = random.Next(1, totalAmount);
            } while (newId == toast.Id);
            Task<Toast> res = database.Table<Toast>().Where(i => i.Id == newId).FirstOrDefaultAsync();
            return res;
        }

        public Task<int> DeleteItemAsync(Toast item)
        {
            return database.DeleteAsync(item);
        }
    }



}
