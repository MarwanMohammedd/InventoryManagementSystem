using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;
public class TransactionHistoryHandler : IRequestHandler<TransactionHistoryRequest, Result<TransactionHistoryResponse>>
{
    public async Task<Result<TransactionHistoryResponse>> Handle(TransactionHistoryRequest request, CancellationToken cancellationToken)
    {
        
    }
}