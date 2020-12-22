namespace MakeATrinkspruch.Models
{
    public class ToastKeyword
    {
        public long ToastId { get; set; }
        public Toast Toast { get; set; }

        public long KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}