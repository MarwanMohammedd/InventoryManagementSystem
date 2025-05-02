using FluentValidation;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedEvent : INotificationHandler<TransactionRecordedNotification>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<TransactionRecordedEvent> logger;
    private readonly IValidator<TransactionRecordedNotification> validator;

    public TransactionRecordedEvent(IUnitOfWork unitOfWork,ILogger<TransactionRecordedEvent>  logger,  IValidator<TransactionRecordedNotification> validator)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
        this.validator = validator;
    }
    public async Task Handle(TransactionRecordedNotification notification, CancellationToken cancellationToken)
    {
        try 
        {
            if(validator.Validate(notification).IsValid)
            {
                Transaction transaction = new (){
                    UserName = notification.UserName,
                    Date = DateTime.UtcNow,
                    ProductId = notification.ProductId,
                    Quantity = notification.Quantity,
                    Type = notification.Type,
                    FromWarehouseId = notification.FromWareHouseId ,
                    ToWarehouseId = notification.ToWareHouseId,
                    ProductCategory = notification.ProductCategory,
                    UserId  = notification.UserId,
                };
                await unitOfWork.Transaction.AddAsync(transaction);
            }
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
        }
    }

}


