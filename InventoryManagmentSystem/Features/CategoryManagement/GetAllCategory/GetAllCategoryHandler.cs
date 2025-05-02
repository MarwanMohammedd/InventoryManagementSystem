using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.GetAllCategory;

public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, Result<GetAllCategoryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllCategoryHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetAllCategoryResponse>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        GetAllCategoryResponse getAllCategoryResponse = new()
        {
            Categories = await unitOfWork.Category.ReadAllAsync()
        };
        return Result<GetAllCategoryResponse>.Success(getAllCategoryResponse);
    }
}