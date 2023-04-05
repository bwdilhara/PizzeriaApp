using CWRETAIL.Api.Pizzerias.Interfaces;
using CWRETAIL.Api.Pizzerias.Models;
using Microsoft.AspNetCore.Mvc;

namespace CWRETAIL.Api.Pizzerias.Controllers
{
    [ApiController]
    [Route("api/Pizzerias")]
    public class PizzeriasController : ControllerBase
    {
        private readonly IPizzeriaService _pizzeriaService;

        public PizzeriasController(IPizzeriaService pizzeriaService)
        {
            _pizzeriaService = pizzeriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPizzaMenusAsync(string locationId)
        {
            int id = int.Parse(locationId);
            if (id > 0) {
                var result = await _pizzeriaService.GetPizzaMenusAsync(id);
                if (result.isSuccess)
                {
                    return Ok(result.pizzaMenus);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PizzaOrder>> CreatePizzaOrderAsync( PizzaOrder pizzaOrder)
        {
            var result = await _pizzeriaService.CreatePizzaOrderAsync(pizzaOrder);
            if (result.isSuccess)
            {
                return Ok(result.totalAmount);
            }
            return NotFound();
        }

    }
}
