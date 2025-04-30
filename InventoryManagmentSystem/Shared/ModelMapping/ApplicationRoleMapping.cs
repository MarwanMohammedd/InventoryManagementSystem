using InventoryManagmentSystem.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagmentSystem.Shared.ModelMapping;

public class ApplicationRoleMapping : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(
            new ApplicationRole(){ Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new ApplicationRole(){ Id = 2, Name = "User", NormalizedName = "USER" }
        );
    }
}