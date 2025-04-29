using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.ProductManagement.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, Result<IEnumerable<Product>>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetAllProductsHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Product>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> results = await unitOfWork.Product.ReadAllAsync();
        return Result<IEnumerable<Product>>.Success(results);
    }
}