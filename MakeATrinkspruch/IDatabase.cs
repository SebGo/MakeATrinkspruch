using SQLite;

namespace MakeATrinkspruch
{
    public interface IDatabase
    {
        SQLiteAsyncConnection CreateConnection();
    }
}