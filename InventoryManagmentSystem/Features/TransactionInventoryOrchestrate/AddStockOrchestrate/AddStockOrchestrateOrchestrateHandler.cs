using InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.AddStockOrchestrate;

public class AddStockOrchestrateOrchestrateHandler : IRequestHandler<AddStockOrchestrateOrchestrateRequest, Result<bool>>
{
    private readonly IMediator mediator;
    private readonly IUnitOfWork unitOfWork;

    public AddStockOrchestrateOrchestrateHandler(IMediator mediator, IUnitOfWork unitOfWork)
    {
        this.mediator = mediator;
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(AddStockOrchestrateOrchestrateRequest request, CancellationToken cancellationToken)
    {
        var addStockResult = await mediator.Send(new AddStockCommandRequest()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            WarehouseId = request.WarehouseId
        });
        
        if (addStockResult.IsSuccess)
        {
            var transactionRecordedResult = await mediator.Send(new TransactionRecordedRequest()
            {
                ProductId = request.ProductId,
                Date = DateTime.UtcNow,
                Quantity = request.Quantity,
                Type = TransactionType.Add,
                UserId = request.UserId,
            });
            
            if (transactionRecordedResult.IsSuccess)
            {
                await unitOfWork.SaveChangesAsync();
                return Result<bool>.Success(true);
            }
        }
        return Result<bool>.Failure("Add Stock Is Faild");
    }
}