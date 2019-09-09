using MakeATrinkspruch.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeATrinkspruch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToastPage : ContentPage
    {
        private Toast currentToast;

        public ToastPage()
        {
            InitializeComponent();
            currentToast = App.Database.GetNewToastAsync(new Toast() { Id = 0, ToastText = "" }).Result;
            ToastTextLabel.Text = currentToast.ToastText;
        }

        async void OnGetNewToast(object sender, EventArgs e)
        {
            currentToast = await App.Database.GetNewToastAsync(currentToast);
            ToastTextLabel.Text = currentToast.ToastText;
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ITextToSpeech>().Speak(currentToast.ToastText);
        }
    }
}