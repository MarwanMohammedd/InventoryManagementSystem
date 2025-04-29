using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.UnitOfWork;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class ArchivedTransaction : IArchivedTransaction
{
    private readonly IUnitOfWork unitOfWork;
    public ArchivedTransaction(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;

    }
    public void Archive()
    {
        unitOfWork.Transaction.BulkTransactionArchivedUpdate();
    }
}