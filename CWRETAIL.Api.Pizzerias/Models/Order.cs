namespace CWRETAIL.Api.Pizzerias.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
