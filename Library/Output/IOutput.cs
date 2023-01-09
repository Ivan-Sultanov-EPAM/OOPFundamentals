namespace Library.Output;

public interface IOutput
{
    public void Display<TEntity>(TEntity obj);
}