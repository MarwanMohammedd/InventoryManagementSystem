using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

public class LowStockReportHandler : IRequestHandler<LowStockReportRequest, Result<IEnumerable<Product>>>
{
    private readonly IUnitOfWork unitOfWork;

    public LowStockReportHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<Product>>> Handle(LowStockReportRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.Product.GetLowStockThresholdProducts();
        if (result is not null)
        {
            return Result<IEnumerable<Product>>.Success(result);
        }
        return Result<IEnumerable<Product>>.Failure("Can Not Retrive Low Stock Products");
    }
}