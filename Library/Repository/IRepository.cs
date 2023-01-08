namespace Library.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    public TEntity GetById(object id);
    public IEnumerable<TEntity> GetAll();
    public IEnumerable<TEntity> Search(Predicate<TEntity> predicate);
    public void Add(TEntity obj);
    public void Update(TEntity obj);
    public void Delete(TEntity obj);
}