using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Features.ReportingManagement.Specifications;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.TransactionHistory;
public class TransactionHistoryHandler : IRequestHandler<TransactionHistoryQuaryRequest, Result<IEnumerable<TransactionHistoryQuaryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionHistoryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<TransactionHistoryQuaryResponse>>> Handle(TransactionHistoryQuaryRequest request, CancellationToken cancellationToken)
    {
        TransactionHistorySpecification spec = new TransactionHistorySpecification
        (
           toDate: request.ToDate,
           fromDate: request.FromDate,
           productCategory: request.ProductCategory,
           productId: request.ProductId,
           transactionType: request.TransactionType
        );

        IEnumerable<TransactionEntity> transactions = await unitOfWork.Transaction.GetBySpecification(spec);
        if (transactions.Count() != 0)
        {
            IEnumerable<TransactionHistoryQuaryResponse> transactionHistoryResponse = transactions
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(t => new TransactionHistoryQuaryResponse
            {
                TransationId = t.Id,
                Type = t.Type,
                Date = t.Date,
                FromWarehouseId = t.FromWarehouseId,
                ToWarehouseId = t.ToWarehouseId,
                ProductId = t.Id,
                UserId = t.UserId,
                ProductCategory = t.ProductCategory,
                TotalPage = (int)Math.Ceiling((decimal)transactions.Count() / request.PageSize)
            });
            return Result<IEnumerable<TransactionHistoryQuaryResponse>>.Success(transactionHistoryResponse);
        }
        return Result<IEnumerable<TransactionHistoryQuaryResponse>>.Failure("There Is No Data Retived");

    }
}