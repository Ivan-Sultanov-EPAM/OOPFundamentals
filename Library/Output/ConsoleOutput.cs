using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Library.Output;

public class ConsoleOutput : IOutput
{
    public void Display(Object? obj)
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

    public void Print(string text)
    {
        Console.WriteLine(text);
        Console.WriteLine();
    }
}