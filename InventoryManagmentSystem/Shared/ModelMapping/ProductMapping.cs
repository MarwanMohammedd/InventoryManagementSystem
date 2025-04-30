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
            Name = "Wireless Mouse",
            Description = "A reliable wireless mouse with ergonomic design.",
            Price = 25.99m,
            LowStockThreshold = 10
        },
        new Product
        {
            Id = 2,
            Name = "Mechanical Keyboard",
            Description = "RGB mechanical keyboard with blue switches.",
            Price = 79.99m,
            LowStockThreshold = 5
        },
        new Product
        {
            Id = 3,
            Name = "USB-C Cable",
            Description = "Durable USB-C to USB-A charging cable.",
            Price = 9.99m,
            LowStockThreshold = 20
        }
    );
    }
}
