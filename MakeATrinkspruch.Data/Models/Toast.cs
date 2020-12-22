using SQLite;
using System.Collections.Generic;

namespace MakeATrinkspruch.Data.Models
{
    public class Toast
    {
        [PrimaryKey, AutoIncrement, Unique]
        public long Id { get; set; }

        [Unique]
        public string ToastText { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}