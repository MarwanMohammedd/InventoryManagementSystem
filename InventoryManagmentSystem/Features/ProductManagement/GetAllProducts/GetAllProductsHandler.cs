using System.Runtime.CompilerServices;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, Result<IEnumerable<GetAllProductsResponse>>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllProductsHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<GetAllProductsResponse>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Product.ReadAllAsync(product => product.Include(p => p.Inventories).ThenInclude(i => i.Warehouse));

        if (products is not null)
        {
            IEnumerable<GetAllProductsResponse> results = products.Select(product =>
            new GetAllProductsResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
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
            return Result<IEnumerable<GetAllProductsResponse>>.Success(results);
        }
        return Result<IEnumerable<GetAllProductsResponse>>.Failure("SomeThing Wrong In when Retrive the Products!!");
    }
}