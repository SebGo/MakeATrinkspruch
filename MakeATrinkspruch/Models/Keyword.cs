namespace MakeATrinkspruch.Models
{
	public class Keywords
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public List<ToastKeywords> ToastKeywords { get; set; }
	}
}
