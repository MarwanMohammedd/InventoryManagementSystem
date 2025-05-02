namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

public class InventoryDTO
{
    public int WareHouseId { get; set; }
    public string WareHouseName { get; set; } = null!;
    public int Quantity { get; set; }
}