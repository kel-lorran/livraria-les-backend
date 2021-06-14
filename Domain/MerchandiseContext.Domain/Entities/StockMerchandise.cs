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

        public float PriceSeller { get; set; }

        public bool Increment(float price, int quantity, float priceSeller)
        {
            if(price < 1 || quantity < 1 || priceSeller < 1)
                return false;
            var newQuantity = Quantity + quantity;
            var newPrice = (Quantity * Price + quantity * price) / newQuantity;
            var profit = priceSeller / newPrice;
            if(newQuantity < 0 || profit < Book.PricingGroup.MinProfit)
                return false;
            Quantity = newQuantity;
            Price = newPrice;
            PriceSeller = priceSeller;
            return true;
        }

        public bool Decrement(int quantity)
        {
            var newQuantity = Quantity + quantity;
            if(newQuantity < 0)
                return false;
            Quantity = newQuantity;
            return true;
        }
    }
}