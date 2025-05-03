using InventoryManagmentSystem.Features.AccountManagement.ModelMapping;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.CategoryManagement.ModelMapping;
using InventoryManagmentSystem.Features.InventoryTransactions.ModelMapping;
using InventoryManagmentSystem.Features.InventoryTransactions.Models;
using InventoryManagmentSystem.Features.ProductManagement.ModelMapping;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.ReportingManagement.ModelMapping;
using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Features.WarehouseManagement.ModelMapping;
using InventoryManagmentSystem.Features.WarehouseManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Data;

public class ApplecationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> inventories { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public ApplecationDBContext(DbContextOptions<ApplecationDBContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine);
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ApplicationRoleMapping());
        modelBuilder.ApplyConfiguration(new CategoryMapping());
        modelBuilder.ApplyConfiguration(new TransactionMapping());
        modelBuilder.ApplyConfiguration(new WarehouseMapping());
        modelBuilder.ApplyConfiguration(new InventoryMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());

    }
}