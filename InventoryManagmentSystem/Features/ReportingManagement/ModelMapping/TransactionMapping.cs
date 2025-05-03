using InventoryManagmentSystem.Features.ReportingManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagmentSystem.Features.ReportingManagement.ModelMapping;

public class TransactionMapping : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.HasQueryFilter(transaction => transaction.IsArchived == false);
        builder.Property(property => property.Type).HasConversion<string>();
    }
}