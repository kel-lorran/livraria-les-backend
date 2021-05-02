using Shared;

namespace Domain.MerchandiseContext
{
    public class DecrementMerchandiseStockCommand : ICommand
    {
        public DecrementMerchandiseStockCommand()
        {
        }

        public DecrementMerchandiseStockCommand(int quantity, int bookId)
        {
            Quantity = quantity;
            BookId = bookId;
        }

        public int Quantity { get; set; }
        public int BookId { get; set; }

        public Book Book { get; private set; }

        public void SetBook(Book book)
        {
            Book = book;
        }
    }
}