using InventoryManagmentSystem.Shared.Utilities;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;

public class TransactionHistoryDTO
{
    public string? ProductName { get; set; }
    public string? ProductCategory { get; set; }
    public TransactionType? TransactionType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}