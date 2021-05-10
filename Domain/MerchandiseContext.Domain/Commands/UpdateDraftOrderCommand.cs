using System;
using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateDraftOrderCommand : ICommand
    {
        public UpdateDraftOrderCommand(int id, List<OrderMerchandise> merchandiseList)
        {
            Id =id;
            MerchandiseList = merchandiseList;
        }
        
        public int Id { get; set; }
        public int CustomerId { get; private set; }
        public List<OrderMerchandise> MerchandiseList { get; set; }

        public void SetCustomerId(int id) => CustomerId = id;
    }
}