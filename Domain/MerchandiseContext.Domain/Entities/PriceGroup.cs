using Shared;

namespace Domain.MerchandiseContext
{
    public class PriceGroup : Identity<PriceGroup, int>
    {
        public PriceGroup()
        {
        }

        public PriceGroup(int id)
        {
            base.Id = id;
        }

        public PriceGroup(string name, float minProfit)
        {
            Name = name;
            MinProfit = minProfit;
        }

        public string Name { get; set; }
        public float MinProfit { get; set; }
    }
}