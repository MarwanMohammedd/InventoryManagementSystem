using InventoryManagmentSystem.Shared.UnitOfWork;

namespace InventoryManagmentSystem.Features.Jobs;

public class DailyLowStockProducts : IJobNotifiy
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<DailyLowStockProducts> logger;

    public DailyLowStockProducts(IUnitOfWork unitOfWork , ILogger<DailyLowStockProducts> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }
    public async Task Notify()
    {
        var productName = await unitOfWork.Product.GetProductsNameWithLowStock();
        foreach(var item in productName)
        {
            logger.LogInformation($"{item} Must Be ReStck");
        }
    }
}