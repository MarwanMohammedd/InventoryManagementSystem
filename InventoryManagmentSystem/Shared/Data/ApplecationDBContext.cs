using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.ModelMapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Data;

public class ApplecationDBContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplecationDBContext(DbContextOptions<ApplecationDBContext> options) : base(options)
    {

    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "Product A", Description = "Description A", Quantity = 100, Price = 10.99m, LowStockThreshold = 10 },
        new Product { ProductId = 2, Name = "Product B", Description = "Description B", Quantity = 150, Price = 15.49m, LowStockThreshold = 15 },
        new Product { ProductId = 3, Name = "Product C", Description = "Description C", Quantity = 200, Price = 8.99m, LowStockThreshold = 20 },
        new Product { ProductId = 4, Name = "Product D", Description = "Description D", Quantity = 80, Price = 12.99m, LowStockThreshold = 8 },
        new Product { ProductId = 5, Name = "Product E", Description = "Description E", Quantity = 120, Price = 5.99m, LowStockThreshold = 12 },
        new Product { ProductId = 6, Name = "Product F", Description = "Description F", Quantity = 300, Price = 20.00m, LowStockThreshold = 25 },
        new Product { ProductId = 7, Name = "Product G", Description = "Description G", Quantity = 50, Price = 7.50m, LowStockThreshold = 5 },
        new Product { ProductId = 8, Name = "Product H", Description = "Description H", Quantity = 60, Price = 11.25m, LowStockThreshold = 6 },
        new Product { ProductId = 9, Name = "Product I", Description = "Description I", Quantity = 90, Price = 9.95m, LowStockThreshold = 9 },
        new Product { ProductId = 10, Name = "Product J", Description = "Description J", Quantity = 70, Price = 14.75m, LowStockThreshold = 7 });
    }
}