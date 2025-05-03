using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Shared.Repository;
namespace InventoryManagmentSystem.Features.ProductManagement.Repository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<string>> GetProductsNameWithLowStock();
}