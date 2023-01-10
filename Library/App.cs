using Library.DataHelpers;
using Library.Entities;
using Library.Output;
using Library.Repository;
using Library.StorageProviders;

namespace Library;

public static class App
{
    private static readonly IFileStorageProvider _storageProvider = new FileStorageProvider();

    private static readonly IRepository<Book> _bookFileRepository = new FileRepository<Book>(_storageProvider);
    private static readonly IRepository<LocalizedBook> _localizedBookFileRepository = new FileRepository<LocalizedBook>(_storageProvider);
    private static readonly IRepository<Patent> _patentFileRepository = new FileRepository<Patent>(_storageProvider);
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

    public static void PrintAllCards()
    {
        var books = _bookFileRepository.GetAll();
        var localizedBooks = _localizedBookFileRepository.GetAll();
        var patents = _patentFileRepository.GetAll();

        foreach (var book in books)
        {
            _printer.Display(book);
        }

        foreach (var book in localizedBooks)
        {
            _printer.Display(book);
        }

        foreach (var patent in patents)
        {
            _printer.Display(patent);
        }
    }

    public static void DisplayByNumber(int number)
    {
        _printer.Display(_bookFileRepository.Search(number));
        _printer.Display(_localizedBookFileRepository.Search(number));
        _printer.Display(_patentFileRepository.Search(number));
    }
}