using AutoMapper;
using CWRETAIL.Api.Menus.Db;
using CWRETAIL.Api.Menus.Interfaces;
using CWRETAIL.Api.Menus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using CWRETAIL.Api.Menus.Models.Menu;
//CWRETAIL.Api.Menus.Models.Menu;

namespace CWRETAIL.Api.Menus.Providers
{
    public class MenusProvider : IMenusProvider
    {
        private readonly MenusDbContext _dbContext;
        private readonly ILogger<MenusProvider> _logger;
        private readonly IMapper _mapper;

        public MenusProvider(MenusDbContext dbContext, ILogger<MenusProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;           
            SeedData();
        }
        private void SeedData()
        {
            if (!_dbContext.Menus.Any())
            {
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 1, Name = "Capricciosa", Description = "Capricciosa – Cheese, Ham, Mushrooms, Olives" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 2, Name = "Mexicana", Description = "Mexicana – Cheese, Salami, Capsicum, Chilli" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 3, Name = "Margherita", Description = "Margherita – Cheese, Spinach, Ricotta, Cherry Tomatoes" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 4, Name = "Vegetarian", Description = "Vegetarian – Cheese, Mushrooms, Capsicum, Onion, Olives" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 5, Name = "Toppings", Description = "Toppings – Cheese" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 6, Name = "Toppings", Description = "Toppings – Capsicum" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 7, Name = "Toppings", Description = "Toppings – Salami" });
                _dbContext.Menus.Add(new Db.Menu() { MenuId = 8, Name = "Toppings", Description = "Toppings – Olives" });

                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 1, MenuId = 1, Price = 20, LocationId = 1, LocationName = "Preston" });
                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 2, MenuId = 2, Price = 18, LocationId = 1, LocationName = "Preston" });
                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 3, MenuId = 3, LocationId = 1, LocationName = "Preston", Price = 18 });
                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 4, MenuId = 6, LocationId = 1, LocationName = "Preston", Price = 1 });
                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 5, MenuId = 1, LocationId = 2, LocationName = "Southbank", Price = 25 });
                _dbContext.LocationMenus.Add(new Db.LocationMenu() { Id = 6, MenuId = 5, LocationId = 2, LocationName = "Southbank", Price = 17 });


                _dbContext.SaveChanges();
            }
        }


        public async Task<(bool isSuccess, IEnumerable<Models.Menu> menus, string errorMessage)> GetMenusAsync()
        {
            try
            {
                _logger?.LogInformation($"Querying Menus");
                var menu = await _dbContext.Menus.ToListAsync();
                if (menu != null)
                {
                    _logger?.LogInformation("menu found");
                    var result = _mapper.Map<IEnumerable<Models.Menu>>(menu);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool isSuccess, IEnumerable<Models.LocationMenu> menus, string errorMessage)> GetLocationMenusAsync(int locationId)
        {
            try
            {
                _logger?.LogInformation($"Querying Menus");
                var menu = await _dbContext.LocationMenus.Where(i=>i.LocationId == locationId).ToListAsync();
                if (menu != null)
                {
                    _logger?.LogInformation("menu found");
                    var result = _mapper.Map<IEnumerable<Models.LocationMenu>>(menu);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
