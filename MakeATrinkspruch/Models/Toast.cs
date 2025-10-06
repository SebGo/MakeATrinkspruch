namespace MakeATrinkspruch.Models
{
	public class Toasts
	{
		public long Id { get; set; }

		public string ToastText { get; set; }

		public List<ToastKeywords> ToastKeywords { get; set; }

		
	}
}
