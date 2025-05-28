namespace PackingOrders.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public List<Product> Products { get; set; }
    }
}
