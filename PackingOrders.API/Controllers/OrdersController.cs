using Microsoft.AspNetCore.Mvc;
using PackingOrders.API.Models;
using PackingOrders.API.Data;
using PackingOrders.API.Services;

namespace PackingOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPackingService _packingService;
        private readonly AppDbContext _context;

        public OrdersController(IPackingService packingService, AppDbContext context)
        {
            _packingService = packingService;
            _context = context;
        }

        [HttpPost("pack")]
        public async Task<IActionResult> ProcessOrder([FromBody] Order order)
        {
            if (order.Products != null)
            {
                foreach (var product in order.Products)
                {
                    product.Order = order; // Relacionamento manual
                }
            }

            _context.Orders.Add(order); // Salva a ordem com os produtos
            await _context.SaveChangesAsync();

            var result = await _packingService.PackOrderAsync(order);
            return Ok(result);
        }
    }
}
