using MakeATrinkspruch.Models;
using MakeATrinkspruch.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MakeATrinkspruch.Views
{
    public partial class FilterPage : ContentPage
    {
        private readonly FilterViewModel VM;

        public FilterPage(List<Keyword> selectableKeywords, List<Keyword> selectedKeywords)
        {
            InitializeComponent();
            VM = new FilterViewModel(selectableKeywords, selectedKeywords);
            BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}