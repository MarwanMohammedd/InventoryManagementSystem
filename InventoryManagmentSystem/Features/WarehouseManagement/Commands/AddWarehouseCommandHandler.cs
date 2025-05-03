using FluentValidation;
using InventoryManagmentSystem.Features.WarehouseManagement.Models;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.Commands;


public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommandRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddWarehouseCommandRequest> validator;

    public AddWarehouseCommandHandler(IUnitOfWork unitOfWork, IValidator<AddWarehouseCommandRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(AddWarehouseCommandRequest request, CancellationToken cancellationToken)
    {

        if (validator.Validate(request).IsValid)
        {
            Warehouse warehouse = new (){
                Location = request.Location,
                Name = request.Name,
            };
            await unitOfWork.Warehouse.AddAsync(warehouse);
            await unitOfWork.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Adding WareHouse Operations");
    }
}
