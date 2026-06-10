using System.Linq;
using LibraryApp.Models;
using LibraryApp.Services;

var library = new Library();
bool running = true;

while (running)
{
    ClearConsole();
    Console.WriteLine("=== Библиотека ===");
    Console.WriteLine("1. Добавить книгу");
    Console.WriteLine("2. Добавить журнал");
    Console.WriteLine("3. Показать все");
    Console.WriteLine("4. Поиск по автору");
    Console.WriteLine("5. Выдать книгу");
    Console.WriteLine("0. Выход");
    Console.Write("Выбор: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddBook(library);
            break;
        case "2":
            AddMagazine(library);
            break;
        case "3":
            ShowAll(library);
            break;
        case "4":
            SearchByAuthor(library);
            break;
        case "5":
            BorrowBook(library);
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Неверный выбор.");
            Pause();
            break;
    }
}

static void AddBook(Library library)
{
    try
    {
        Console.Write("Название: ");
        string title = ReadRequiredLine();

        Console.Write("Автор: ");
        string author = ReadRequiredLine();

        Console.Write("Год: ");
        int year = ReadInt();

        Console.Write("Страницы: ");
        int pages = ReadInt();

        library.AddItem(new Book(title, author, year, pages));
        Console.WriteLine("Книга добавлена!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }

    Pause();
}

static void AddMagazine(Library library)
{
    try
    {
        Console.Write("Название: ");
        string title = ReadRequiredLine();

        Console.Write("Автор: ");
        string author = ReadRequiredLine();

        Console.Write("Год: ");
        int year = ReadInt();

        Console.Write("Номер выпуска: ");
        int issueNumber = ReadInt();

        library.AddItem(new Magazine(title, author, year, issueNumber));
        Console.WriteLine("Журнал добавлен!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }

    Pause();
}

static void ShowAll(Library library)
{
    List<LibraryItem> items = library.GetAllItems();

    if (items.Count == 0)
    {
        Console.WriteLine("Библиотека пуста.");
    }
    else
    {
        foreach (LibraryItem item in items)
        {
            item.DisplayInfo();
        }
    }

    Pause();
}

static void SearchByAuthor(Library library)
{
    Console.Write("Автор: ");
    string author = Console.ReadLine() ?? string.Empty;

    List<Book> books = library.GetBooksByAuthor(author);

    if (books.Count == 0)
    {
        Console.WriteLine("Книги этого автора не найдены.");
    }
    else
    {
        foreach (Book book in books)
        {
            book.DisplayInfo();
        }
    }

    Pause();
}

static void BorrowBook(Library library)
{
    Console.Write("Название книги: ");
    string title = Console.ReadLine() ?? string.Empty;

    Book? book = library
        .GetAllItems()
        .OfType<Book>()
        .FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

    if (book is null)
    {
        Console.WriteLine("Книга не найдена.");
    }
    else
    {
        book.Borrow("Пользователь");
    }

    Pause();
}

static string ReadRequiredLine()
{
    string? value = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(value))
    {
        throw new ArgumentException("Значение не может быть пустым");
    }

    return value;
}

static int ReadInt()
{
    string value = ReadRequiredLine();

    if (!int.TryParse(value, out int number))
    {
        throw new FormatException("Введите целое число");
    }

    return number;
}

static void Pause()
{
    Console.WriteLine("Нажмите любую клавишу...");

    if (!Console.IsInputRedirected)
    {
        Console.ReadKey(true);
    }
}

static void ClearConsole()
{
    if (Console.IsInputRedirected || Console.IsOutputRedirected)
    {
        return;
    }

    Console.Clear();
}
