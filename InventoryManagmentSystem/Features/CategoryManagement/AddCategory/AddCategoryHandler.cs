using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.AddCategory;

public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddCategoryRequest> validator;

    public AddCategoryHandler(IUnitOfWork unitOfWork, IValidator<AddCategoryRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Category category = new()
            {
                CategoryName = request.CategoryName,
            };
            await unitOfWork.Category.AddAsync(category);
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Add Category Operation");
    }
}