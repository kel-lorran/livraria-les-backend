using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateOrderStatusCommand : ICommand
    {
        public UpdateOrderStatusCommand()
        {
        }

        public UpdateOrderStatusCommand(int orderId, string status)
        {
            OrderId = orderId;
            Status = status;
        }

        public bool ReturnStock { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}