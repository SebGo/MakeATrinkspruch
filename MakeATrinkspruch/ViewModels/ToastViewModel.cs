using MakeATrinkspruch.Models;
using MakeATrinkspruch.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MakeATrinkspruch.ViewModels
{
    public class ToastViewModel : BaseViewModel
    {
        private Toast currentToast;
        private IEnumerable<Keyword> selectedKeywords;

        public ToastViewModel()
        {
            Title = "Make A Trinkspruch";

            SwipeCommand = new Command<string>(async (string swipeDirection) => await OnSwipeAsync(swipeDirection));
            ReadCommand = new Command(OnReadClicked);
            FilterCommand = new Command(async () => await OnFilterClicked());
            AboutCommand = new Command(async () => await OnAbout());
            BuyABeerCommand = new Command(async () => await OnBuyABeerClicked());
            LoadKeywordsCommand = new Command(async () => await OnLoadKeywords());
            GetRandomToastCommand = new Command(async () => await OnGetRandomToast());

            selectedKeywords = new List<Keyword>();

            MessagingCenter.Subscribe<FilterViewModel, List<Keyword>>(this, "Filter", async (obj, s) =>
            {
                selectedKeywords = s;
                CurrentToast = await DataService.GetAFilteredToast(selectedKeywords);
            });
        }

        public ICommand AboutCommand { get; }
        public ICommand BuyABeerCommand { get; }

        public Toast CurrentToast
        {
            set => SetProperty(ref currentToast, value);
            get => currentToast;
        }

        public ICommand FilterCommand { get; }
        public ICommand GetRandomToastCommand { get; }
        public IEnumerable<Keyword> Keywords { get; private set; }
        public ICommand LoadKeywordsCommand { get; }

        public ICommand ReadCommand { get; }

        public ICommand SwipeCommand { get; }

        private async Task OnAbout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }

        private async Task OnBuyABeerClicked()
        {
            await Launcher.OpenAsync(new Uri("https://paypal.me/MakeATrinkspruch"));
        }

        private async Task OnFilterClicked()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new FilterPage((List<Keyword>)Keywords, (List<Keyword>)selectedKeywords));
        }

        private async Task OnGetRandomToast()
        {
            CurrentToast = await DataService.GetRandomToast();
        }

        private async Task OnLoadKeywords()
        {
            Keywords = await DataService.GetAllKeywords();
        }

        private void OnReadClicked()
        {
            DependencyService.Get<ITextToSpeech>().Speak(CurrentToast.ToastText);
        }

        private async Task OnSwipeAsync(string swipeDirection)
        {
            if (swipeDirection.Equals("Left"))
            {
                CurrentToast = await DataService.GetAFilteredToast(selectedKeywords);
            }
        }
    }
}