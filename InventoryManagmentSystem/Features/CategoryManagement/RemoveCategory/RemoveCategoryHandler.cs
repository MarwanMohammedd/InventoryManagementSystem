using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.RemoveCategory;

public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryRequest, Result<string>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveCategoryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<string>> Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Category.Delete(element => element.CategoryId == request.CategoryId);
        if(result)
        {
            return Result<string>.Success("Category Has Been Deleted Successfully!");
        }
            return Result<string>.Failure("Category Can Not Be Delete");
    }
}