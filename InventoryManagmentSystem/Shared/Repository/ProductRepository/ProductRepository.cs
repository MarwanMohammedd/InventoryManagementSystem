using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Repository.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplecationDBContext applicationDBContext;

    public ProductRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public async Task<IEnumerable<Product>> GetLowStockThresholdProducts()
    {
        var lowStockThresholdProducts = await applicationDBContext.Products.Where(product => product.LowStockThreshold > product.Quantity).ToListAsync();
        return lowStockThresholdProducts;
    }
}