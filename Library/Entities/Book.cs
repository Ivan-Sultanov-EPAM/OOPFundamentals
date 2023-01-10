namespace Library.Entities;

public class Book : Card
{
    public string ISBN { get; set; }
    public string Publisher { get; set; }
    public int NumberOfPages { get; set; }

    public override string ToString()
    {
        return $"ISBN:  {ISBN}\n" +
               $"Title: {Title}\n" +
               $"Authors: {string.Join(", ", Authors)}\n" +
               $"Pages: {NumberOfPages}\n" +
               $"Publisher: {Publisher}\n" +
               $"Date Published: {DatePublished:yyyy}";
    }
}