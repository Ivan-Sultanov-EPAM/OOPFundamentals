using Library.Entities;

namespace Library.Repository;

public interface IRepository
{
    public IEnumerable<Card?> GetAll();
    public Card? GetByNumber(int number);
    public void AddRange(List<Card> card);
}