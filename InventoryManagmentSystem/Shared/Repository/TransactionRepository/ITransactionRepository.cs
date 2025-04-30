using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.TransactionRepository;


public interface ITransactionRepository : IGenericRepository<Transaction>
{
    void BulkTransactionArchivedUpdate();
}