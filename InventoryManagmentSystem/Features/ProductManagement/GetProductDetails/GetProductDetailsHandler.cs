using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.GetProductDetails;

public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, Result<Product>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetProductDetailsHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<Product>> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
    {
        Product? product = await unitOfWork.Product.GetItemAsync(item => item.ProductId == request.ProductID);
        if (product is not null)
        {
            return Result<Product>.Success(product);
        }
        return Result<Product>.Failure("Product Does Not Exist!");
    }
}