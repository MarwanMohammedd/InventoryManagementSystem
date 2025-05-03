using InventoryManagmentSystem.Features.CategoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagmentSystem.Features.CategoryManagement.ModelMapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { CategoryId = 1, CategoryName = "Food" },
            new Category { CategoryId = 2, CategoryName = "Electric" },
            new Category { CategoryId = 3, CategoryName = "Electronics" }
        );

    }
}