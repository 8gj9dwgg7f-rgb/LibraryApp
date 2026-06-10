namespace LibraryApp.Models
{
    public class Book : LibraryItem, IBorrowable
    {
        public bool IsAvailable { get; set; } = true;
        public int Pages { get; set; }

        public Book(string title, string author, int year, int pages)
            : base(title, author, year)
        {
            if (pages <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pages), "Количество страниц должно быть больше нуля");
            }

            Pages = pages;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Книга: {Title} / {Author} ({Year}) — {Pages} стр.");
        }

        public void Borrow(string borrowerName)
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"Книга '{Title}' выдана пользователю {borrowerName}");
            }
            else
            {
                Console.WriteLine($"Книга '{Title}' уже выдана");
            }
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"Книга '{Title}' возвращена");
        }
    }
}
