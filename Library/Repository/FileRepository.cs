namespace Library.Repository;

public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public IEnumerable<TEntity> GetAll()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Update(TEntity obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity obj)
    {
        throw new NotImplementedException();
    }
}