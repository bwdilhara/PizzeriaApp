using CWRETAIL.Api.Pizzerias.Interfaces;
using CWRETAIL.Api.Pizzerias.Models;
using CWRETAIL.Api.Pizzerias.Services;
using Moq;
using Polly;
using System.Reflection.Metadata.Ecma335;

namespace CWRETAIL.Api.Pizzerias.Test
{
    public class PizzeriaServiceTest
    {
        private Mock<IMenuService> _menuService;
        private Mock<IOrderService> _orderService;

        public PizzeriaServiceTest()
        {
            _menuService =  new Mock<IMenuService>();
            _orderService= new Mock<IOrderService>();
        }

        [Fact]
        public async void CalculatTotalOrderAmount()
        {
            _menuService.Setup(m => m.GetMenuAsync(It.IsAny<int>())).Returns(this.GetMenuAsync());          

            var pizzeriaService = new PizzeriaService(_menuService.Object, _orderService.Object);

            var result = await pizzeriaService.GetPizzaMenusAsync(1);

            Assert.True(result.isSuccess);
            Assert.True(result.pizzaMenus.Count() == 3);
        }

        [Fact]
        public async void GetMultiplePizzaMenus()
        {
            _menuService.Setup(m => m.GetMenuAsync(It.IsAny<int>())).Returns(this.GetMenuAsync());

            _orderService.Setup(m => m.CreateOrderAsync(It.IsAny<Order>())).Returns(this.CreateOrderAsync());

            var order = new PizzaOrder
            {
                LocationId = 1,
                OrderDate = DateTime.Now,
                CustomerId = 1,
                Items = new List<LocationMenu> { new LocationMenu { Quantity = 1, Id = 1 }
                }
            };

            var pizzeriaService = new PizzeriaService(_menuService.Object, _orderService.Object);

            var result = await pizzeriaService.CreatePizzaOrderAsync(order);

            Assert.True(result.isSuccess);
            Assert.True(result.totalAmount == 25);
        }

        private async Task<(bool isSuccess, IEnumerable<LocationMenu> menus, string errorMessage)> GetMenuAsync()
        {
            var locationMenus = new List<LocationMenu>{ new LocationMenu()
            {
                Id = 1,
                Price = 20,
            }, new LocationMenu()
            {
                Id = 2,
                Price = 18,
            }, new LocationMenu()
            {
                Id = 3,
                Price = 18
            }};
            return (true, locationMenus, null);
        }

        private async Task<(bool isSuccess, decimal total, string errorMessage)> CreateOrderAsync()
        {
            return (true, 25, null);
        }
    }
}