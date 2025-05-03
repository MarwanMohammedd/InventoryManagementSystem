using System.Security.Claims;
using FluentValidation;
using InventoryManagmentSystem.Features.AccountManagement.Models;
using InventoryManagmentSystem.Features.InventoryTransactions.Models;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;

public class AddStockCommandHandler : IRequestHandler<AddStockCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IValidator<AddStockCommandRequest> validator;
    private readonly IMediator mediator;

    public AddStockCommandHandler(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager , IValidator<AddStockCommandRequest> validator, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.userManager = userManager;
        this.validator = validator;
        this.mediator = mediator;
    }

    public async Task<Result<bool>> Handle(AddStockCommandRequest request, CancellationToken cancellationToken)
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
            
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Failed To Add Stock Operation");
    }
}