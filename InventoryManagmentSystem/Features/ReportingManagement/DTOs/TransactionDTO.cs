namespace InventoryManagmentSystem.Features.ReportingManagement.DTOs;

public class TransactionDTO
{
    public int WareHouseId { get; set; }
    public string WareHouseName { get; set; } = null!;
    public int Quantity { get; set; }
}