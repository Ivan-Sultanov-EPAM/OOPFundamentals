using System.Text.Json;

namespace Library.Output;

public class ConsoleOutput : IOutput
{
    public void Display<TEntity>(TEntity obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var objectJson = JsonSerializer.Serialize(obj, options);

        Console.WriteLine(objectJson);
        Console.WriteLine();
    }
}