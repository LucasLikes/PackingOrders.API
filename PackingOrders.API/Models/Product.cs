namespace PackingOrders.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}
