using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Shared.Utilities;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.TransactionHistory;

public class TransactionHistoryQuaryResponse
{
    public int TransationId { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public int ProductId { get; set; }
    public int? FromWarehouseId { get; set; }
    public int? ToWarehouseId { get; set; }
    public string ProductCategory { get; set; } = null!;
    public int UserId { get; set; }
    public int TotalPage { get; set; }
}