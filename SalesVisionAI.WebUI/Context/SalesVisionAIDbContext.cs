using Microsoft.EntityFrameworkCore;
using SalesVisionAI.WebUI.Entities;

namespace SalesVisionAI.WebUI.Context
{
    public class SalesVisionAIDbContext : DbContext
    {
        public SalesVisionAIDbContext(DbContextOptions<SalesVisionAIDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
