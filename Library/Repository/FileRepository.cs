using Library.Cache;
using Library.Entities;
using Library.StorageProviders;

namespace Library.Repository;

public class FileRepository : IRepository
{
    private readonly IFileStorageProvider _repository;
    private readonly IAppCache _cache;

    public FileRepository(IFileStorageProvider repository, IAppCache cache)
    {
        _repository = repository;
        _cache = cache;
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
        if (_cache.TryGetValue(number, out var card))
        {
            return card as Card;
        }

        var newValue = _repository.GetByNumber(number) as Card;

        if (newValue != null)
        {
            _cache.Set(number, newValue);
        }


        return newValue;
    }

    public void AddRange(List<Card> objects)
    {
        foreach (var obj in objects)
        {
            _repository.Save(obj);
        }
    }
}