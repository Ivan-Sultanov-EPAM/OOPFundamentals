namespace Library.Entities;

public abstract class Card
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public DateTime DatePublished { get; set; }
}