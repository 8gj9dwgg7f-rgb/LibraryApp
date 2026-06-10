namespace LibraryApp.Models
{
    public interface IBorrowable
    {
        bool IsAvailable { get; set; }
        void Borrow(string borrowerName);
        void Return();
    }
}
