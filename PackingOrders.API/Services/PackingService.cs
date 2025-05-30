using PackingOrders.API.Models;

namespace PackingOrders.API.Services
{
    public class PackingService : IPackingService
    {
        private readonly List<Box> _availableBoxes;

        public PackingService()
        {
            _availableBoxes = new List<Box>
            {
                new Box { Type = "Caixa 1", Height = 30, Width = 40, Length = 80 },
                new Box { Type = "Caixa 2", Height = 80, Width = 50, Length = 40 },
                new Box { Type = "Caixa 3", Height = 50, Width = 80, Length = 60 }
            };
        }

        public Task<List<PackedBox>> PackOrderAsync(Order order)
        {
            var packedBoxes = new List<PackedBox>();

            var sortedProducts = order.Products
                .OrderByDescending(p => p.Volume)
                .ToList();

            foreach (var product in sortedProducts)
            {
                var packed = false;

                foreach (var box in packedBoxes)
                {
                    if (box.CanFit(product))
                    {
                        box.AddProduct(product);
                        packed = true;
                        break;
                    }
                }

                if (!packed)
                {
                    var suitableBox = _availableBoxes
                        .OrderBy(b => b.Volume)
                        .FirstOrDefault(b =>
                            b.Height >= product.Height &&
                            b.Width >= product.Width &&
                            b.Length >= product.Length);

                    if (suitableBox == null)
                        throw new Exception($"Produto muito grande para ser embalado: {product.Height}x{product.Width}x{product.Length}");

                    var newPackedBox = new PackedBox
                    {
                        Box = suitableBox,
                        Products = new List<Product> { product }
                    };

                    packedBoxes.Add(newPackedBox);
                }
            }

            return Task.FromResult(packedBoxes);
        }
    }
}
