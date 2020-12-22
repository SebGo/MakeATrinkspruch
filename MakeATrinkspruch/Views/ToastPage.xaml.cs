using MakeATrinkspruch.ViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeATrinkspruch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToastPage : ContentPage
    {
        private readonly ToastViewModel VM;

        public ToastPage()
        {
            InitializeComponent();
            VM = new ToastViewModel();
            BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (VM.CurrentToast == null)
            {
                VM.GetRandomToastCommand.Execute(null);
            }

            if (VM.Keywords == null || !VM.Keywords.Any())
            {
                VM.LoadKeywordsCommand.Execute(null);
            }
        }
    }
}