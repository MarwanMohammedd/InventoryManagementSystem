using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.TransactionHistory;
public class TransactionHistoryQuaryRequest : IRequest<Result<IEnumerable<TransactionHistoryQuaryResponse>>>
{
    public int? ProductId { get; set; }
    public string? ProductCategory { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}