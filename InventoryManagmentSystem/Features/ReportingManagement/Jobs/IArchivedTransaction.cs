namespace InventoryManagmentSystem.Features.ReportingManagement.Jobs;

public interface IArchivedTransaction
{
    Task Notify();
}