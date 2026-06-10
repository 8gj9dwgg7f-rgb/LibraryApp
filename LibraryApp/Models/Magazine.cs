namespace LibraryApp.Models
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, int year, int issueNumber)
            : base(title, author, year)
        {
            if (issueNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(issueNumber), "Номер выпуска должен быть больше нуля");
            }

            IssueNumber = issueNumber;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Журнал: {Title} / {Author} ({Year}) — Выпуск №{IssueNumber}");
        }
    }
}
