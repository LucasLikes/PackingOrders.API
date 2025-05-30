using PackingOrders.API.Models;

namespace PackingOrders.API.Services
{
    public interface IPackingService
    {
        Task<List<PackedBox>> PackOrderAsync(Order order);
    }

}
