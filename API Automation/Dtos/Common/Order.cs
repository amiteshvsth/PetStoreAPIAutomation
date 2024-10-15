namespace API_Automation.Dtos.Common
{
    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public long Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus Status { get; set; } // Enum for order status
        public bool Complete { get; set; }
    }
}