using InventoryManagmentSystem.Shared.Utilities;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;

public class TransactionHistoryDTO
{
    public int? ProductId { get; set; }
    public string? ProductCategory { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}