using InventoryManagmentSystem.Shared.Utilities;

namespace InventoryManagmentSystem.Features.ReportingManagement.DTOs;

public class TransactionHistoryDTO
{
    public int? ProductId { get; set; }
    public string? ProductCategory { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}