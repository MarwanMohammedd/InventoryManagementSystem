using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, Result<GetProductDetailsResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetProductDetailsHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetProductDetailsResponse>> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
    {
        Product? product = await unitOfWork.Product.GetItemAsync(item => item.Id == request.ProductID, p=>p.Include(pp=>pp.Inventories).ThenInclude(i=>i.Warehouse));
        if (product is not null)
        {
            // int totalQuantity;
            // if (unitOfWork.Product.GetTotalQuantityForProduct(product!.Id, out totalQuantity))
            // {
            // }

            GetProductDetailsResponse getProductDetailsResponse = new()
            {
                ProductID = product.Id,
                LowStockThreshold = product.LowStockThreshold,
                ProductName = product.Name,
                TotalQuantity = product.Inventories!.Sum(i => i.Quantity),
                Inventories = product.Inventories!.Select(i=>new InventoryDTO(){WareHouseName = i.Warehouse.Name , WareHouseId =i.WarehouseId, Quantity = i.Quantity})
            };
            return Result<GetProductDetailsResponse>.Success(getProductDetailsResponse);
        }
        return Result<GetProductDetailsResponse>.Failure("Product Does Not Exist!");
    }
}