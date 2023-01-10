using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Library.StorageProviders;

public class FileStorageProvider : IFileStorageProvider
{
    private static readonly string _storagePath = $"{Environment.CurrentDirectory}//Storage";

    public void Save(object obj)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        var objectJson = JsonSerializer.Serialize(obj, obj!.GetType(), options);

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

    private object? Read(string fileName)
    {
        var assemblyName = this.GetType().Assembly.GetName().Name;

        var typeString = GetTypeFromName(fileName);

        var type = Type.GetType($"{assemblyName}.Entities.{typeString}");

        var file = File.ReadAllBytes(fileName);

        return JsonSerializer.Deserialize(file, type);
    }

    private bool FileExists<TEntity>(TEntity obj, out string path, out int count)
    {
        path = "";
        count = 0;

        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            count++;

            var objectToCompare = Read(fileName);

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

    public object? GetByNumber(int number)
    {
        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            if (GetFileNumber(fileName) == number)
            {
                return Read(fileName);
            }
        }

        return default;
    }

    public IEnumerable<object?> GetAll()
    {
        foreach (var fileName in Directory.GetFiles(_storagePath))
        {
            yield return Read(fileName);
        }
    }

    private static int GetFileNumber(string path)
    {
        return int.Parse(path.Split('\\').Last().Split('#').Last().TrimEnd(".json".ToCharArray()));
    }

    private static string GetTypeFromName(string path)
    {
        return path.Split('\\').Last().Split('_').First();
    }
}