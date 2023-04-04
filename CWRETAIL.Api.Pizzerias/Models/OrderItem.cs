namespace CWRETAIL.Api.Pizzerias.Models
{
    public class OrderItem
    {
        public int Id { get; set; }       
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
