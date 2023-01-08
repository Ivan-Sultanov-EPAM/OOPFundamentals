namespace Library.Entities;

public class Patent
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public DateTime DatePublished { get; set; }
    public DateTime ExpirationDate { get; set; }
}