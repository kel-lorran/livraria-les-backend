namespace Domain.MerchandiseContext
{
    public class StockMerchandise : Merchandise
    {
        public StockMerchandise()
        {
        }

        public StockMerchandise(float price, int quantity, Book book) : base(price, quantity, book)
        {
        }
    }
}