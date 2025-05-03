using InventoryManagmentSystem.Features.InventoryTransactions.Repository;
using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Features.ReportingManagement.Repository;
using InventoryManagmentSystem.Features.WarehouseManagement.Repository;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository Product { get;}
    public ICategoryRepository Category { get;}
    public IWarehouseRepository Warehouse { get; }
    public ITransactionRepository Transaction { get; }
    public IInventoryRepository Inventory { get;}
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}