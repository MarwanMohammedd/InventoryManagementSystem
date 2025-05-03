using InventoryManagmentSystem.Features.InventoryTransactions.Event;
using InventoryManagmentSystem.Features.InventoryTransactions.Models;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Commands.RemoveStock;

public class RemoveStockHandler : IRequestHandler<RemoveStockCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public RemoveStockHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }
    public async Task<Result<bool>> Handle(RemoveStockCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = await unitOfWork.Product.GetItemAsync
        (product => product.Id == request.ProductId,
         product => product.Include(product => product.Inventories).Include(item => item.Category));
        if (product is null)
        {
            return Result<bool>.Failure("Product is not found");
        }


        Inventory inventory = product!.Inventories!.FirstOrDefault(item => item.WarehouseId == request.WarehouseId)!;

        if (inventory is null)
        {
            return Result<bool>.Failure("Inventory not found for this warehouse");
        }

        if (inventory.Quantity < request.Quantity)
        {
            return Result<bool>.Failure("Not enough stock in the selected warehouse.");
        }


        inventory.Quantity -= request.Quantity;


        if(product.Inventories.Sum(i=> i.Quantity) < product.LowStockThreshold)
        {
            await mediator.Publish(new LowStockProductNotifcation(){ ProductName = product.Name});
        }

        return Result<bool>.Success(true);
    }
}