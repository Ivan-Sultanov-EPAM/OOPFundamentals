using Library.DataHelpers;
using Library.Entities;
using Library.Output;
using Library.Repository;

namespace Library;

public class App : IApp
{
    private readonly IRepository<Book> _bookFileRepository;
    private readonly IRepository<LocalizedBook> _localizedBookFileRepository;
    private readonly IRepository<Patent> _patentFileRepository;
    private readonly IOutput _printer;

    public App(IRepository<Book> bookFileRepository,
        IRepository<LocalizedBook> localizedBookFileRepository,
        IRepository<Patent> patentFileRepository,
        IOutput printer)
    {
        _bookFileRepository = bookFileRepository;
        _localizedBookFileRepository = localizedBookFileRepository;
        _patentFileRepository = patentFileRepository;
        _printer = printer;
    }

    public void InitializeData()
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

    public void PrintAllCards()
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

    public void DisplayByNumber(int number)
    {
        _printer.Display(_bookFileRepository.Search(number));
        _printer.Display(_localizedBookFileRepository.Search(number));
        _printer.Display(_patentFileRepository.Search(number));
    }
}