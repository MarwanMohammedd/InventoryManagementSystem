using System.Runtime.CompilerServices;
using InventoryManagmentSystem.Features.ProductManagement.DTOs;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, Result<IEnumerable<GetAllProductsQueryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<GetAllProductsQueryResponse>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Product.ReadAllAsync(product => product.Include(p => p.Inventories).ThenInclude(i => i.Warehouse).Include(p=>p.Category));

        if (products is not null)
        {
            IEnumerable<GetAllProductsQueryResponse> results = products.Select(product =>
            new GetAllProductsQueryResponse()
            {
                Id = product.Id,
                Name = product.Name,
                ProductCategory = product.Category!.CategoryName,
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
            return Result<IEnumerable<GetAllProductsQueryResponse>>.Success(results);
        }
        return Result<IEnumerable<GetAllProductsQueryResponse>>.Failure("SomeThing Wrong In when Retrive the Products!!");
    }
}