using CWRETAIL.Api.Pizzerias.Models;

namespace CWRETAIL.Api.Pizzerias.Interfaces
{
    public interface IMenuService
    {
        Task<(bool isSuccess, IEnumerable<LocationMenu> menus, string errorMessage)> GetMenuAsync(int id);
    }
}
