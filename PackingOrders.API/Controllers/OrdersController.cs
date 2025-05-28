using Microsoft.AspNetCore.Mvc;
using PackingOrders.API.Models;
using PackingOrders.API.Services;

namespace PackingOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPackingService _packingService;

        public OrdersController(IPackingService packingService)
        {
            _packingService = packingService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder([FromBody] Order order)
        {
            var result = await _packingService.PackOrderAsync(order);
            return Ok(result);
        }
    }
}
