using SQLite;

namespace MakeATrinkspruch.Models
{
    public class Toast
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [Unique]
        public string ToastText { get; set; }

    }
}
