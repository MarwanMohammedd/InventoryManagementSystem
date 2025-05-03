using System.Threading.Tasks;
using InventoryManagmentSystem.Features.ReportingManagement.Repository;
using InventoryManagmentSystem.Shared.UnitOfWorks;

namespace InventoryManagmentSystem.Features.ReportingManagement.Jobs;

public class ArchivedTransaction : IArchivedTransaction
{
    private readonly IUnitOfWork unitOfWork;
    public ArchivedTransaction(IUnitOfWork unitOfWork, ILogger<ArchivedTransaction> logger)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task Notify()
    {
        await unitOfWork.Transaction.BulkTransactionArchivedUpdate();
    }
}