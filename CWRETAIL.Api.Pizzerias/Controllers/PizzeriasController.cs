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

        [HttpPost]
        public async Task<IActionResult> SearchAsync(PizzaOrder pizzaOrder)
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
