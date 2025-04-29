using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}