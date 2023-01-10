using Library.DataHelpers;
using Library.Entities;
using Library.Repository;
using Library.UI;

namespace Library;

public class App : IApp
{
    private readonly IRepository<Book> _bookFileRepository;
    private readonly IRepository<LocalizedBook> _localizedBookFileRepository;
    private readonly IRepository<Patent> _patentFileRepository;
    private readonly IUserInterface _userInterface;

    public App(IRepository<Book> bookFileRepository,
        IRepository<LocalizedBook> localizedBookFileRepository,
        IRepository<Patent> patentFileRepository,
        IUserInterface userInterface)
    {
        _bookFileRepository = bookFileRepository;
        _localizedBookFileRepository = localizedBookFileRepository;
        _patentFileRepository = patentFileRepository;
        _userInterface = userInterface;
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
            _userInterface.Display(book);
        }

        foreach (var book in localizedBooks)
        {
            _userInterface.Display(book);
        }

        foreach (var patent in patents)
        {
            _userInterface.Display(patent);
        }
    }

    public void DisplayByNumber(int number)
    {
        _userInterface.Display(_bookFileRepository.Search(number));
        _userInterface.Display(_localizedBookFileRepository.Search(number));
        _userInterface.Display(_patentFileRepository.Search(number));
    }
}