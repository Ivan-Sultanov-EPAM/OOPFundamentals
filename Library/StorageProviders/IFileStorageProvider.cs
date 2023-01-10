namespace Library.StorageProviders;

public interface IFileStorageProvider
{
    void Save<TEntity>(TEntity obj);
    TEntity? GetByNumber<TEntity>(int number);
    IEnumerable<TEntity?> GetAll<TEntity>();
}