namespace PackingOrders.API.Models
{
    namespace PackingOrders.API.Models
    {
        public class PackedBox
        {
            public string BoxType { get; set; } = string.Empty;
            public List<Product> Products { get; set; } = new();
        }
    }

}
