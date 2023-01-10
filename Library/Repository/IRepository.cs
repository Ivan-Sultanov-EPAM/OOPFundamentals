namespace Library.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    public IEnumerable<TEntity?> GetAll();
    public TEntity? Search(int number);
    public void Add(TEntity obj);
    public void AddRange(List<TEntity> obj);
}