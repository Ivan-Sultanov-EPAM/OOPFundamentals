using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Library.UI;

public class ConsoleUI : IUserInterface
{
    public void DisplayCard(object? obj, string type)
    {
        if (obj == null)
        {
            Console.WriteLine("Error. No cards found");
            return;
        }

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        var objectJson = JsonSerializer.Serialize(obj, options);
        Console.WriteLine($"-{type}-");
        Console.WriteLine(obj.ToString());
        Console.WriteLine();
    }
}