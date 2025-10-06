namespace MakeATrinkspruch.Data
{
	public class DatabaseHelper
	{
		public static readonly string dbName = "MakeATrinkspruch.db3";

		public static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);

		public const SQLite.SQLiteOpenFlags Flags =
			 // open the database in read/write mode
			 SQLite.SQLiteOpenFlags.ReadOnly |
			 // create the database if it doesn't exist
			 // enable multi-threaded database access
			 SQLite.SQLiteOpenFlags.SharedCache;

	}
}
