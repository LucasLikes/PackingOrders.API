using PackingOrders.API.Models;
using PackingOrders.API.Models.PackingOrders.API.Models;

namespace PackingOrders.API.Services
{
    public interface IPackingService
    {
        Task<List<PackedBox>> PackOrderAsync(Order order);
    }

}
