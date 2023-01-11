namespace Library.Cache;

public class CacheConfig
{
    public List<EntitySettings> CacheSettings { get; set; }
}

public class EntitySettings
{
    public string Type { get; set; }
    public string? TimeSpan { get; set; }
    public bool? DisableCache { get; set; }
}