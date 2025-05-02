using System.Linq.Expressions;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.SpeceficationPattern;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Shared.Repository.TransactionRepository;
public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly ApplecationDBContext applicationDBContext;

    public TransactionRepository(ApplecationDBContext applicationDBContext) : base(applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public async Task BulkTransactionArchivedUpdate()
    {
        var oldTransactions = GetAllWithFilter(transaction => transaction.Date < DateTime.UtcNow.AddYears(-1)).ToList();
        
        foreach (var transaction in oldTransactions)
        {
            transaction.IsArchived = true;
        }
        
        await applicationDBContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetBySpecification(ISpecification<Transaction> specification)
    {
            

        return  await applicationDBContext.Transactions.AsQueryable().Where(specification.Criteria).ToListAsync();
    }
}