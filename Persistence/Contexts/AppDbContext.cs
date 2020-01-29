using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Auth;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Highscore> Highscores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasKey(ur => new {ur.UserId, ur.RoleId});

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category {Id = 100, Name = "Fruits and Vegetables"}, // Id set manually due to in-memory provider
                new Category {Id = 101, Name = "Dairy"}
            );

            builder.Entity<Highscore>().ToTable("Highscores");
            builder.Entity<Highscore>().HasKey(hs => hs.Id);
            builder.Entity<Highscore>().Property(hs => hs.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Highscore>().Property(hs => hs.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Highscore>().Property(hs => hs.HighScore).IsRequired();
            builder.Entity<Highscore>().Property(hs => hs.Resolution).IsRequired().HasMaxLength(9);

            builder.Entity<Highscore>().HasData
            (
                new Highscore
                {
                    Id = 69,
                    Name = "Knauser",
                    HighScore = 420,
                    Resolution = "3840,2160"
                },
                new Highscore
                {
                    Id = 420,
                    Name = "Knauser",
                    HighScore = 69,
                    Resolution = "3840,2160"
                }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );
        }
    }
}