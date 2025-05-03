using InventoryManagmentSystem.Features.ProductManagement.DTOs;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQueryRequest, Result<GetProductDetailsQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetProductDetailsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetProductDetailsQueryResponse>> Handle(GetProductDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        Product? product = await unitOfWork.Product.GetItemAsync(item => item.Id == request.ProductID, p=>p.Include(pp=>pp.Inventories).ThenInclude(i=>i.Warehouse).Include(p=>p.Category));
        if (product is not null)
        {
            GetProductDetailsQueryResponse getProductDetailsResponse = new()
            {
                ProductID = product.Id,
                LowStockThreshold = product.LowStockThreshold,
                ProductCategory = product.Category!.CategoryName,
                ProductName = product.Name,
                TotalQuantity = product.Inventories!.Sum(i => i.Quantity),
                Inventories = product.Inventories!.Select(i=>new InventoryDTO(){WareHouseName = i.Warehouse.Name , WareHouseId =i.WarehouseId, Quantity = i.Quantity})
            };
            return Result<GetProductDetailsQueryResponse>.Success(getProductDetailsResponse);
        }
        return Result<GetProductDetailsQueryResponse>.Failure("Product Does Not Exist!");
    }
}