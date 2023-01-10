using Library.StorageProviders;

namespace Library.Repository;

public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IFileStorageProvider _repository;

    public FileRepository(IFileStorageProvider repository)
    {
        _repository = repository;
    }

    public IEnumerable<TEntity?> GetAll()
    {
        return _repository.GetAll<TEntity>();
    }

    public TEntity? Search(int number)
    {
        return _repository.GetByNumber<TEntity>(number);
    }

    public void Add(TEntity obj)
    {
        _repository.Save(obj);
    }

    public void AddRange(List<TEntity> objects)
    {
        foreach (var obj in objects)
        {
            _repository.Save(obj);
        }
    }
}