using InventoryManagmentSystem.Features.ProductManagement.Repository;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.ProductManagement.Commands;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Product.Delete(element => element.Id == request.ProductId);
        if (result)
        {
            await unitOfWork.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Product Is Not Exist");
    }
}