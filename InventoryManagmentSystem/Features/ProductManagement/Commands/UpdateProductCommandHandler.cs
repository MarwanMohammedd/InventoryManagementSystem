using FluentValidation;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<UpdateProductCommandRequest> validator;

    public UpdateProductCommandHandler( IUnitOfWork unitOfWork, IValidator<UpdateProductCommandRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Product product = new Product()
            {
                Id = request.UpdatedProduct.Id,
                Name = request.UpdatedProduct.Name,
                Description = request.UpdatedProduct.Description,
                LowStockThreshold = request.UpdatedProduct.LowStockThreshold,
                Price = request.UpdatedProduct.Price,
            };
            bool result = await unitOfWork.Product.UpdateAsync(element => element.Id == request.OldProductID, product);
            if (result == true)
            {
                await unitOfWork.SaveChangesAsync();
                return Result<bool>.Success(result);
            }
            else
            {
                return Result<bool>.Failure("Something Wrong With Update");
            }
        }
        return Result<bool>.Failure("The Updated Product Is Not Valid!");
    }
}