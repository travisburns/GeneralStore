using Microsoft.EntityFrameworkCore;
using GeneralStore.Models;
using System.Collections.Generic;

namespace GeneralStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

