using System.Linq.Expressions;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.SpeceficationPattern;
using InventoryManagmentSystem.Shared.Utilities;
using Microsoft.EntityFrameworkCore.Query;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;


public class TransactionHistorySpecification : ISpecification<Transaction>
{
    public Expression<Func<Transaction, bool>> Criteria { get; }

    // public Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>> IncludedOperation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public TransactionHistorySpecification(
        string? productName,
        string? productCategory,
        TransactionType? transactionType,
        DateTime? fromDate,
        DateTime? toDate)
    {
        Criteria = transactionObject => 
        (!fromDate.HasValue || transactionObject.Date >= fromDate ) &&
        (!toDate.HasValue || transactionObject.Date <= toDate ) &&
        (string.IsNullOrEmpty(productCategory) || transactionObject.Date >= fromDate ) &&
        (string.IsNullOrEmpty(productName) || transactionObject.Product!.Name == productName ) &&
        (!transactionType.HasValue || transactionObject.Type ==  transactionType) ;
    }


}