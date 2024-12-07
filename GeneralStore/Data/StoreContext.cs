using Microsoft.EntityFrameworkCore;
using GeneralStore.Models;
namespace GeneralStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    Name = "Hardwood Desk",
                    Description = "A nice hardwood desk",
                    Price = 150.00m,
                    Weight = 0.0m,
                    Category = "Furniture",
                    InStock = true,
                    StockQuantity = 10,
                    DateListed = DateTime.Now
                },
                new Item
                {
                    ItemId = 2,
                    Name = "Hardwood Chair",
                    Description = "Chair made of wood.",
                    Price = 20.00m,
                    Weight = 0.0m,
                    Category = "Furniture",
                    InStock = true,
                    StockQuantity = 10,
                    DateListed = DateTime.Now
                },
                new Item
                {
                    ItemId = 3,
                    Name = "Steel Lamp",
                    Description = "Lamp Of Steel",
                    Price = 100.00m,
                    Weight = 0.0m,
                    Category = "Lighting",
                    InStock = true,
                    StockQuantity = 10,
                    DateListed = DateTime.Now
                },
                new Item
                {
                    ItemId = 4,
                    Name = "Power Drill",
                    Description = "Basic Power Drill",
                    Price = 150.00m,
                    Weight = 0.0m,
                    Category = "Tools",
                    InStock = true,
                    StockQuantity = 10,
                    DateListed = DateTime.Now
                }
            );
        }
    }
}