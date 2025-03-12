using BulkyWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<UserAuthen> UserAuthens { get; set; }
        DbSet<UserAuthorize> UserAuthorizes { get; set; }
        DbSet<Authorization> Authorizations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define Many-to-One Relationship (Product <--> Category)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade Delete if a Category is deleted            
            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.UserAuthorize)
                .WithOne(a => a.UserInfo) // Ensure there is a corresponding navigation property in UserAuthorize
                .HasForeignKey(a => a.UserInfoId) // Ensure there is a foreign key in UserAuthorize
                .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior
            //modelBuilder.Entity<UserInfo>().Ignore(u => u.UserAuthorize);
            //// Many-to-Many Relationship: UserAuth <--> UserAuthorization
            modelBuilder.Entity<UserAuthorize>()
                .HasOne(ua => ua.UserInfo)
                .WithMany(u => u.UserAuthorize)
                .HasForeignKey(ua => ua.UserInfoId);

            //modelBuilder.Entity<UserAuthorize>()
            //    .HasOne(ua => ua.Authorization)
            //    .WithMany(a => a.UserAuthorizes)
            //    .HasForeignKey(ua => ua.AuthorizationId);
            ////// Define One-to-One Relationship (UserAuthen <--> UserInfo)
            //modelBuilder.Entity<UserAuthen>()
            //   .HasOne(p => p.UserInfo)
            //   .WithOne(c => c.UserAuthen)
            //   .HasForeignKey<UserInfo>(p => p.UserAuthenId)
            //   .OnDelete(DeleteBehavior.Cascade); // Cascade Delete if a Category is deleted

            // Auto-incrementing primary key
            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserAuthen>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserAuthorize>(
                x =>
                {
                    x.HasNoKey();
                });
            //modelBuilder.Entity<Authorization>()
            //    .Property(x => x.Id)
            //    .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserInfo>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
