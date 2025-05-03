using InventoryManagmentSystem.Features.InventoryTransactions.Commands.AddStock;
using InventoryManagmentSystem.Features.InventoryTransactions.Commands.TransferStock;
using InventoryManagmentSystem.Features.TransactionRecorded;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using InventoryManagmentSystem.Shared.Utilities;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionInventoryOrchestrate.TransfarStockOrchestrate;

public class TransfarStockOrchestrateHandler : IRequestHandler<TransfarStockOrchestrateRequest, Result<bool>>
{
    private readonly IMediator mediator;
    private readonly IUnitOfWork unitOfWork;

    public TransfarStockOrchestrateHandler(IMediator mediator, IUnitOfWork unitOfWork)
    {
        this.mediator = mediator;
        this.unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(TransfarStockOrchestrateRequest request, CancellationToken cancellationToken)
    {
        var stockTransfareReuslt = await mediator.Send(new TransferStockCommandRequest()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            FromWareHouseId = request.FromWareHouseId,
            ToWareHouseId = request.ToWareHouseId
        });

        if (stockTransfareReuslt.IsSuccess)
        {
            var transfarRecordeResult = await mediator.Send(new TransactionRecordedRequest()
            {
                ProductId = request.ProductId,
                Date = DateTime.UtcNow,
                Quantity = request.Quantity,
                Type = TransactionType.Transfer,
                UserId = request.UserId,
                FromWareHouseId = request.FromWareHouseId,
                ToWareHouseId = request.ToWareHouseId
            });
            if (transfarRecordeResult.IsSuccess)
            {
                await unitOfWork.SaveChangesAsync();
                return Result<bool>.Success(true);
            }
        }
        return Result<bool>.Failure("Transar Stock is Failed");
    }
}