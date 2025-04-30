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
        // var lowStockThresholdProducts = await applicationDBContext.Products.Where(product => product.LowStockThreshold > product.Quantity).ToListAsync();
        // return lowStockThresholdProducts;
        IEnumerable<Product> products = new List<Product>();
        return products;
    }

    public bool GetTotalQuantityForProduct(int productId, out int result)
    {
        Product? product = applicationDBContext.Products.Include(p => p.Inventories).FirstOrDefault(p => p.Id == productId);
        if (product is not null)
        {
            result = product!.Inventories!.Sum(element => element.Quantity);
            return true;
        }
        result = -1;
        return false;
    }

    public bool RemoveProductFromInventory(int productId)
    {
        var product = applicationDBContext.Products.Include(p => p.Inventories).FirstOrDefault(p => p.Id == productId);

        if (product is not null)
        {
            applicationDBContext.Products.Remove(product);
            return true;
        }
        return false;
    }

    public IEnumerable<Product> GetAllProductDetials()
    {
        return applicationDBContext.Products.Include(p=>p.Inventories)!.ThenInclude(i=>i.Warehouse).ToList();
    }

}