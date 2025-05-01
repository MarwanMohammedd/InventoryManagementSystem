using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.TransferStock;

public class TransferStockHandler : IRequestHandler<TransferStockRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;

    public TransferStockHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(TransferStockRequest request, CancellationToken cancellationToken)
    {

             var product = await unitOfWork.Product.GetItemAsync(
            p => p.Id == request.ProductId,
            q => q.Include(p => p.Inventories!)
        );

        if (product is null)
            return Result<bool>.Failure("Product not found.");

        var fromInventory = product.Inventories!.FirstOrDefault(i => i.WarehouseId == request.FromWareHouseId);
        if (fromInventory == null)
            return Result<bool>.Failure("Source warehouse inventory not found.");

        if (fromInventory.Quantity < request.Quantity)
            return Result<bool>.Failure("Insufficient stock in source warehouse.");

        var toInventory = product.Inventories!.FirstOrDefault(i => i.WarehouseId == request.ToWareHouseId);
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

        Transaction transaction = new()
        {
            Type = TransactionType.Transfer,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            FromWarehouseId = request.FromWareHouseId,
            ToWarehouseId = request.ToWareHouseId,
            Date = DateTime.UtcNow,
            UserId = 1,
            UserName = "System"
        };

        await unitOfWork.Transaction.AddAsync(transaction);
        await unitOfWork.SaveAsync();

        return Result<bool>.Success(true);
    }
}