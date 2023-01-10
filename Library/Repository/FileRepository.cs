using Library.Entities;
using Library.StorageProviders;

namespace Library.Repository;

public class FileRepository : IRepository
{
    private readonly IFileStorageProvider _repository;

    public FileRepository(IFileStorageProvider repository)
    {
        _repository = repository;
    }

    public IEnumerable<Card?> GetAll()
    {
        foreach (var obj in _repository.GetAll())
        {
            yield return obj as Card;
        }
    }

    public Card? GetByNumber(int number)
    {
        return _repository.GetByNumber(number) as Card;
    }

    public void AddRange(List<Card> objects)
    {
        foreach (var obj in objects)
        {
            _repository.Save(obj);
        }
    }
}