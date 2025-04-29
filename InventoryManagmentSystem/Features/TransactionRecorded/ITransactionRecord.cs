namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;
public interface ITransactionRecord
{
    public Task Record(string UserName , int Quantity , string TransactionType);
}