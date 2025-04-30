using InventoryManagmentSystem.Shared.Repository.InventoryRepository;
using InventoryManagmentSystem.Shared.Repository.ProductRepository;
using InventoryManagmentSystem.Shared.Repository.TransactionRepository;
using InventoryManagmentSystem.Shared.Repository.WarehouseRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository Product { get; }
    public ITransactionRepository Transaction { get; }
    public IInventoryRepository Inventory { get; }
    public IWarehouseRepository Warehouse { get; }
    Task StartTransactionAsync();
    Task RollBackAsync();
    Task CommitAsync();
    Task SaveAsync();
}