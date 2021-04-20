namespace Domain.MerchandiseContext
{
    public interface IProductRepository
    {
        Book CreateBook(Book book);
        Book GetById(int id);
    }
}