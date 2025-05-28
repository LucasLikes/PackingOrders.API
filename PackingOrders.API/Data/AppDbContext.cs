using Microsoft.EntityFrameworkCore;
using PackingOrders.API.Models;

namespace PackingOrders.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Box> Boxes { get; set; }
    }
}
