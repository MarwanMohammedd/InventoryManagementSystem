namespace InventoryManagmentSystem.Features.InventoryTransactions.LowStockLoggingService;

public class LowStockLoggingService : ILowStockLoggingService
{
    private readonly ILogger<LowStockLoggingService> logger;

    public LowStockLoggingService(ILogger<LowStockLoggingService> logger)
    {
        this.logger = logger;
    }

    public void Log(string Name)
    {
       logger.LogInformation("");
    }
}