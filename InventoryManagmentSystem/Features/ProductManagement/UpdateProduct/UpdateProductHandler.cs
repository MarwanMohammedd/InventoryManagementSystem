using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<UpdateProductRequest> validator;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IValidator<UpdateProductRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
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
                await unitOfWork.SaveAsync();
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