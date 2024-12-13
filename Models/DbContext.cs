using Microsoft.EntityFrameworkCore;

namespace krogercart.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }

        // Configure composite primary key for ProductCart entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCart>().HasKey(pc => new { pc.CartID, pc.ProductID });
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; } = default!;
        public DbSet<ProductCart> ProductCarts { get; set; } = default!;
    }
}