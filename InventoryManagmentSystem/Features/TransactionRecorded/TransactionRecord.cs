using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;

namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

public class TransactionRecord : ITransactionRecord
{
    private readonly IUnitOfWork unitOfWork;

    public TransactionRecord(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task Record(string UserName, int Quantity,  string TransactionType)
    {
        var transaction = new Transaction() 
        { UserName = UserName, Date = DateTime.UtcNow, TransactionType = TransactionType, Quantity = Quantity };
       await unitOfWork.Transaction.AddAsync(transaction);
       await unitOfWork.SaveAsync();
    }
}