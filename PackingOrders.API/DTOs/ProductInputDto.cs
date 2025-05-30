namespace PackingOrders.API.DTOs
{
    public class ProductInputDto
    {
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}
