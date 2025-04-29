using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductRequest, Result<Product>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddProductRequest> validator;

    public AddProductHandler(IUnitOfWork unitOfWork, IValidator<AddProductRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<Product>> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            await unitOfWork.Product.AddAsync(request.NewProduct);
            await unitOfWork.SaveAsync();
            return Result<Product>.Success(request.NewProduct);
        }
        return Result<Product>.Failure("Something Wrong With Add");
    }
}