using MakeATrinkspruch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MakeATrinkspruch.ViewModels
{
    public class FilterViewModel : BaseViewModel
    {
        public List<SelectableData<Keyword>> DataSource { get; set; }
        public ICommand CloseCommand { get; }
        public ICommand SetFilterCommand { get; }

        public FilterViewModel()
        {
        }

        public FilterViewModel(List<Keyword> keywords, List<Keyword> selectedKeywords)
        {
            Title = "Filter";
            CloseCommand = new Command(async () => await OnCloseClicked());
            SetFilterCommand = new Command(async () => await OnSetFilter());
            DataSource = new List<SelectableData<Keyword>>();
            foreach (Keyword keyword in keywords)
            {
                SelectableData<Keyword> sk = new SelectableData<Keyword>()
                {
                    Data = keyword
                };
                if (selectedKeywords.Contains(keyword))
                {
                    sk.IsChecked = true;
                }
                DataSource.Add(sk);
            }
        }

        private async Task OnSetFilter()
        {
            List<Keyword> selectedKeyword = DataSource.Where(k => k.IsChecked == true).Select(t => t.Data).ToList();
            MessagingCenter.Send(this, "Filter", selectedKeyword);

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task OnCloseClicked()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}