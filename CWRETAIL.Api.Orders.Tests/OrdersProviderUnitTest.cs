using AutoMapper;
using CWRETAIL.Api.Orders.Db;
using CWRETAIL.Api.Orders.Profiles;
using CWRETAIL.Api.Orders.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit.Abstractions;

namespace CWRETAIL.Api.Orders.Tests
{
    public class OrdersProviderUnitTest
    {
        [Fact]
        public async Task CreateOrderForOneBlankRecord()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
               .UseInMemoryDatabase(nameof(CreateOrderForOneBlankRecord))
               .Options;
            var dbContext = new OrdersDbContext(options);
            
            var order = new Models.Order()
            {               
                LocationId = 1,
                OrderDate = DateTime.Now,
                Items = new List<Models.OrderItem> { new Models.OrderItem {  } }
            };

            var orderProfile = new OrderProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(orderProfile));
            var mapper = new Mapper(configuration);

            var ordersProvider = new OrdersProvider(dbContext, null, mapper);

            var result = await ordersProvider.CreateOrdersAsync(order);
            Assert.True(result.isSuccess);
            Assert.True(result.totalAmount==0);
            Assert.Null(result.errorMessage);
        }


        [Fact]
        public async Task CreateOrderForOnePizza()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
               .UseInMemoryDatabase(nameof(CreateOrderForOnePizza))
               .Options;
            var dbContext = new OrdersDbContext(options);
         
            var order = new Models.Order()
            {
                LocationId = 1,
                OrderDate = DateTime.Now,
                Items = new List<Models.OrderItem> {
                    new Models.OrderItem {
                        MenuId = 1,
                        Quantity= 1,
                        UnitPrice=20
                } }
            };

            var orderProfile = new OrderProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(orderProfile));
            var mapper = new Mapper(configuration);

            var ordersProvider = new OrdersProvider(dbContext, null, mapper);

            var result = await ordersProvider.CreateOrdersAsync(order);
            Assert.True(result.isSuccess);
            Assert.True(result.totalAmount == 20);
            Assert.Null(result.errorMessage);
        }


        [Fact]
        public async Task CreateOrderForMultiplePizza()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
               .UseInMemoryDatabase(nameof(CreateOrderForMultiplePizza))
               .Options;
            var dbContext = new OrdersDbContext(options);
            
            var order = new Models.Order()
            {                
                LocationId = 1,
                OrderDate = DateTime.Now,
                Items = new List<Models.OrderItem> {
                    new Models.OrderItem {
                        MenuId = 1,
                        Quantity= 1,
                        UnitPrice=20
                },new Models.OrderItem {
                        MenuId = 1,
                        Quantity= 1,
                        UnitPrice=20
                },
                new Models.OrderItem {
                        MenuId = 2,
                        Quantity= 1,
                        UnitPrice=18
                }}
            };

            var orderProfile = new OrderProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(orderProfile));
            var mapper = new Mapper(configuration);

            var ordersProvider = new OrdersProvider(dbContext, null, mapper);

            var result = await ordersProvider.CreateOrdersAsync(order);
            Assert.True(result.isSuccess);
            Assert.True(result.totalAmount == 58);
            Assert.Null(result.errorMessage);
        }        
    }
}