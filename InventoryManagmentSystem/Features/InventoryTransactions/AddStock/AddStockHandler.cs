using FluentValidation;
using InventoryManagmentSystem.Features.TransactionRecorded;
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
    private readonly IMediator mediator;

    public AddStockHandler(IUnitOfWork unitOfWork, IValidator<AddStockRequest> validator, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
        this.mediator = mediator;
    }

    public async Task<Result<bool>> Handle(AddStockRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
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


            await mediator.Publish(new TransactionRecordedNotification
            {
                UserName = "System",
                Type = TransactionType.Add,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Date = DateTime.UtcNow,
                UserId = 1,
            });
            await unitOfWork.SaveAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Failed To Add Stock Operation");
    }
}