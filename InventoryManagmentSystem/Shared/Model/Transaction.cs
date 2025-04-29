namespace InventoryManagmentSystem.Shared.Model;

public class Transaction
{
    public string UserName { get; set; } = null!;
    public string TransactionType { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Quantity { get; set; } 
}