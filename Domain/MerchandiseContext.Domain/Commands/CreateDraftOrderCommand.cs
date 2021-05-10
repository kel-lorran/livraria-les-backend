using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateDraftOrderCommand : ICommand
    {
        private List<OrderMerchandise> _merchandiseList = new List<OrderMerchandise>();
        public CreateDraftOrderCommand(List<OrderMerchandise> merchandiseList)
        {
            MerchandiseList = merchandiseList;
        }

        public int CustomerId { get; private set; }
        public List<OrderMerchandise> MerchandiseList { get => new List<OrderMerchandise>(){ _merchandiseList.ElementAt(0) }; set => _merchandiseList = value; }
        public DateTime Date { get => DateTime.Now; }
        public string Status { get => "rascunho"; }

        public void SetCustomerId(int id) => CustomerId = id;
    }
}