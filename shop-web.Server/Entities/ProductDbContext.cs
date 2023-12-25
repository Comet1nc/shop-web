using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace shop_web.Server.Entities
{
    public class ProductDbContext : DbContext
    {
        private string _connetctionString =
            "Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProducts> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .Property(u => u.Email)
                 .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Name)
                 .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithMany(p => p.Users)
                .UsingEntity<UserProducts>(
                    j => j.HasOne(e => e.Product).WithMany(e => e.UserProducts).HasForeignKey(e => e.ProductsId).HasPrincipalKey(e => e.Id),
                    j => j.HasOne(e => e.User).WithMany(e => e.UserProducts).HasForeignKey(e => e.UsersId).HasPrincipalKey(e => e.Id),
                    j => j.HasKey("UsersId", "ProductsId")
                );


            modelBuilder.Entity<Product>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(t => t.Price)
                .IsRequired();
            
            modelBuilder.Entity<Product>().HasData(
                    [
                        new Product()
                        {
                            Id = 1,
                            Price = 999,
                            Name = "iPhone 14",
                            Description = "Смартфон от компании Apple, 128 GB памяти. Цвет черный.",
                            Count = 5
                        },
                        new Product()
                        {
                            Id = 2,
                            Price = 1099,
                            Name = "iPhone 14 Pro",
                            Description = "Смартфон от компании Apple, 512 GB памяти. Цвет серый.",
                            Count = 5
                        },
                        new Product()
                        {
                            Id = 3,
                            Price = 1399,
                            Name = "MacBook Pro 2022",
                            Description = "Ноубук от компании Apple, 1 TB памяти. Цвет серебристый.",
                            Count = 5
                        },
                        new Product()
                        {
                            Id = 4,
                            Price = 699,
                            Name = "Mac Mini",
                            Description = "Компьютер от компании Apple, 512 GB памяти. Цвет серебристый.",
                            Count = 5
                        }
                    ]
                    
                );

            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 1,
                        Email = "abc@abc",
                        Name = "Alex",
                        Password = "admin123"
                    }
                );
            
        }
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connetctionString);
        }
    }
}
