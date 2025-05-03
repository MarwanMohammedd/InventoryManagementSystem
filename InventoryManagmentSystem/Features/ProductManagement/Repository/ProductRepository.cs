using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplecationDBContext applicationDBContext;

    public ProductRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public async Task<IEnumerable<string>> GetProductsNameWithLowStock()
    {
        IEnumerable<string> products = await applicationDBContext
        .Products
        .Include(p => p.Inventories)
        .Where(element=>element.Inventories.Sum(i=>i.Quantity) < element.LowStockThreshold)
        .Select(element=>element.Name).ToListAsync();
        return products;    
        
        }
}