
using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Shared.UnitOfWorks;

namespace InventoryManagmentSystem.Features.ProductManagement.Jobs;

public class DailyLowStockProducts : IDailyLowStockProducts
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<DailyLowStockProducts> logger;

    public DailyLowStockProducts( IUnitOfWork unitOfWork, ILogger<DailyLowStockProducts> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }
    public async Task Notify()
    {
        var productName = await unitOfWork.Product.GetProductsNameWithLowStock();
        foreach(var item in productName)
        {
            logger.LogInformation($"{item} Must Be ReStock");
        }
    }
}