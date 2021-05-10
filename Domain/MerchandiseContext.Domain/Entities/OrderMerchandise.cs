namespace Domain.MerchandiseContext
{
    public class OrderMerchandise : Merchandise
    {
        public OrderMerchandise()
        {
        }

        public OrderMerchandise(StockMerchandise stockMerchandise)
        {
            Price = stockMerchandise.Price;
            Quantity = stockMerchandise.Quantity;
            Book = stockMerchandise.Book;
        }

        public OrderMerchandise(float price, int quantity, Book book) : base(price, quantity, book)
        {
        }

        public string Status { get; set; }
    }
}