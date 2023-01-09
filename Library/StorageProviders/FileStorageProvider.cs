using System.Text.Json;

namespace Library.StorageProviders;

public static class FileStorageProvider
{
    private static readonly string _storagePath = $"{Environment.CurrentDirectory}//Storage";

    public static void Save<TEntity>(TEntity obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        var objectJson = JsonSerializer.Serialize(obj, options);

        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }

        if (!FileExists(obj, out var path, out var count))
        {
            count += 1;
            File.WriteAllText($"{_storagePath}//{obj!.GetType().Name}_#{count}.json", objectJson);
        }
    }

    public static TEntity? Read<TEntity>(string fileName)
    {
        var file = File.ReadAllBytes($"{_storagePath}//{fileName}.json");

        return JsonSerializer.Deserialize<TEntity>(file);
    }

    public static void Delete<TEntity>(TEntity obj)
    {
        if (FileExists(obj, out var path, out var count))
        {
            File.Delete(path);
        }
    }

    public static bool FileExists<TEntity>(TEntity obj, out string path, out int count)
    {
        path = "";
        count = 0;

        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            var type = fileName.Split('\\').Last().Split('_')[0];

            if (type.Equals($"{typeof(TEntity).Name}"))
            {
                count++;
            }
            else
            {
                continue;
            }

            var objectToCompare = JsonSerializer.Deserialize<TEntity>(File.ReadAllBytes(fileName));

            var jsonObj1 = JsonSerializer.Serialize(objectToCompare);
            var jsonObj2 = JsonSerializer.Serialize(obj);

            if (jsonObj1.Equals(jsonObj2, StringComparison.InvariantCulture))
            {
                path = fileName;
                return true;
            }
        }

        return false;
    }

    public static IEnumerable<TEntity?> GetAll<TEntity>()
    {
        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            if (fileName.Split('\\').Last().Split('_')[0].Equals($"{typeof(TEntity).Name}"))
            {
                yield return JsonSerializer.Deserialize<TEntity>(File.ReadAllBytes(fileName));
            }
        }
    }
}