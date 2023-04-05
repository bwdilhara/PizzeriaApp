namespace CWRETAIL.Api.Menus.Db
{
    public class LocationMenu
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string MenuStatus { get; set; }
        public string Rating { get; set; }
        
    }
}
