using FluentValidation;
using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using InventoryManagmentSystem.Shared.UnitOfWork;
using MediatR;

namespace InventoryManagmentSystem.Features.WarehouseManagement.AddWarehouse;


public class AddWarehouseHandler : IRequestHandler<AddWarehouseRequest, Result<bool>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddWarehouseRequest> validator;

    public AddWarehouseHandler(IUnitOfWork unitOfWork, IValidator<AddWarehouseRequest> validator)
    {
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<Result<bool>> Handle(AddWarehouseRequest request, CancellationToken cancellationToken)
    {

        if (validator.Validate(request).IsValid)
        {
            Warehouse warehouse = new (){
                Location = request.Location,
                Name = request.Name,
            };
            await unitOfWork.Warehouse.AddAsync(warehouse);
            await unitOfWork.SaveAsync();
            return Result<bool>.Success(true);
        }
        return Result<bool>.Failure("Invalid Adding WareHouse Operations");
    }
}
