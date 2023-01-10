using Library.DataHelpers;
using Library.Entities;
using Library.Repository;
using Library.UI;

namespace Library;

public class App : IApp
{
    private readonly IRepository _fileRepository;
    private readonly IUserInterface _userInterface;

    public App(IRepository fileRepository, IUserInterface userInterface)
    {
        _fileRepository = fileRepository;
        _userInterface = userInterface;
    }

    public void InitializeData()
    {
        _fileRepository.AddRange(new List<Card>
        {
            Books.Book1,
            Books.Book2,
            Books.Book2
        });

        _fileRepository.AddRange(new List<Card>
        {
            LocalizedBooks.LocalizedBook1,
            LocalizedBooks.LocalizedBook2,
            LocalizedBooks.LocalizedBook3
        });

        _fileRepository.AddRange(new List<Card>
        {
            Patents.Patent1,
            Patents.Patent2,
            Patents.Patent3
        });

        _fileRepository.AddRange(new List<Card>
        {
            Magazines.Magazine1,
            Magazines.Magazine2,
            Magazines.Magazine3
        });
    }

    public void PrintAllCards()
    {
        var cards = _fileRepository.GetAll();

        foreach (var card in cards)
        {
            var type = card.GetType().Name;

            _userInterface.DisplayCard(card, type);
        }
    }

    public void DisplayByNumber(int number)
    {
        var obj = _fileRepository.GetByNumber(number);
        var type = obj?.GetType().Name;

        _userInterface.DisplayCard(obj, type);
    }
}