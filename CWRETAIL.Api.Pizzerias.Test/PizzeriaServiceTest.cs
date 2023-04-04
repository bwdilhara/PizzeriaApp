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
        }
        

        //[Fact]
        //public async void CalculatTotalOrderAmonut()
        //{
        //    //var menusProvider = new PizzeriaService(_menuService.Object);

        //   var locationMenus = new List<LocationMenu>{ new LocationMenu()
        //    {
        //        Id = 1,
        //        Price = 20,
        //    }, new LocationMenu()
        //    {
        //        Id = 2,
        //        Price = 18,
        //    }, new LocationMenu()
        //    {                Id = 3,

        //        Price = 18
        //    }};
           
        //    _menuService.Setup(m => m.GetMenuAsync(It.IsAny<int>()))
        //    .ReturnsAsync((bool isSuccess, IEnumerable<LocationMenu> menus, string errorMessage) =>
        //     {
        //         return (true, locationMenus, null);
        //     });
        //    _orderService.Setup(m => m.CreateOrderAsync(It.IsAny<Order>()))
        //    .ReturnsAsync((bool isSuccess, decimal total, string errorMessage) =>
        //    {
        //        return (true, 25, null);
        //    });

        //    var order = new PizzaOrder
        //    {
        //        LocationId = 1,
        //        OrderDate = DateTime.Now,
        //        CustomerId= 1,
        //        Items = new List<PizzaOrderItem> { new PizzaOrderItem { Quantity = 1, locationMenuId = 1 }
        //        }
        //    };

        //    var pizzeriaService = new PizzeriaService(_menuService.Object, _orderService.Object);

        //    var result = await pizzeriaService.CreatePizzaOrderAsync(order);



        //}
    }
}