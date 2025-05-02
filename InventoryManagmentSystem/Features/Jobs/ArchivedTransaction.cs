using System.Threading.Tasks;
using InventoryManagmentSystem.Shared.UnitOfWork;

namespace InventoryManagmentSystem.Features.Jobs;

public class ArchivedTransaction : IJobNotifiy
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<ArchivedTransaction> logger;

    public ArchivedTransaction(IUnitOfWork unitOfWork , ILogger<ArchivedTransaction> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public async Task Notify()
    {
       await unitOfWork.Transaction.BulkTransactionArchivedUpdate();
    }
}