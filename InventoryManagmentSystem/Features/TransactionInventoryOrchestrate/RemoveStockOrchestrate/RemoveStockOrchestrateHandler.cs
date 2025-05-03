using InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.RemoveStock;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.RemoveStockOrchestrate;

public class RemoveStockOrchestrateHandler : IRequestHandler<RemoveStockOrchestrateRequest, Result<bool>>
{
    private readonly IMediator mediator;
    private readonly IUnitOfWork unitOfWork;

    public RemoveStockOrchestrateHandler(IMediator mediator, IUnitOfWork unitOfWork)
    {
        this.mediator = mediator;
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(RemoveStockOrchestrateRequest request, CancellationToken cancellationToken)
    {
        var removeStockResult = await mediator.Send(new RemoveStockCommandRequest()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            WarehouseId = request.WarehouseId
        });

        if (removeStockResult.IsSuccess)
        {
            var transactionRecordedResult = await mediator.Send(new TransactionRecordedRequest()
            {
                ProductId = request.ProductId,
                Date = DateTime.UtcNow,
                Quantity = request.Quantity,
                Type = TransactionType.Remove,
                UserId = request.UserId,
            });

            if (transactionRecordedResult.IsSuccess)
            {
                await unitOfWork.SaveChangesAsync();
                return Result<bool>.Success(true);
            }
        }
        return Result<bool>.Failure("Remove Stock Is Failed");
    }
}