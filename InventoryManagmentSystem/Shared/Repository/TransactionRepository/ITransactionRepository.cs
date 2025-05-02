using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.SpeceficationPattern;

namespace InventoryManagmentSystem.Shared.Repository.TransactionRepository;


public interface ITransactionRepository : IGenericRepository<Transaction> 
{
    Task BulkTransactionArchivedUpdate();

    Task<IEnumerable<Transaction>> GetBySpecification(ISpecification<Transaction> specification);

}