using InventoryManagmentSystem.Shared.UnitOfWorks;

namespace InventoryManagmentSystem.Shared.Registeration;

public class TransactionProcessMiddleware : IMiddleware
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<TransactionProcessMiddleware> logger;

    public TransactionProcessMiddleware( IUnitOfWork unitOfWork ,  ILogger<TransactionProcessMiddleware> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();
            await next(context);
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            logger.LogError(ex.Message);
        }
    }
}