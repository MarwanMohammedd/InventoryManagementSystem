using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.ProductRepository;
public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
    }
}