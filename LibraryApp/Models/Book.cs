namespace LibraryApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Автор не может быть пустым", nameof(author));
            }

            if (year < 0 || year > DateTime.Now.Year + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Недопустимый год издания");
            }

            Title = title;
            Author = author;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}, Автор: {Author}, Год: {Year}");
        }
    }
}
