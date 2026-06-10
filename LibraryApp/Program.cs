using LibraryApp.Models;
using LibraryApp.Services;

var library = new Library();

library.AddItem(new Book("1984", "Оруэлл", 1949, 328));
library.AddItem(new Book("Гарри Поттер", "Роулинг", 1997, 400));
library.AddItem(new Magazine("Science", "Редколлегия", 2023, 5));

Console.WriteLine("=== Все издания ===");
library.GetAllItems().ForEach(item => item.DisplayInfo());

Console.WriteLine("\n=== Книги Роулинг ===");
library.GetBooksByAuthor("Роулинг").ForEach(book => book.DisplayInfo());

Console.WriteLine("\n=== Современные книги (после 2000) ===");
library.GetModernBookTitles().ForEach(Console.WriteLine);
