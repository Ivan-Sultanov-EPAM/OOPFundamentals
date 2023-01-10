namespace Library.Entities;

public class Patent : Card
{
    public int Id { get; set; }
    public DateTime ExpirationDate { get; set; }
}