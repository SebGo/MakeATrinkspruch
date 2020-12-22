using MakeATrinkspruch.Data;

namespace MakeATrinkspruch
{
    public interface IDatabase
    {
        MakeATrinkspruchDbContext CreateConnection();
    }
}