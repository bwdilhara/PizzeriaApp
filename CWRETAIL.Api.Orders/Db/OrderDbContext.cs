using Microsoft.EntityFrameworkCore;

namespace CWRETAIL.Api.Orders.Db
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
