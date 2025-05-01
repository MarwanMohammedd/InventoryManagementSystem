using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;

public class LowStockReportHandler : IRequestHandler<LowStockReportRequest, Result<IEnumerable<LowStockReportResponse>>>
{
    private readonly IUnitOfWork unitOfWork;

    public LowStockReportHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<LowStockReportResponse>>> Handle(LowStockReportRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Product.ReadAllAsync(product => product.Include(p => p.Inventories).ThenInclude(i => i.Warehouse));

        if (products is not null)
        {
            IEnumerable<LowStockReportResponse> results = products.Where(p=>p.Inventories!.Sum(i=>i.Quantity) < p.LowStockThreshold).Select(product =>
            new LowStockReportResponse()
            {
                Id = product.Id,
                Name = product.Name,
                TotalQuantity = product.Inventories!.Sum(i => i.Quantity),
                LowStockThreshold = product.LowStockThreshold,
                Inventories = product?.Inventories!.Select(i => new InventoryDTO()
                {
                    WareHouseName = i.Warehouse!.Name,
                    WareHouseId = i.WarehouseId,
                    Quantity = i.Quantity,
                })
            }
            );
            return Result<IEnumerable<LowStockReportResponse>>.Success(results);
        }
        return Result<IEnumerable<LowStockReportResponse>>.Failure("Can Not Retrive Low Stock Products");
    }
}