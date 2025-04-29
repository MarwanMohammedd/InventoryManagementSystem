using InventoryManagmentSystem.Shared.Repository.ProductRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository Product { get; }
    public ITransactionRepository Transaction { get;}
    Task StartTransactionAsync();
    Task RollBackAsync();
    Task CommitAsync();
    Task SaveAsync();
}