using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;
using InventoryManagmentSystem.Shared.Repository.ProductRepository;
using InventoryManagmentSystem.Shared.Repository.TransactionRepository;
using InventoryManagmentSystem.Shared.Repository.WarehouseRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplecationDBContext applicationDBContext;

    public IProductRepository Product { get; private set; }

    public ITransactionRepository Transaction { get; private set; }

    public IInventoryRepository Inventory { get; private set; }

    public IWarehouseRepository Warehouse { get; private set; }

    public ICategoryRepository Category { get; private set; }

    public UnitOfWork(ApplecationDBContext applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
        Product = new ProductRepository(this.applicationDBContext);
        Transaction = new TransactionRepository(this.applicationDBContext);
        Inventory = new InventoryRepository(this.applicationDBContext);
        Warehouse = new WarehouseRepository(this.applicationDBContext);
        Category = new CategoryRepository(this.applicationDBContext);
    }

    public async Task CommitAsync()
    {
        await applicationDBContext.Database.CommitTransactionAsync();
    }

    public void Dispose()
    {
        applicationDBContext.Dispose();
    }

    public async Task RollBackAsync()
    {
        await applicationDBContext.Database.RollbackTransactionAsync();
    }

    public async Task SaveAsync()
    {
        await applicationDBContext.SaveChangesAsync();
    }

    public async Task StartTransactionAsync()
    {
        await applicationDBContext.Database.BeginTransactionAsync();
    }
}