namespace LibraryApp.Models
{
    public class Book
    {
        public string Title = string.Empty;
        public string Author = string.Empty;
        public int Year;

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}, Автор: {Author}, Год: {Year}");
        }
    }
}
