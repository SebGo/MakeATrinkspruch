using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeATrinkspruch.Data.Models
{
    public class Keyword
    {
        [PrimaryKey, AutoIncrement, Unique]
        public long Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public List<Toast> Toasts { get; set; }
    }
}