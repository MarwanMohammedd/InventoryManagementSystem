using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;
public class TransactionHistoryRequest : IRequest<Result<TransactionHistoryResponse>>
{
    public int? ProductId { get; set; }
    public string? ProductCategory { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}