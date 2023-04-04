using CWRETAIL.Api.Pizzerias.Models;

namespace CWRETAIL.Api.Pizzerias.Interfaces
{
    public interface IOrderService
    {
        Task<(bool isSuccess, decimal totalAmount, string errorMessage)> CreateOrderAsync(Order order);
    }
}
