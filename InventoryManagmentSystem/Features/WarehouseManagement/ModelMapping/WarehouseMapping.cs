using InventoryManagmentSystem.Features.WarehouseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.WarehouseManagement.ModelMapping;

public class WarehouseMapping : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Warehouse> builder)
    {
        builder.HasData(
        new Warehouse
        {
            ID = 1,
            Name = "Central Warehouse",
            Location = "New York, NY"
        },
        new Warehouse
        {
            ID = 2,
            Name = "West Coast Warehouse",
            Location = "Los Angeles, CA"
        },
        new Warehouse
        {
            ID = 3,
            Name = "Midwest Warehouse",
            Location = "Chicago, IL"
        }
    );
    }
}