using InventoryManagmentSystem.Features.CategoryManagement.DTOs;
using InventoryManagmentSystem.Features.CategoryManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Queries;

public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQueryRequest, Result<GetAllCategoryQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllCategoryHandler( IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var CategoriesName = await unitOfWork.Category.ReadAllAsync();

        GetAllCategoryQueryResponse getAllCategoryResponse = new()
        {
            Categories = CategoriesName.Select(c=>new CategoryDTO(){CategoryId = c.CategoryId , CategoryName =c.CategoryName}).ToList()
        };
        return Result<GetAllCategoryQueryResponse>.Success(getAllCategoryResponse);
    }
}