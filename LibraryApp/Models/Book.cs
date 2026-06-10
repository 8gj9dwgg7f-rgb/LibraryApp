namespace LibraryApp.Models
{
    public class Book : LibraryItem
    {
        public int Pages { get; set; }

        public Book(string title, string author, int year, int pages)
            : base(title, author, year)
        {
            Pages = pages;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Книга: {Title} / {Author} ({Year}) — {Pages} стр.");
        }
    }
}
