namespace CWRETAIL.Api.Menus.Models
{
    public class LocationMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MenuId { get; set; }
        public string? MenuStatus { get; set; }
        public string? Category { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string Rating { get; set; }
    }
}
