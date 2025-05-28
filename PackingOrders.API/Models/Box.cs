namespace PackingOrders.API.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}
