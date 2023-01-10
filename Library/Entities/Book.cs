namespace Library.Entities;

public class Book : Card
{
    public string? ISBN { get; set; }
    public string? Publisher { get; set; }
    public int NumberOfPages { get; set; }
}