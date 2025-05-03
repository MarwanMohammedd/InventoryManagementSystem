using System.Linq.Expressions;
using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Shared.Utilities;
using Microsoft.EntityFrameworkCore.Query;

namespace InventoryManagmentSystem.Features.ReportingManagement.Specifications;


public class TransactionHistorySpecification : ISpecification<TransactionEntity>
{
    public Expression<Func<TransactionEntity, bool>> Criteria { get; }

    public TransactionHistorySpecification(
        int? productId,
        string? productCategory,
        string? transactionType,
        DateTime? fromDate,
        DateTime? toDate)
    {
        TransactionType? parsedTransactionType = null;

        if (!string.IsNullOrEmpty(transactionType) && Enum.TryParse(transactionType, out TransactionType parsed))
        {
            parsedTransactionType = parsed;
        }

        Criteria = transactionObject =>
        (!fromDate.HasValue || transactionObject.Date >= fromDate) &&
        (!toDate.HasValue || transactionObject.Date <= toDate) &&
        (string.IsNullOrEmpty(productCategory) || transactionObject.Product!.Category!.CategoryName == productCategory) &&
        (!productId.HasValue || transactionObject.Product!.Id == productId) &&
        (!parsedTransactionType.HasValue || transactionObject.Type == parsedTransactionType);

    }


}