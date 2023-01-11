using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Library.Cache;

public class AppCache : IAppCache
{
    private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    private readonly IConfiguration _configuration;

    public AppCache(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool TryGetValue(object key, out object? o)
    {
        var value = _cache.TryGetValue(key, out var obj);

        o = obj;

        return value;
    }

    public void Set(object key, object value)
    {
        var type = value.GetType().Name;
        var cacheSettings = TryGetCacheSettings(type, out var timeSpan);

        if (cacheSettings == (true, true))
        {
            _cache.Set(key, value, timeSpan);
        }

        if (cacheSettings == (true, false))
        {
            _cache.Set(key, value);
        }
    }

    private (bool, bool) TryGetCacheSettings(string type, out TimeSpan timeSpan)
    {
        var cacheConfig =
            _configuration.GetRequiredSection("CacheConfig")
                .Get<CacheConfig>()?.CacheSettings;

        var config = cacheConfig?.FirstOrDefault(x => x.Type == type);

        timeSpan = TimeSpan.Parse(config?.TimeSpan ?? "0:0:0:0");

        if (config == null || config.DisableCache == true)
        {
            timeSpan = TimeSpan.Zero;
            return (false, false);
        }

        if (timeSpan > new TimeSpan(0, 0, 0, 0))
        {
            return (true, true);
        }

        return (true, false);
    }
}