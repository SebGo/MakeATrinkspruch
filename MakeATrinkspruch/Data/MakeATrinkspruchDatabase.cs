using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Models;
using SQLite;

namespace MakeATrinkspruch.Data
{
	public class MakeATrinkspruchDatabase : IDataService
	{
		private readonly Random random;
		SQLiteAsyncConnection Database;
		private int totalAmount;
		public MakeATrinkspruchDatabase()
		{
			random = new Random();
			totalAmount = 0;
		}

		public async Task<Toasts> GetAFilteredToast(IEnumerable<long> keywordFilter)
		{
			await Init();

			if (keywordFilter != null && keywordFilter.Count() > 0)
			{
				string keywordIdsString = string.Join(", ", keywordFilter);

				string query = $@"
					SELECT * FROM Toasts t 
					JOIN ToastKeywords tk ON t.Id = tk.ToastId 
					Where tk.KeywordId in ({keywordIdsString})";
				List<Toasts> toasts =  await  Database.QueryAsync<Toasts>(query);
				int index = random.Next(0, toasts.Count());
				return toasts.ElementAt(index);
			}
			else
			{
				return await GetRandomToast();
			}
		}

		public async Task<IEnumerable<Keywords>> GetAllKeywords()
		{
			await Init();

			return await Database.Table<Keywords>().ToListAsync();
		}

		public async Task<int> GetAmountOfToasts()
		{
			try
			{
				await Init();
				return await Database.Table<Toasts>().CountAsync();
			}
			catch (Exception e)
			{

				throw;
			}
		}

		public async Task<Toasts> GetRandomToast()
		{
			try
			{
				await Init();

				if (totalAmount == 0)
				{
					totalAmount = await GetAmountOfToasts();
				}

				int newId = random.Next(1, totalAmount);
				Toasts? toast = await Database.Table<Toasts>().Where(i => i.Id == newId).FirstOrDefaultAsync();
				return toast;
			}
			catch (Exception e)
			{

				throw;
			}
		}

		private async Task CopyDatabaseAsync()
		{
			try
			{
				// Check if database file exists in local storage
				if (!File.Exists(DatabaseHelper.dbPath))
				{
					using var resourceStream = await FileSystem.OpenAppPackageFileAsync(DatabaseHelper.dbName);
					using FileStream fileStream = new FileStream(DatabaseHelper.dbPath, FileMode.Create, FileAccess.Write);
					await resourceStream.CopyToAsync(fileStream);
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		private async Task Init()
		{
			if (Database is not null)
			{
				return;
			}

			await CopyDatabaseAsync();
			Database = new SQLiteAsyncConnection(DatabaseHelper.dbPath, DatabaseHelper.Flags);
		}
	}
}
