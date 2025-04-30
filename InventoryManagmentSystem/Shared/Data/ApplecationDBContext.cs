using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.ModelMapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Data;

public class ApplecationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> inventories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public ApplecationDBContext(DbContextOptions<ApplecationDBContext> options) : base(options)
    {

    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ApplicationRoleMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new TransactionMapping());
        modelBuilder.ApplyConfiguration(new WarehouseMapping());
        modelBuilder.ApplyConfiguration(new InventoryMapping());

    }
}