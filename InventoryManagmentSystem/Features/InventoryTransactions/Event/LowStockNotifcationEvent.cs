using FluentValidation;
using MediatR;

namespace InventoryManagmentSystem.Features.InventoryTransactions.Event;

public class LowStockNotifcationEvent : INotificationHandler<LowStockProductNotifcation>
{
    private readonly ILogger<LowStockNotifcationEvent> logger;
    private readonly IValidator<LowStockProductNotifcation> validator;

    public LowStockNotifcationEvent(ILogger<LowStockNotifcationEvent> logger , IValidator<LowStockProductNotifcation> validator)
    {
        this.logger = logger;
        this.validator = validator;
    }
    public async Task Handle(LowStockProductNotifcation notification, CancellationToken cancellationToken)
    {
        if(validator.Validate(notification).IsValid)
        {
            logger.LogInformation($"{notification.ProductName}'s Quantity Falls Below Low Stock Threshold");
        }
    }
}