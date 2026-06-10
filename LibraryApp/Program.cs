using System.Collections.Generic;
using LibraryApp.Models;

var items = new List<LibraryItem>
{
    new Book("1984", "Оруэлл", 1949, 328),
    new Magazine("Science", "Редколлегия", 2023, 5),
    new Book("Анна Каренина", "Толстой", 1877, 850)
};

foreach (LibraryItem item in items)
{
    item.DisplayInfo();
}
