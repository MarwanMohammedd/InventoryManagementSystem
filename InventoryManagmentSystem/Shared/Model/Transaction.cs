namespace InventoryManagmentSystem.Shared.Model;

public class Transaction
{
    public int TransactionId { get; set; }
    public string ProductName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string TransactionType { get; set; } = null!;
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public bool IsArchived { get; set; } = false;

}