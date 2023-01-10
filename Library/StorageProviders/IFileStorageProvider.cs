namespace Library.StorageProviders;

public interface IFileStorageProvider
{
    void Save(object obj);
    object? GetByNumber(int number);
    IEnumerable<object?> GetAll();
}