using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Shared.Repository.TransactionRepository;
public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly ApplecationDBContext applicationDBContext;

    public TransactionRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public void BulkTransactionArchivedUpdate()
    {
        var oldTransactions = GetAllWithFilter(transaction => transaction.Date < DateTime.UtcNow.AddYears(-1));

        foreach (var transaction in oldTransactions)
        {
            transaction.IsArchived = true;
        }
        
        applicationDBContext.SaveChanges();
    }
}