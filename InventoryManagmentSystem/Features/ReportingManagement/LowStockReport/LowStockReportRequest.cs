using InventoryManagmentSystem.Shared.APIResult;
using InventoryManagmentSystem.Shared.Model;
using MediatR;

namespace InventoryManagmentSystem.Features.ReportingManagement.LowStockReport;


public class LowStockReportRequest : IRequest<Result<IEnumerable<LowStockReportResponse>>>
{

}