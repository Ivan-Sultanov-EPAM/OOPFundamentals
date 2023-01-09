using Library.DataHelpers;
using Library.Entities;
using Library.Output;
using Library.Repository;

namespace Library;

public static class App
{
    private static readonly IRepository<Book> _bookFileRepository = new FileRepository<Book>();
    private static readonly IRepository<LocalizedBook> _localizedBookFileRepository = new FileRepository<LocalizedBook>();
    private static readonly IRepository<Patent> _patentFileRepository = new FileRepository<Patent>();
    private static readonly IOutput _printer = new ConsoleOutput();

    public static void InitializeData()
    {
        _bookFileRepository.Add(Books.Book1);
        _bookFileRepository.Add(Books.Book2);
        _bookFileRepository.Add(Books.Book3);

        _localizedBookFileRepository.AddRange(new List<LocalizedBook>
        {
            LocalizedBooks.LocalizedBook1,
            LocalizedBooks.LocalizedBook2,
            LocalizedBooks.LocalizedBook3
        });

        _patentFileRepository.AddRange(new List<Patent>
        {
            Patents.Patent1,
            Patents.Patent2,
            Patents.Patent3
        });
    }

    public static void PrintAllBooks()
    {
        var books = _bookFileRepository.GetAll();
        foreach (var book in books)
        {
            _printer.Display(book);
        }
    }
}