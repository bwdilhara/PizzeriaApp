using CWRETAIL.Api.Orders.Db;
using CWRETAIL.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CWRETAIL.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrdersAsync(int id)
        //{
        //    var result = await ordersProvider.GetOrdersAsync(id);
        //    if (result.isSuccess)
        //    {
        //        return Ok(result.orders);
        //    }
        //    return NotFound();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateOrdersAsync(Models.Order order)
        {
            var result = await ordersProvider.CreateOrdersAsync(order);
            if (result.isSuccess)
            {
                return Ok(result.totalAmount);
            }
            return NotFound();
        }
    }
}
