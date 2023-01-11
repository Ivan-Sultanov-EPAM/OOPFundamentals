namespace Library.Cache
{
    public interface IAppCache
    {
        bool TryGetValue(object key, out object? o);
        void Set(object key, object value);
    }
}