namespace Library.Entities;

[Serializable]
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public string Publisher { get; set; }
    public int NumberOfPages { get; set; }
    public DateTime DatePublished { get; set; }
}