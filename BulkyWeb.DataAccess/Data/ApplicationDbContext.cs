using BulkyWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Define FK Relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade Delete if a Category is deleted
        }
    }
}
