using System.Collections.Generic;
using System.Linq;

namespace PackingOrders.API.Models
{
    public class PackedBox
    {
        public Box Box { get; set; }
        public List<Product> Products { get; set; } = new();

        public double UsedVolume => Products.Sum(p => p.Volume);
        public double RemainingVolume => Box.Volume - UsedVolume;

        public bool CanFit(Product product)
        {
            return product.Volume <= RemainingVolume;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
