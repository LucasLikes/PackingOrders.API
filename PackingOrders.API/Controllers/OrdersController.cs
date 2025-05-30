using Microsoft.AspNetCore.Mvc;
using PackingOrders.API.Models;
using PackingOrders.API.Data;
using PackingOrders.API.Services;
using PackingOrders.API.DTOs;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        [HttpPost("pack")]
        public async Task<IActionResult> ProcessOrders([FromBody] List<OrderInputDto> ordersDto)
        {
            if (ordersDto == null || !ordersDto.Any())
                return BadRequest("Nenhum pedido recebido.");

            // Converter os DTOs para modelos de domínio Order e Product
            var orders = ordersDto.Select(dto => new Order
            {
                OrderCode = dto.OrderCode,
                Products = dto.Products.Select(p => new Product
                {
                    Name = p.Name,
                    Height = p.Height,
                    Width = p.Width,
                    Length = p.Length
                }).ToList()
            }).ToList();

            // Adicionar os pedidos no contexto para salvar no banco
            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
            await _context.SaveChangesAsync();

            // Processar cada pedido e empacotar
            var results = new List<object>();
            foreach (var order in orders)
            {
                var packedBoxes = await _packingService.PackOrderAsync(order);
                results.Add(new
                {
                    OrderCode = order.OrderCode,
                    PackedBoxes = packedBoxes
                });
            }

            return Ok(results);
        }
    }
}
