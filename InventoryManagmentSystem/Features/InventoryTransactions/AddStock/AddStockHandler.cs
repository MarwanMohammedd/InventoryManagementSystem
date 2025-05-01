using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.AddStock;

public class AddStockHandler : IRequestHandler<AddStockRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddStockRequest> validator;

    public AddStockHandler(IUnitOfWork unitOfWork , IValidator<AddStockRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }

    public async Task<Result<bool>> Handle(AddStockRequest request, CancellationToken cancellationToken)
    {
        if(validator.Validate(request).IsValid)
        {
            Product product = await unitOfWork.Product.GetItemAsync(product => product.Id == request.ProductId, product => product.Include(item => item.Inventories));

        if (product is null)
        {
            return Result<bool>.Failure("Product Dose Not Exist");
        }

        Inventory inventory = product!.Inventories!.FirstOrDefault(item => item.WarehouseId == request.WarehouseId)!;

        if (inventory is null)
        {
            inventory = new Inventory()
            {
                ProductId = product.Id,
                WarehouseId = request.WarehouseId,
                Quantity = request.Quantity
            };

            await unitOfWork.Inventory.AddAsync(inventory);
        }
        else
        {
            inventory.Quantity += request.Quantity;
        }

        Transaction transaction = new()
        {
            Type = TransactionType.Add,
            Quantity = request.Quantity,
            Date = DateTime.UtcNow,
            ProductId = request.ProductId,
            UserId = 1,
            UserName = "System" 
        };

        await unitOfWork.Transaction.AddAsync(transaction);
        return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Something Wrong");
    }
}