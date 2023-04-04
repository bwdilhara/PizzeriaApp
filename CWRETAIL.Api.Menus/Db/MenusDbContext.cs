using Microsoft.EntityFrameworkCore;

namespace CWRETAIL.Api.Menus.Db
{
    public class MenusDbContext:DbContext
    {
        public MenusDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<LocationMenu> LocationMenus { get; set; }
        
    }
}
