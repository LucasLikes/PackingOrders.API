namespace PackingOrders.API.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public int Volume => Height * Width * Length;
    }
}
