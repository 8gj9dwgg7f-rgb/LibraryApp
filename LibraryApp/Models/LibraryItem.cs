namespace LibraryApp.Models
{
    public abstract class LibraryItem
    {
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public int Year { get; protected set; }

        protected LibraryItem(string title, string author, int year)
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

        public abstract void DisplayInfo();
    }
}
