using FluentValidation;
using InventoryManagmentSystem.Features.ProductManagement.Models;
using InventoryManagmentSystem.Features.ReportingManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Features.TransactionRecorded;

public class TransactionRecordedEvent : IRequestHandler<TransactionRecordedRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<TransactionRecordedRequest> validator;

    public TransactionRecordedEvent(IUnitOfWork unitOfWork, IValidator<TransactionRecordedRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }

    public async Task<Result<bool>> Handle(TransactionRecordedRequest request, CancellationToken cancellationToken)
    {
        if (validator.Validate(request).IsValid)
        {
            Product ProductCategory = await unitOfWork.Product.GetItemAsync(p=>p.Id == request.ProductId , pp=>pp.Include(ppp=>ppp.Category));

            TransactionEntity transaction = new()
            {
                Date = DateTime.UtcNow,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Type = request.Type,
                FromWarehouseId = request.FromWareHouseId,
                ToWarehouseId = request.ToWareHouseId,
                ProductCategory = ProductCategory!.Category!.CategoryName,
                UserId = request.UserId,
            };
            await unitOfWork.Transaction.AddAsync(transaction);
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Transaction Recording Is Fail");
    }
}


