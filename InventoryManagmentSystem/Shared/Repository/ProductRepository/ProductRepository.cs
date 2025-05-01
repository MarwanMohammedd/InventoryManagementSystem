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
}