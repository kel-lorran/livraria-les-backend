using Shared;

namespace Domain.MerchandiseContext
{
    public abstract class  Merchandise : Identity<Merchandise, int>
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

        public int Id { get => base.Id; set => base.Id = value; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        [System.Text.Json.Serialization.JsonInclude]
        public Book Book { get; set; }
    }
}