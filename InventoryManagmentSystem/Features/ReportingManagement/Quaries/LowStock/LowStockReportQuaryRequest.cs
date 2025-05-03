using InventoryManagmentSystem.Shared.APIResult;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.Quaries.LowStock;


public class LowStockReportQuaryRequest : IRequest<Result<IEnumerable<LowStockReportQuaryResponse>>>
{
    public int PageSize { get; set; }
    public int Page { get; set; }
}