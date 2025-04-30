namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

public class InventoryDTO
{
    public int WareHouseId { get; set; }
    public string WareHouseName { get; set; } = null!;
    public int Quantity { get; set; }
}