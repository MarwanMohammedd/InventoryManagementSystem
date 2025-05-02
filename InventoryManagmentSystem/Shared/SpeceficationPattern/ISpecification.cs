using System.Linq.Expressions;

namespace InventoryManagmentSystem.Shared.SpeceficationPattern;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
}
