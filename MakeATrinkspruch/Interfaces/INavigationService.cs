using MakeATrinkspruch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeATrinkspruch.Interfaces
{
	public interface INavigationService
	{
		Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
		Task GoBackAsync();
	}
}
