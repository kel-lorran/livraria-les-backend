using Shared;

namespace Domain.MerchandiseContext
{
    public class Merchandise : Identity<Book, int>
    {
        public Merchandise()
        {
        }

        public Merchandise(float price, int quantity, Book book)
        {
            Price = price;
            Quantity = quantity;
            Book = book;
        }

        public float Price { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
    }
}