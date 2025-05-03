using System.Linq.Expressions;
using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Features.ReportingManagement.Specifications;
using InventoryManagmentSystem.Shared.Repository;

namespace InventoryManagmentSystem.Features.ReportingManagement.Repository;


public interface ITransactionRepository : IGenericRepository<TransactionEntity>
{

    Task BulkTransactionArchivedUpdate();

    Task<IEnumerable<TransactionEntity>> GetBySpecification(ISpecification<TransactionEntity> specification);

}