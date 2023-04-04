using CWRETAIL.Api.Pizzerias.Interfaces;
using CWRETAIL.Api.Pizzerias.Models;

namespace CWRETAIL.Api.Pizzerias.Services
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IMenuService _menusService;
        private readonly IOrderService _orderService;

        public PizzeriaService(IMenuService menusService, IOrderService orderService)
        {
            _menusService = menusService;
            _orderService = orderService;
        }

        public async Task<(bool isSuccess, decimal totalAmount)> CreatePizzaOrderAsync(PizzaOrder pizzaOrder)
        {
            decimal totalAmount = 0;
            Order order= new Order();
            if (pizzaOrder != null && pizzaOrder.CustomerId > 0 && pizzaOrder.LocationId > 0 && pizzaOrder.Items != null && pizzaOrder.Items.Any())
            {
                order.OrderDate = DateTime.Now;
                order.LocationId = pizzaOrder.LocationId;
                order.Items = new List<OrderItem>();
                var menuResults= await _menusService.GetMenuAsync(pizzaOrder.LocationId);
               
                if (menuResults.isSuccess)
                {
                    foreach (var item in pizzaOrder.Items)
                    {
                        var menu = menuResults.menus?.FirstOrDefault(i => i.Id == item.locationMenuId);
                        if (menu != null)
                        {
                            order.Items.Add(new OrderItem
                            {
                                Quantity = item.Quantity,
                                UnitPrice = menu.Price
                            });    
                        }
                    }
                }
                var orderResult= await _orderService.CreateOrderAsync(order);
                totalAmount = orderResult.totalAmount;
            }
            return (true, totalAmount);
        }
    }
}
