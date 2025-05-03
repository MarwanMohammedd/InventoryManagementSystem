using System.Linq.Expressions;

namespace InventoryManagmentSystem.Features.ReportingManagement.Specifications;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
}
