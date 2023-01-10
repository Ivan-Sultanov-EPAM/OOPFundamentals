namespace Library.Entities;

public class Magazine : Card
{
    public string Publisher { get; set; }
    public int ReleaseNumber { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\n" +
               $"Publisher: {Publisher}\n" +
               $"Release Number: {ReleaseNumber}\n" +
               $"Publish Date: {DatePublished:yyyy MMMM dd}";
    }
}