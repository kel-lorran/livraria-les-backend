using Shared;

namespace Domain.MerchandiseContext
{
    public class DecrementMerchandiseStockCommand : ICommand
    {
        public DecrementMerchandiseStockCommand()
        {
        }

        public DecrementMerchandiseStockCommand(float price, int quantity, int bookId)
        {
            Price = price;
            Quantity = quantity;
            BookId = bookId;
        }

        public float Price { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }

        public Book Book { get; private set; }

        public void SetBook(Book book)
        {
            Book = book;
        }
    }
}