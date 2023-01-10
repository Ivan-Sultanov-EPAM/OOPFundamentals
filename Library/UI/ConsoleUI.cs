using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Library.UI;

public class ConsoleUI : IUserInterface
{
    public void Display(object? obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Error. No information to display");
            return;
        }

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        var objectJson = JsonSerializer.Serialize(obj, options);

        Console.WriteLine(objectJson);
        Console.WriteLine();
    }

    public void PrintText(string text)
    {
        Console.WriteLine(text);
        Console.WriteLine();
    }
}