using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.RemoveProduct;

public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveProductHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
    {
        bool result = await unitOfWork.Product.Delete(element => element.ProductId == request.ProductId);
        if (result)
        {
            await unitOfWork.SaveAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Product Is Not Exist");
    }
}