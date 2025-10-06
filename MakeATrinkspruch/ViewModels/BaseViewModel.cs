using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MakeATrinkspruch.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private string title = string.Empty;

		public BaseViewModel()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;

		public string Title
		{
			get => title;
			set
			{
				if (title != value)
				{
					title = value;
					OnPropertyChanged(); // reports this property
				}
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string name = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		protected bool SetProperty<T>(ref T backingStore, T value,
					[CallerMemberName] string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
