
using System.Linq;
using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Features.ReportingManagement.Specifications;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ReportingManagement.Repository;
public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
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

    public async Task<IEnumerable<TransactionEntity>> GetBySpecification(ISpecification<TransactionEntity> specification)
    {
        return  await applicationDBContext.Transactions.AsQueryable().Where(specification.Criteria).ToListAsync();
    }
}