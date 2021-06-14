using System;
using Shared;

namespace Domain.MerchandiseContext
{
    public class DecrementMerchandiseStockCommand : ICommand
    {
        private int _quantity;
        public DecrementMerchandiseStockCommand()
        {
        }

        public DecrementMerchandiseStockCommand(int quantity, int bookId)
        {
            Quantity = quantity;
            BookId = bookId;
        }

        public int Quantity { get => _quantity; set => _quantity = Math.Abs(value) * -1; }
        public int BookId { get; set; }

        public Book Book { get; private set; }

        public void SetBook(Book book)
        {
            Book = book;
        }
    }
}