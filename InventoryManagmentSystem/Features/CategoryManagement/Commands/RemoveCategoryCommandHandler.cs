using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Repository.InventoryRepository;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.CategoryManagement.Commands;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, Result<string>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork  )
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<string>> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Category.Delete(element => element.CategoryId == request.CategoryId);
        if(result)
        {
            await unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Category Has Been Deleted Successfully!");
        }
            return Result<string>.Failure("Category Can Not Be Delete");
    }
}