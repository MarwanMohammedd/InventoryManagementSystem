using FluentValidation;
using InventoryManagmentSystem.Features.InventoryTransactions.Models;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Commands.TransferStock;

public class TransferStockCommandHandler : IRequestHandler<TransferStockCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<TransferStockCommandRequest> validator;
    private readonly IMediator mediator;

    public TransferStockCommandHandler(IUnitOfWork unitOfWork ,IValidator<TransferStockCommandRequest> validator, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
        this.mediator = mediator;
    }

    public async Task<Result<bool>> Handle(TransferStockCommandRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Product product = await unitOfWork.Product.GetItemAsync(
                    p => p.Id == request.ProductId,
                    q => q.Include(p => p.Inventories!).Include(item=>item.Category));

            if (product is null)
                return Result<bool>.Failure("Product Not Found");

            Inventory fromInventory = product.Inventories!.FirstOrDefault(i => i.WarehouseId == request.FromWareHouseId);
            if (fromInventory == null)
                return Result<bool>.Failure("Source WareHouse Inventory Not Found");

            if (fromInventory.Quantity < request.Quantity)
                return Result<bool>.Failure("Your Transfar Quantity Is Larger Than Stock Quantity In Source WareHouse");

            Inventory toInventory = product.Inventories!.FirstOrDefault(i => i.WarehouseId == request.ToWareHouseId);
            if (toInventory == null)
            {
                toInventory = new Inventory
                {
                    ProductId = request.ProductId,
                    WarehouseId = request.ToWareHouseId,
                    Quantity = 0
                };
                await unitOfWork.Inventory.AddAsync(toInventory);
            }

            fromInventory.Quantity -= request.Quantity;
            toInventory.Quantity += request.Quantity;


            return Result<bool>.Success(true);
        }

        return Result<bool>.Failure("Invalid In Transfer Operation");
    }
}