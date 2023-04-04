using CWRETAIL.Api.Orders.Models;

namespace CWRETAIL.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool isSuccess, IEnumerable<Models.Order> orders, string errorMessage)> GetOrdersAsync(int id);
        Task<(bool isSuccess, decimal totalAmount, string errorMessage)> CreateOrdersAsync(Models.Order order);
        
    }
}
