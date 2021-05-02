using System;
using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateDraftOrderCommand : ICommand
    {
        public int CustomerId { get; private set; }
        public List<OrderMerchandise> MerchandiseList { get; set; }
        public DateTime Date { get => DateTime.Now; }
        public string Status { get => "rascunho"; }

        public void SetCustomerId(int id) => CustomerId = id;
    }
}