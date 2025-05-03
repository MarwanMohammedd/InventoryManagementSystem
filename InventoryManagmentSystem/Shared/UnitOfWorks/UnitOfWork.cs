using InventoryManagmentSystem.Features.CategoryManagement.Repository;
using InventoryManagmentSystem.Features.InventoryTransactions.Repository;
using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Features.ReportingManagement.Repository;
using InventoryManagmentSystem.Features.WarehouseManagement.Repository;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;

namespace InventoryManagmentSystem.Shared.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplecationDBContext applicationDBContext;

    private IProductRepository _product;
    public IProductRepository Product
    {
        get
        {
            if (_product is null)
            {
                _product = new ProductRepository(applicationDBContext);
            }
            return _product;
        }
    }

    private ICategoryRepository _category;
    public ICategoryRepository Category
    {
        get
        {
            if (_category is null)
            {
                _category = new CategoryRepository(applicationDBContext);
            }
            return _category;
        }
    }

    private IWarehouseRepository _warehouse;
    public IWarehouseRepository Warehouse
    {
        get
        {
            if (_warehouse is null)
            {
                _warehouse = new WarehouseRepository(applicationDBContext);
            }
            return _warehouse;
        }
    }

    private ITransactionRepository _transaction;

    public ITransactionRepository Transaction
    {
        get
        {
            if (_transaction is null)
            {
                _transaction = new TransactionRepository(applicationDBContext);
            }
            return _transaction;
        }
    }

    private IInventoryRepository _inventory;
    public IInventoryRepository Inventory
    {
        get
        {
            if (_inventory is null)
            {
                _inventory = new InventoryRepository(applicationDBContext);
            }
            return _inventory;
        }
    }

    public UnitOfWork(ApplecationDBContext applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public async Task BeginTransactionAsync()
    {
        await applicationDBContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await applicationDBContext.Database.CommitTransactionAsync();
    }

    public void Dispose()
    {
        applicationDBContext.Dispose();
    }

    public async Task RollbackAsync()
    {
        await applicationDBContext.Database.RollbackTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await applicationDBContext.SaveChangesAsync();
    }
}