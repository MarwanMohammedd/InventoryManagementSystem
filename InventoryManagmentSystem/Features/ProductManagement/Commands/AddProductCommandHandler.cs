using FluentValidation;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, Result<string>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddProductCommandRequest> validator;

    public AddProductCommandHandler(IUnitOfWork unitOfWork,  IValidator<AddProductCommandRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<string>> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Product product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                LowStockThreshold = request.LowStockThreshold,
                Price = request.Price,
                CategoryId = request.CategoryId,
            };
            await unitOfWork.Product.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Product Added Successfully");
        }
        return Result<string>.Failure("Something Wrong With Add");
    }
}