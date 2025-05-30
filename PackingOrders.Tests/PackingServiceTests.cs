using Xunit;
using PackingOrders.API.Services;
using PackingOrders.API.Models;
using System.Collections.Generic;

namespace PackingOrders.Tests
{
    public class PackingServiceTests
    {
        [Fact]
        public async Task DeveEmpacotarPedidoEmCaixaCorreta()
        {
            // Arrange
            var service = new PackingService();
            var pedido = new Order
            {
                Products = new List<Product>
        {
            new Product { Height = 30, Width = 30, Length = 30 }
        }
            };

            // Act
            var resultado = await service.PackOrderAsync(pedido);

            // Assert
            Assert.Single(resultado);
            Assert.Single(resultado[0].Products);
        }
    }
}
