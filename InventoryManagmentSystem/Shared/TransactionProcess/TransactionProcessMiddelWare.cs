
using InventoryManagmentSystem.Shared.UnitOfWork;

namespace InventoryManagmentSystem.Shared.Registeration;

public class TransactionProcessMiddelWare : IMiddleware
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<TransactionProcessMiddelWare> logger;

    public TransactionProcessMiddelWare(IUnitOfWork unitOfWork, ILogger<TransactionProcessMiddelWare> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await unitOfWork.StartTransactionAsync();
            await next(context);
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await unitOfWork.RollBackAsync();
            logger.LogError(ex.Message);
        }
    }
}