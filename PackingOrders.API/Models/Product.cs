namespace PackingOrders.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public int Volume => Height * Width * Length;

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
