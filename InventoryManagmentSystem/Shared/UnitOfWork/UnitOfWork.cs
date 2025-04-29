using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository.ProductRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplecationDBContext applicationDBContext;

    public IProductRepository Product { get; private set; }

    public UnitOfWork(ApplecationDBContext applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
        Product = new ProductRepository(this.applicationDBContext);
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