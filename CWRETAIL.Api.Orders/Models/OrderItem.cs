namespace CWRETAIL.Api.Orders.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
