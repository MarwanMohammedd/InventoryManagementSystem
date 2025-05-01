using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagmentSystem.Features.WarehouseManagement.RemoveWarehouse;

[ApiController]
[Route("[controller]")]
public class RemoveWarehouseController : ControllerBase
{
    private readonly IMediator mediator;

    public RemoveWarehouseController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
}