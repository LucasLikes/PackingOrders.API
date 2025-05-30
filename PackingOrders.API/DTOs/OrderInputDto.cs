using System.Collections.Generic;

namespace PackingOrders.API.DTOs
{
    public class OrderInputDto
    {
        public string OrderCode { get; set; } = string.Empty;
        public List<ProductInputDto> Products { get; set; } = new();
    }
}