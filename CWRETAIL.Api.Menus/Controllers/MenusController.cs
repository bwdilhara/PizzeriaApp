using CWRETAIL.Api.Menus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CWRETAIL.Api.Menus.Controllers
{
    [ApiController]
    [Route("api/menus")]
    public class MenusController:ControllerBase
    {
        private readonly IMenusProvider _menusProvider;      

        public MenusController(IMenusProvider menusProvider)
        {
            _menusProvider = menusProvider;
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetMenusAsync(int locationId)
        {
            var all = await _menusProvider.GetLocationMenusAsync(locationId);
            if (all.isSuccess)
            {
                return Ok(all.menus.ToList());
            }
            return NotFound(all.errorMessage);
        }
    }
}
