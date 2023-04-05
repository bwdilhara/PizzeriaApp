using CWRETAIL.Api.Pizzerias.Models;

namespace CWRETAIL.Api.Pizzerias.Interfaces
{
    public interface IPizzeriaService
    {
        Task<(bool isSuccess, decimal totalAmount)> CreatePizzaOrderAsync(PizzaOrder pizzaOrder);
        Task<(bool isSuccess, IEnumerable<LocationMenu> pizzaMenus)> GetPizzaMenusAsync(int locationId);
    }
}
