using InventoryManagmentSystem.Shared.Model;
namespace InventoryManagmentSystem.Shared.Repository.ProductRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetLowStockThresholdProducts();
    bool GetTotalQuantityForProduct(int productId, out int result);
    bool RemoveProductFromInventory(int productId);

    IEnumerable<Product> GetAllProductDetials();
}