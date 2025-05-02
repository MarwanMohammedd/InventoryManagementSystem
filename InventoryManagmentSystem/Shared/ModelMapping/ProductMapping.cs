using InventoryManagmentSystem.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagmentSystem.Shared.ModelMapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Apple",
                Description = "Fresh red apple",
                Price = 0.99m,
                LowStockThreshold = 10,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Banana",
                Description = "Ripe yellow bananas",
                Price = 1.20m,
                LowStockThreshold = 12,
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Rice 1kg",
                Description = "Premium basmati rice",
                Price = 3.49m,
                LowStockThreshold = 15,
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Name = "LED Bulb",
                Description = "10W LED white light",
                Price = 2.50m,
                LowStockThreshold = 6,
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Name = "Electric Kettle",
                Description = "1.5L stainless steel",
                Price = 25.00m,
                LowStockThreshold = 4,
                CategoryId = 2
            },
            new Product
            {
                Id = 6,
                Name = "Extension Cord",
                Description = "3m long 4-socket",
                Price = 7.99m,
                LowStockThreshold = 5,
                CategoryId = 2
            },
            new Product
            {
                Id = 7,
                Name = "Bluetooth Speaker",
                Description = "Portable wireless speaker",
                Price = 18.75m,
                LowStockThreshold = 3,
                CategoryId = 3
            },
            new Product
            {
                Id = 8,
                Name = "Smartphone Charger",
                Description = "Fast charging USB-C",
                Price = 9.99m,
                LowStockThreshold = 8,
                CategoryId = 3
            },
            new Product
            {
                Id = 9,
                Name = "HDMI Cable",
                Description = "2-meter high-speed HDMI",
                Price = 5.99m,
                LowStockThreshold = 10,
                CategoryId = 3
            },
            new Product
            {
                Id = 10,
                Name = "USB Flash Drive",
                Description = "32GB USB 3.0",
                Price = 6.49m,
                LowStockThreshold = 7,
                CategoryId = 3
            }
        );

    }
}
