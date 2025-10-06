namespace MakeATrinkspruch.Models
{
	public class ToastKeywords
	{
		public long ToastId { get; set; }
		public Toasts Toast { get; set; }

		public long KeywordId { get; set; }
		public Keywords Keyword { get; set; }
	}
}
