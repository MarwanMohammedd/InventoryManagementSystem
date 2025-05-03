using FluentValidation;
using InventoryManagmentSystem.Features.CategoryManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Commands;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddCategoryCommandRequest> validator;

    public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<AddCategoryCommandRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Category category = new()
            {
                CategoryName = request.CategoryName,
            };
            await unitOfWork.Category.AddAsync(category);
            await unitOfWork.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Add Category Operation");
    }
}