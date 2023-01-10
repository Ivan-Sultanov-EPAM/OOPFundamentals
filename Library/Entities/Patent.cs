namespace Library.Entities;

public class Patent : Card
{
    public int Id { get; set; }
    public DateTime ExpirationDate { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\n" +
               $"Authors: {string.Join(", ", Authors)}\n" +
               $"Date Published: {DatePublished:yyyy MMMM dd}\n" +
               $"Expiration Date: {ExpirationDate:yyyy MMMM dd}";
    }
}