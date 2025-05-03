using Azure;
using InventoryManagmentSystem.Features.ProductManagement.DTOs;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.LowStock;

public class LowStockReportHandler : IRequestHandler<LowStockReportQuaryRequest, Result<IEnumerable<LowStockReportQuaryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;

    public LowStockReportHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<LowStockReportQuaryResponse>>> Handle(LowStockReportQuaryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await unitOfWork.Product.ReadAllAsync
        (product => product.Include(p => p.Inventories).ThenInclude(i => i.Warehouse));

        if (products is not null)
        {
            IEnumerable<LowStockReportQuaryResponse> results = products
            .Skip((request.Page-1) * request.PageSize)
            .Take(request.PageSize)
            .Where(p=>p.Inventories!.Sum(i=>i.Quantity) < p.LowStockThreshold)
            .Select(product =>
            new LowStockReportQuaryResponse()
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
                }),
                TotalPage = (int)Math.Ceiling((decimal) products.Count()/request.PageSize),
            }
            );
            return Result<IEnumerable<LowStockReportQuaryResponse>>.Success(results);
        }
        return Result<IEnumerable<LowStockReportQuaryResponse>>.Failure("Can Not Retrive Low Stock Products");
    }
}