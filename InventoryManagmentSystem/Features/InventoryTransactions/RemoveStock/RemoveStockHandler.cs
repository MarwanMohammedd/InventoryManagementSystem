using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.RemoveStock;

public class RemoveStockHandler : IRequestHandler<RemoveStockRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public RemoveStockHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;
    }
    public async Task<Result<bool>> Handle(RemoveStockRequest request, CancellationToken cancellationToken)
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


        await mediator.Publish(new TransactionRecordedNotification
        {
            Type = TransactionType.Remove,
            Quantity = request.Quantity,
            Date = DateTime.UtcNow,
            UserId = 2,
            ProductId = request.ProductId,
            ProductCategory = product.Category!.CategoryName,
            UserName = "System"
        });

        await unitOfWork.SaveAsync();

        return Result<bool>.Success(true);
    }
}