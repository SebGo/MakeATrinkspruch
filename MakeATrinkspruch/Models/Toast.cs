﻿using System.Collections.Generic;

namespace MakeATrinkspruch.Models
{
    public class Toast
    {
        public long Id { get; set; }

        public string ToastText { get; set; }

        public List<ToastKeyword> ToastKeywords { get; set; }
    }
}