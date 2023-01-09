using Library.StorageProviders;

namespace Library.Repository;

public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public IEnumerable<TEntity?> GetAll()
    {
        return FileStorageProvider.GetAll<TEntity>();
    }

    public TEntity GetById(object id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> Search(Predicate<TEntity> predicate)
    {
        throw new NotImplementedException();
    }

    public void Add(TEntity obj)
    {
        FileStorageProvider.Save(obj);
    }

    public void AddRange(List<TEntity> objects)
    {
        foreach (var obj in objects)
        {
            FileStorageProvider.Save(obj);
        }
    }

    public void Update(TEntity obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity obj)
    {
        FileStorageProvider.Delete(obj);
    }
}