namespace PackingOrders.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
