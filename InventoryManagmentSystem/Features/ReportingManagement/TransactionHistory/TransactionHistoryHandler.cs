using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;
public class TransactionHistoryHandler : IRequestHandler<TransactionHistoryRequest, Result<TransactionHistoryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionHistoryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<TransactionHistoryResponse>> Handle(TransactionHistoryRequest request, CancellationToken cancellationToken)
    {

        TransactionHistorySpecification spec = new TransactionHistorySpecification
        (
           toDate: request.ToDate,
           fromDate: request.FromDate,
           productCategory: request.ProductCategory,
           productName: request.ProductName,
           transactionType: request.TransactionType
        );

        IEnumerable<Transaction> transactions = await unitOfWork.Transaction.GetBySpecification(spec);
        if (transactions is not null)
        {
            TransactionHistoryResponse transactionHistoryResponse = new()
            {
                Transactions = transactions
            };
            return Result<TransactionHistoryResponse>.Success(transactionHistoryResponse);
        }
        return Result<TransactionHistoryResponse>.Failure("There Is Data Retrived!");
    }
}