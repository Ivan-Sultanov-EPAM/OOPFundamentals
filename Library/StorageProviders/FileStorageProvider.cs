using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Library.StorageProviders;

public class FileStorageProvider : IFileStorageProvider
{
    private static readonly string _storagePath = $"{Environment.CurrentDirectory}//Storage";

    public void Save<TEntity>(TEntity obj)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

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

    private TEntity? Read<TEntity>(string fileName)
    {
        var file = File.ReadAllBytes(fileName);

        return JsonSerializer.Deserialize<TEntity>(file);
    }

    private bool FileExists<TEntity>(TEntity obj, out string path, out int count)
    {
        path = "";
        count = 0;

        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            if (IsTypeEquals<TEntity>(fileName))
            {
                count++;
            }
            else
            {
                continue;
            }

            var objectToCompare = Read<TEntity>(fileName);

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

    public TEntity? GetByNumber<TEntity>(int number)
    {
        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            if (!IsTypeEquals<TEntity>(fileName))
            {
                continue;
            }

            if (GetFileNumber(fileName) == number)
            {
                return Read<TEntity>(fileName);
            }
        }

        return default;
    }

    public IEnumerable<TEntity?> GetAll<TEntity>()
    {
        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            if (IsTypeEquals<TEntity>(fileName))
            {
                yield return Read<TEntity>(fileName);
            }
        }
    }

    private static bool IsTypeEquals<TEntity>(string path)
    {
        return path.Split('\\').Last().Split('_')[0].Equals($"{typeof(TEntity).Name}");
    }

    private static int GetFileNumber(string path)
    {
        return int.Parse(path.Split('\\').Last().Split('#').Last().TrimEnd(".json".ToCharArray()));
    }
}