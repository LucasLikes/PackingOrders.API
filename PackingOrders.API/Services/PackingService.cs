using PackingOrders.API.Models;
using PackingOrders.API.Models.PackingOrders.API.Models;

namespace PackingOrders.API.Services
{
    public class PackingService : IPackingService
    {
        private readonly List<Box> _availableBoxes;

        public PackingService()
        {
            _availableBoxes = new List<Box>
        {
            new Box { Type = "Caixa 1", Height = 30, Width = 40, Length = 80 },
            new Box { Type = "Caixa 2", Height = 80, Width = 50, Length = 40 },
            new Box { Type = "Caixa 3", Height = 50, Width = 80, Length = 60 }
        };
        }

        public Task<List<PackedBox>> PackOrderAsync(Order order)
        {
            // TODO: lógica para empacotar produtos e retornar quais produtos vão em cada caixa
            throw new NotImplementedException();
        }
    }

}
