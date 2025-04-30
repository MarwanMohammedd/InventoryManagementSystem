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
            Product product = new Product()
            {
                Id = request.NewProduct.Id,
                Name = request.NewProduct.Name,
                Description = request.NewProduct.Description,
                LowStockThreshold = request.NewProduct.LowStockThreshold,
                Price = request.NewProduct.Price,
            };
            await unitOfWork.Product.AddAsync(product);
            await unitOfWork.SaveAsync();
            return Result<Product>.Success(product);
        }
        return Result<Product>.Failure("Something Wrong With Add");
    }
}