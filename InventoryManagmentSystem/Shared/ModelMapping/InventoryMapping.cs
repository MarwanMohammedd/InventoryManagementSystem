using InventoryManagmentSystem.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagmentSystem.Shared.ModelMapping;

public class InventoryMapping : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(element => new { element.ProductId, element.WarehouseId });

        builder.HasOne(i => i.Product)
        .WithMany(p => p.Inventories)
        .HasForeignKey(i => i.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}