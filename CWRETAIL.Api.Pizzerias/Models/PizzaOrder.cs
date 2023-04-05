namespace CWRETAIL.Api.Pizzerias.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }        
        public List<LocationMenu> Items { get; set; }
    }
}
