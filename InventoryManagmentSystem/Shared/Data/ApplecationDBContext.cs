using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Data;

public class ApplecationDBContext : DbContext
{
    public ApplecationDBContext(DbContextOptions<ApplecationDBContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}