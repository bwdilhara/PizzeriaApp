using CWRETAIL.Api.Menus.Models;

namespace CWRETAIL.Api.Menus.Interfaces
{
    public interface IMenusProvider
    {
        Task<(bool isSuccess, IEnumerable<Menu> menus, string errorMessage)> GetMenusAsync();
        Task<(bool isSuccess, IEnumerable<Models.LocationMenu> menus, string errorMessage)> GetLocationMenusAsync(int locationId);
    }
}
