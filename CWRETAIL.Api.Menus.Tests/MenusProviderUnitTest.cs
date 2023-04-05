using AutoMapper;
using CWRETAIL.Api.Menus.Db;
using CWRETAIL.Api.Menus.Profiles;
using CWRETAIL.Api.Menus.Providers;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CWRETAIL.Api.Menus.Tests
{
    public class MenusProviderUnitTest 
    {
        [Fact]
        public async Task GetAllMenus()
        {
            var options = new DbContextOptionsBuilder<MenusDbContext>()
               .UseInMemoryDatabase(nameof(GetAllMenus))
               .Options;
            var dbContext = new MenusDbContext(options);            

            var menuProfile = new MenuProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(menuProfile));
            var mapper = new Mapper(configuration);

            var menusProvider = new MenusProvider(dbContext, null, mapper);

            var result = await menusProvider.GetMenusAsync();
            Assert.True(result.isSuccess);
            Assert.True(result.menus.Any());
            Assert.Null(result.errorMessage);

        }

        [Fact]
        public async Task GetMenusForCustomerLocation()
        {
            var options = new DbContextOptionsBuilder<MenusDbContext>()
               .UseInMemoryDatabase(nameof(GetMenusForCustomerLocation))
               .Options;
            var dbContext = new MenusDbContext(options);          

            var menuProfile = new MenuProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(menuProfile));
            var mapper = new Mapper(configuration);

            var menusProvider = new MenusProvider(dbContext, null, mapper);

            var result = await menusProvider.GetLocationMenusAsync(1);
            Assert.True(result.isSuccess);
            Assert.True(result.menus.Count()==4);
            Assert.Null(result.errorMessage);
        }
    }
}