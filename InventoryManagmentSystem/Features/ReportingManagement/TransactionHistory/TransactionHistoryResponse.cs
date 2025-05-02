using InventoryManagmentSystem.Shared.Model;

namespace InventoryManagmentSystem.Features.ReportingManagement.TransactionHistory;

public class TransactionHistoryResponse
{
    public IEnumerable<Transaction> Transactions { get; set; } = null!;
}