namespace InventoryManagmentSystem.Shared.APIResult;

public class APIResponse<T> where T : class
{
    public T Data { get; set; } = null!;
}