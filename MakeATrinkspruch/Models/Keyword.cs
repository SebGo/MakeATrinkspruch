using System.Collections.Generic;

namespace MakeATrinkspruch.Models
{
    public class Keyword
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<ToastKeyword> ToastKeywords { get; set; }
    }
}