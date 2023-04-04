namespace CWRETAIL.Api.Pizzerias.Models
{
    public class PizzaOrderItem
    {
        public int Id { get; set; }       
        public int locationMenuId { get; set; }
        public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }
    }
}
