namespace MakeATrinkspruch.Models
{
    public class SelectableData<T>
    {
        public T Data { get; set; }
        public bool IsChecked { get; set; }
    }
}